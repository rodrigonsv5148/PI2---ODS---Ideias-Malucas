using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThomasAnimacoes : MonoBehaviour
{
    public Animator controlador;


    // Start is called before the first frame update
    void Start()
    {
        controlador = GetComponent<Animator>();
    }

    public void animacaoPlay(int estado)
    {
        controlador.SetBool("Pensando", false);
        controlador.ResetTrigger("Aprovado");
        controlador.ResetTrigger("Rejeitado");

        switch (estado)
        {
            case 0:
                controlador.SetBool("Pensando", true);
                break;
            case 1:
                break;
            case 2:
                controlador.SetTrigger("Aprovado");
                break;
            case 3:
                controlador.SetTrigger("Rejeitado");
                break;
        }
    }
}
