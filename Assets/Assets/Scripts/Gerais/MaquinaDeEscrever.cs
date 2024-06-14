using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MaquinaDeEscrever : MonoBehaviour
{
    [SerializeField] private List<string> texto;
    [SerializeField] private List<GameObject> imagens;
    private char[] letras;
    public TMP_Text Viewer;
    [SerializeField] float tempoLetra = 0.2f;
    private Coroutine atualDigitacao;

    [SerializeField] string proxCena;

    private int count = 0;
    private int count2 = 0;
    private int counti = 0;

    // Chama o primeiro texto
    void Start()
    {
        MostrarTextoAtual();
        mostrarImagem();
    }

    IEnumerator MostrarTexto()
    {
        while (count < letras.Length)
        {
            yield return new WaitForSeconds(tempoLetra);
            Viewer.text += letras[count];
            count++;
            if (count == letras.Length) 
            {
                mostrarImagem();
            }
        }
        count = 0;
    }

    private void MostrarTextoAtual()
    {
        if (count2 < texto.Count)
        {
            letras = texto[count2].ToCharArray();
            Viewer.text = null;
            atualDigitacao = StartCoroutine(MostrarTexto());
        }
        else
        {
            SceneManager.LoadScene(proxCena);
        }
    }

    protected void OnMouseDown()
    {
        // Se o texto atual não estiver completo, exibe o texto completo
        if (count < letras.Length)
        {
            StopCoroutine(atualDigitacao);
            Viewer.text = texto[count2];
            count = letras.Length; // Define count para evitar reiniciar a corrotina
            mostrarImagem();            
        }
        else
        {
            // Avança para o próximo texto
            count2++;
            count = 0;
            MostrarTextoAtual();
        }
    }

    private void mostrarImagem() 
    {
        if (imagens.Count != 0) 
        {
            if (counti < imagens.Count) 
            {
                imagens[counti].SetActive(true);
                counti++;
            }
        }
    }
}