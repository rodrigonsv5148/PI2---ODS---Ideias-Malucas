using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThomasAnimacoes : MonoBehaviour
{
    private Animator controlador;

    // Start is called before the first frame update
    void Start()
    {
        controlador = GetComponent<Animator>();
    }

    public void animacaoPlay(int estado)
    {
        switch (estado)
        {
            case 0:
                controlador.SetBool("Carimbando", true);
                //controlador.SetTrigger("Pensando");
                break;
            case 1:
                controlador.SetBool("Carimbando", false);
                //controlador.SetTrigger("NPensando");
                break;
            case 2:
                controlador.SetTrigger("Aprovado");
                controlador.SetBool("Carimbando", false);
                break;
            case 3:
                
                controlador.SetTrigger("Rejeitado");
                controlador.SetBool("Carimbando", false);
                break;
        }
    }
}
