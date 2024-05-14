using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextoPapel : MonoBehaviour
{
    public TMP_Text paper;
    public int indice;
    public Ideias ideiasPersonagem;
    public int investimento;
    public int sustentabilidade;

    // Start is called before the first frame update

    void Start()
    {
        ideiasPersonagem = IdeiasControle.Informacoes(indice);

        paper.text = ideiasPersonagem.ideia + "\n\n$$" + ideiasPersonagem.valorInvestimento;

        investimento = ideiasPersonagem.valorInvestimento;
        sustentabilidade = ideiasPersonagem.valorSustentabilidade;
    }

    public void atualizarIndice (int novoInidice) 
    {
        indice = novoInidice;
    }
}
