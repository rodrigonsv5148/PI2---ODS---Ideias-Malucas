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
    private int sustentabilidade;
    private int dinheiro;

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
            estado = 1;
        }
        if (collision.gameObject.tag == tagPapel && gameObject.tag == tagCarimboSim)
        {
            estado = 2;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        Debug.Log("saiu");
        if (collision.gameObject.tag == tagPapel) 
        {
            estado = 0;
        }
    }

    private void carimbada() 
    {
        GameObject[] listaPapeis = GameObject.FindGameObjectsWithTag(tagPapel);

        foreach (GameObject papel in listaPapeis)
        {
            switch (estado)
            {
                case 1://estado de negação

                    // Só destruir o npc agora
                    destruirPapel(papel);
                    Debug.Log(estado);
                    break;

                case 2: //estado de aprovação

                    //falta pegar o dinheiro e a sustentabilidade de algum lugar

                    GameManager.proximo(dinheiro, sustentabilidade);

                    // Só destruir o npc agora
                    destruirPapel(papel);
                    Debug.Log(estado);
                    break;

                default:
                    Debug.Log("Clique fora do papel");
                    break;

                    // talvez depois que ativar o efeito, seja necessário mudar o estado p 0, assim, n tô dizendo nada, só acho e.e
            }
        }
    }

    private void destruirPapel(GameObject papel) 
    {
        if (papel.activeSelf) 
        {
            Destroy(papel);
        }
    }
}
