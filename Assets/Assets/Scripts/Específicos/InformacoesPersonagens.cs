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

        infos.text = "Nome: " + repositorioIdeias.name + "\n" + "Idade: " + repositorioIdeias.idade + "\n" + "Emprego: " + repositorioIdeias.emprego + "\n" + "Score: " + repositorioIdeias.score + "\n" + "Visitas: " + repositorioIdeias.qteVisitas + "\n";
    }

    public void novoIndice(int inidicePersonagem)
    {
        indice = inidicePersonagem;
    }
}
