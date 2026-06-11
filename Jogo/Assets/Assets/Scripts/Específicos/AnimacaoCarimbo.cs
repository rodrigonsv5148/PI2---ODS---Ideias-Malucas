using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacaoCarimbo : MonoBehaviour
{
    private Animator carimbadaAnimacao;

    // Start is called before the first frame update
    void Start()
    {
        carimbadaAnimacao = GetComponent<Animator>();
    }

    public void sim() 
    {
        carimbadaAnimacao.SetTrigger("CarimboSim");
    }

    public void nao()
    {
        carimbadaAnimacao.SetTrigger("CarimboNao");
    }
}
