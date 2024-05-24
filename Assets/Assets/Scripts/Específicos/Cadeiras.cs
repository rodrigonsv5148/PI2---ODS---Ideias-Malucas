using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.UI;
using UnityEngine;
//using static UnityEditor.Progress;

public class Cadeiras : MonoBehaviour
{
    // Atributos referentes ao personagem sentar
    public int qteNPC = 0;
    public GameObject porta;
    private Porta scriptPorta;
    private ObjetosClicaveis localizacaoCadeiraSegundaria;

    // Atributos referentes a invoca��o de papel
    public int tagCadeira = 0;
    public GameObject outraCadeira = null;
    private Cadeiras scriptOutraCadeira = null;
    private string nomeDoComando;

    // Atributos referentes a corre��o de localiza��o
    [SerializeField] private float Xaxis;
    [SerializeField] private float Yaxis;
    private Vector3 xy = new Vector3();
    private Coroutine aumentarEscala;
    private Coroutine diminuirEscala;

    private void Start()
    {
        scriptPorta = porta.GetComponent<Porta>();
        if (tagCadeira == 1) 
        {
            scriptOutraCadeira = outraCadeira.GetComponent<Cadeiras>();
        }
        
        xy.x = Xaxis;
        xy.y = Yaxis;        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            qteNPC++;

            if (qteNPC == 1) 
            {        
                localizacaoCadeiraSegundaria = collision.GetComponent<ObjetosClicaveis>();
                
                localizacaoCadeiraSegundaria.novaPosicao(transform.position + xy);
                
                if (tagCadeira == 1) 
                {
                    aumentarEscala = StartCoroutine(localizacaoCadeiraSegundaria.novaEscala(false));
                    Invoke("papelEntrando", 1f);

                }

                if (tagCadeira == 2) 
                {
                    diminuirEscala = StartCoroutine(localizacaoCadeiraSegundaria.novaEscala(true));       
                    Invoke("papelSaindo", 1f); 
                }
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
                if (tagCadeira == 1) 
                {
                    StopCoroutine(aumentarEscala);
                    CancelInvoke("papelEntrando"); 
                }
                if (tagCadeira == 2) 
                {
                    StopCoroutine(diminuirEscala);
                    CancelInvoke("papelSaindo"); 
                }
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
    //Quando sentar na cadeira secundaria (1), o papel ir� sumir
    //se n�o tiver ninguem na secund�ria e na prim�ria a quantidade for igual a 1, � p o papel q sumiu voltar.
    //
}
