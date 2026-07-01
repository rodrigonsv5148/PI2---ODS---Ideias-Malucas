using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public int dinheiro = 1400000;
    static public int sustentabilidadeDoMundo = 0;
    static public int qtePropostas;

    // Start is called before the first frame update
    void Start()
    {

        qtePropostas = 0;

    }

    // Para projetos aprovados:
    public static void proximo(int dinheiroProjeto, int sustentatibilidadeProjeto) 
    {
        dinheiro -= dinheiroProjeto;
        sustentabilidadeDoMundo += sustentatibilidadeProjeto;
    }

    public static void propostas() 
    {
        Debug.Log(dinheiro);
        Debug.Log(sustentabilidadeDoMundo);
        Debug.Log(qtePropostas);

        // 0 = falha por falta de dinheiro
        // 1 = falha por falta de sustentabilidade
        // 2 = vit�ria por passar mais um dia

        if (qtePropostas <= 7)
        {
            if (dinheiro < 0) SceneManager.LoadScene(Scene_Names.Cinematics.badEndMoney);
        }
        else
        {
            if (sustentabilidadeDoMundo > 0 && dinheiro > 0) SceneManager.LoadScene(Scene_Names.Cinematics.goodEnd);

            else if (dinheiro < 0) SceneManager.LoadScene(Scene_Names.Cinematics.badEndMoney);

            else if (sustentabilidadeDoMundo < 0) SceneManager.LoadScene(Scene_Names.Cinematics.badEndSustentability);
        }
    }
}
