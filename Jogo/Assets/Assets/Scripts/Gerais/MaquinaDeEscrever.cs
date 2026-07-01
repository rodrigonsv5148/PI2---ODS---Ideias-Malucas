using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaquinaDeEscrever : MonoBehaviour
{
    [SerializeField] private List<string> phrasesList;
    [SerializeField] float tempoPorLetra = 0.2f;
    [SerializeField] RectTransform ScrollViewContent;
    [SerializeField] private TMP_Text textBox;
    [SerializeField] private string sceneName;

    private char[] letras;
    int actualLetterPosition = 0;
    private Coroutine atualDigitacao;
    private bool estaDigitando;

    [SerializeField] private List<GameObject> imagens;
    private int indexTextList;

    // Chama o primeiro texto
    void Start()
    {
        indexTextList = 0;
        WritePhrase(indexTextList);
        //mostrarImagem();
    }

    IEnumerator WriteTextMachine(char[] text)
    {
        estaDigitando = true;
        actualLetterPosition = 0;

        while (actualLetterPosition < text.Length)
        {
            yield return new WaitForSeconds(tempoPorLetra);

            textBox.text += text[actualLetterPosition];
            actualLetterPosition++;
        }

        estaDigitando = false;
    }

    private void WritePhrase(int index)
    {
        if (index < 0) index = 0;

        if (index < phrasesList.Count)
        {
            letras = phrasesList[index].ToCharArray();
            textBox.text = string.Empty;

            atualDigitacao = StartCoroutine(WriteTextMachine(letras));
        }
        else
        {
            LoadScene(sceneName);
        }
    }

    public void LoadScene(string _sceneName) 
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void Proximo()
    {
        ShowCinematicImage();

        if (estaDigitando)
        {
            if (atualDigitacao != null)
                StopCoroutine(atualDigitacao);

            textBox.text = phrasesList[indexTextList];
            //count = letras.Length;
            estaDigitando = false;
        }
        else 
        {
            ResetScrollViewContent();
            indexTextList++;
            WritePhrase(indexTextList);
        }
    }

    public void Anterior()
    {
        HideCinematicImage();

        if (estaDigitando)
        {
            if (atualDigitacao != null)
                StopCoroutine(atualDigitacao);

            textBox.text = phrasesList[indexTextList];
            estaDigitando = false;
        }
        else
        {
            ResetScrollViewContent();
            if (indexTextList > 0) indexTextList--;
            WritePhrase(indexTextList);
        }
    }

    private void ResetScrollViewContent()
    {
        ScrollViewContent.anchoredPosition = new Vector2(
            ScrollViewContent.anchoredPosition.x,
            0f);
    }

    private void ShowCinematicImage()
    {
        if (imagens.Count == 0 
            || indexTextList < 0 
            || indexTextList >= imagens.Count 
            || imagens[indexTextList] == null) return;

        if (imagens[indexTextList].activeSelf == false) 
        {
            imagens[indexTextList].SetActive(true);
        }
    }

    private void HideCinematicImage() 
    {
        if (imagens.Count == 0 
            || indexTextList < 0 
            || indexTextList >= imagens.Count 
            || imagens[indexTextList] == null) return;

        if (imagens[indexTextList].activeSelf == true)
        {
            imagens[indexTextList].SetActive(false);
        }
    }
}