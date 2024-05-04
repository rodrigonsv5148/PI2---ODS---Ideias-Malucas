using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public int dinheiro = 50;
    static public int sustentabilidadeDoMundo = 20;
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void proximo(int dinheiroProjeto, int sustentatibilidadeProjeto) 
    {
        dinheiro -= dinheiroProjeto;
        sustentabilidadeDoMundo -= sustentatibilidadeProjeto;
        Debug.Log(dinheiro);
        Debug.Log(sustentabilidadeDoMundo);
    }

}
