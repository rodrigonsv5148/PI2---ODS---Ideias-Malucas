using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iniciar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.dinheiro = 1400000;
        GameManager.sustentabilidadeDoMundo = 0;
        GameManager.qtePropostas = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
