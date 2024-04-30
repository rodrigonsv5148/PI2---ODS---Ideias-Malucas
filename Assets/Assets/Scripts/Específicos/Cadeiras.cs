using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using static UnityEditor.Progress;

public class Cadeiras : MonoBehaviour
{
    // Atributos referentes ao personagem sentar
    public int qteNPC = 0;
    public GameObject porta;
    private Porta scriptPorta;
    private ObjetosClicaveis localizacaoCadeiraSegundaria;

    // Atributos referentes a invocação de papel
    public int tagCadeira = 0;
    public GameObject outraCadeira = null;
    private Cadeiras scriptOutraCadeira = null;
    private string nomeDoComando;

    private void Start()
    {
        scriptPorta = porta.GetComponent<Porta>();
        if (tagCadeira == 1) 
        {
            scriptOutraCadeira = outraCadeira.GetComponent<Cadeiras>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            qteNPC++;

            if (qteNPC == 1) 
            {
                localizacaoCadeiraSegundaria = collision.GetComponent<ObjetosClicaveis>();
                localizacaoCadeiraSegundaria.novaPosicao(transform.position);
                if (tagCadeira == 1) Invoke("papelEntrando", 1.5f);
                if (tagCadeira == 2) Invoke("papelSaindo", 1.5f);
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
                if (tagCadeira == 1) CancelInvoke("papelEntrando");
                if (tagCadeira == 2) CancelInvoke("papelSaindo");
            }  
        }
    }

    public void papelSaindo () 
    {
        scriptPorta.papelInGame[0].SetActive(false);
    }
    public void papelEntrando()
    {
        if (scriptOutraCadeira.qteNPC == 0) 
        {
            scriptPorta.papelInGame[0].SetActive(true);
        }
    }
    //Quando sentar na cadeira secundaria (1), o papel irá sumir
    //se não tiver ninguem na secundária e na primária a quantidade for igual a 1, é p o papel q sumiu voltar.
    //
}
