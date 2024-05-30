using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InformacoesPersonagens : MonoBehaviour
{
    public TMP_Text infos;
    public int indice;
    public Ideias repositorioIdeias;

    // Start is called before the first frame update
    void Start()
    {
        repositorioIdeias = IdeiasControle.Informacoes(indice);

        infos.text = "Nome: " + repositorioIdeias.name + "\n\n" + "Idade: " + repositorioIdeias.idade + "\n\n" + "Emprego: " + repositorioIdeias.emprego + "\n\n" + "Score: " + repositorioIdeias.score + "\n\n" + "Visitas: " + repositorioIdeias.qteVisitas + "\n\n"  + "Investimento: \n$$" + repositorioIdeias.valorInvestimento + "\n\n";
    }

    public void novoIndice(int inidicePersonagem)
    {
        indice = inidicePersonagem;
    }
}
