using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carimbos : ObjetosClicaveis
{
    [SerializeField] private string tagPapel;
    [SerializeField] private string tagCarimboNao;
    [SerializeField] private string tagCarimboSim;
    private int estado;
    private int indicePapel;
    private TextoPapel scriptPapel;

    protected override void OnMouseDrag() 
    {
        Vector2 posicaoMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (arrastavel)
        {
            transform.position = posicaoMouse; // Faz o objeto seguir o mouse    
        }

        if (Input.GetMouseButtonDown(1))
        {
            carimbada();
            Debug.Log("ativou efeito carimbo");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagPapel && gameObject.tag == tagCarimboNao)
        {
            scriptPapel = collision.GetComponent<TextoPapel>();
            indicePapel = scriptPapel.indice;
            estado = 1;
        }
        if (collision.gameObject.tag == tagPapel && gameObject.tag == tagCarimboSim)
        {
            scriptPapel = collision.GetComponent<TextoPapel>();
            indicePapel = scriptPapel.indice;
            estado = 2;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        Debug.Log("saiu");
        if (collision.gameObject.tag == tagPapel) 
        {
            estado = 0;
            indicePapel = -1;
        }
    }

    private void carimbada() 
    {
        switch (estado)
        {
            case 1://estado de negação

              
                Debug.Log(estado);

                destruirPapelENPC();
                break;

            case 2: //estado de aprovação
                
                GameManager.proximo(scriptPapel.investimento, scriptPapel.sustentabilidade);

                Debug.Log(estado);
                
                destruirPapelENPC();
                break;

            default:

                Debug.Log("Clique fora do papel");
                break;
        }
    }

    private void destruirPapelENPC() 
    {
        Destroy(GameObject.Find("NPC " + indicePapel.ToString()));
        Destroy(GameObject.Find("Papel " + indicePapel.ToString()));
    }
}
