using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextoPapel : MonoBehaviour
{
    public TMP_Text paper;
    public int indice;
    public Ideias ideiasPersonagem;
    // Start is called before the first frame update
    
    void Start()
    {
        ideiasPersonagem = IdeiasControle.Informacoes(indice);

        paper.text = ideiasPersonagem.ideia + "\n\n\n$$$$" + ideiasPersonagem.valorInvestimento;
    }

    public void atualizarIndice (int novoInidice) 
    {
        indice = novoInidice;
    }
}
