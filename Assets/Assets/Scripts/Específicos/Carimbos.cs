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

    // Anima��o de Thomas
    public GameObject thomas;
    private ThomasAnimacoes animacoes;

    // Anima��es carimbada
    public GameObject animacoesCarimbo;
    private AnimacaoCarimbo animacaoCarimbada;

    //som carimbada

    protected override void Start()
    {
        animacoes = thomas.GetComponent<ThomasAnimacoes>();
        animacaoCarimbada = animacoesCarimbo.GetComponent<AnimacaoCarimbo>();

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSourceclique = gameObject.AddComponent<AudioSource>();
        configurarAudio(somMouse, audioSource);
        configurarAudio(somEspecial, audioSourceclique);

        posicaoInicial = transform.position; // Pega a posi��o inicial do objeto
    }

    protected override void OnMouseDrag()
    {
        animacoes.animacaoPlay(0);
        Vector2 posicaoMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (arrastavel)
        {
            transform.position = posicaoMouse; // Faz o objeto seguir o mouse    
        }

        if (Input.GetMouseButtonDown(1))
        {
            audioSourceclique.Play();
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

    protected override void OnMouseUp()
    {
        Cursor.SetCursor(null, defaultHotspot, CursorMode.Auto);
        if (arrastavel) transform.position = posicaoInicial; // Devolve o objeto a posi��o inicial
        animacoes.animacaoPlay(1);
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
            case 1://estado de nega��o
                animacaoCarimbada.nao();
                animacoes.animacaoPlay(3);
                GameManager.qtePropostas++;
                GameManager.propostas();
                destruirPapelENPC();
                break;

            case 2: //estado de aprova��o
                animacaoCarimbada.sim();
                animacoes.animacaoPlay(2);
                GameManager.qtePropostas++;
                GameManager.proximo(scriptPapel.investimento, scriptPapel.sustentabilidade);
                GameManager.propostas();
                destruirPapelENPC();
                break;

            default:
                Debug.Log("Clique fora do papel");
                break;
        }
    }

    private void destruirPapelENPC()
    {
        Destroy(GameObject.Find("infoNPC " + indicePapel.ToString()));
        Destroy(GameObject.Find("NPC " + indicePapel.ToString()));
        Destroy(GameObject.Find("Papel " + indicePapel.ToString()));
    }
}