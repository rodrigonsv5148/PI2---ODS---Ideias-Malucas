using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using static UnityEditor.Progress;

public class Cadeiras : MonoBehaviour
{
    public bool cadeiraOcupada = false;
    public int qteNPC = 0;
    private ObjetosClicaveis localizacaoCadeiraSegundaria;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            qteNPC++;

            if (qteNPC == 1) 
            {
                localizacaoCadeiraSegundaria = collision.GetComponent<ObjetosClicaveis>();
                localizacaoCadeiraSegundaria.novaPosicao(transform.position);
                print("NPC sentou");
            }            
        }
    }
  
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            qteNPC--;

            if(qteNPC == 0) 
            {
                print("NPC saiu");
            }
            
        }
    }
}
