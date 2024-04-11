using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class IdeiasControle : MonoBehaviour
{

    // tirar do start e botar quando o NPC sair.
    // Start is called before the first frame update
    void Start()
    {
        //Carrega o arquivo JSON
        var jsonFile = Resources.Load<TextAsset>("Save/Ideias");

        // Desserializa o JSON para um objeto C#
        TodasIdeias arquivoJson = JsonUtility.FromJson<TodasIdeias>(jsonFile.text);

        // Acessa o vetor de jogadores e obtém o jogador na posição desejada
        int indiceVetor = 0; // índice do jogador que queremos acessar
        Ideias ideiaDaVez = arquivoJson.listaIdeias[indiceVetor];

        Debug.Log(ideiaDaVez.name);
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
    }
}
