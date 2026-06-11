using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class IdeiasControle : MonoBehaviour
{
    public static Ideias Informacoes(int indiceJSON) 
    {
        //Carrega o arquivo JSON
        var jsonFile = Resources.Load<TextAsset>("Save/Ideias");

        // Desserializa o JSON para um objeto C#
        TodasIdeias arquivoJson = JsonUtility.FromJson<TodasIdeias>(jsonFile.text);

        // Acessa o vetor de jogadores e obtém o jogador na posição desejada
        Ideias ideiaDaVez = arquivoJson.listaIdeias[indiceJSON];

        /*Debug.Log(ideiaDaVez.name);
        Debug.Log(ideiaDaVez.idade);
        Debug.Log(ideiaDaVez.sexo);
        Debug.Log(ideiaDaVez.emprego);
        Debug.Log(ideiaDaVez.score);
        Debug.Log(ideiaDaVez.qteVisitas);
        Debug.Log(ideiaDaVez.conseguiuCredito);
        Debug.Log(ideiaDaVez.valorDoCredito);

        Debug.Log(ideiaDaVez.valorInvestimento);
        Debug.Log(ideiaDaVez.ideia);
        Debug.Log(ideiaDaVez.valorSustentabilidade);

        Debug.Log(ideiaDaVez.resposta);*/

        return ideiaDaVez;
    }
}
