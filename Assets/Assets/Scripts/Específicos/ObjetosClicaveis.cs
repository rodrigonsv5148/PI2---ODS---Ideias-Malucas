using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosClicaveis : MonoBehaviour
{
    //--------------------------------------------------------
    protected Vector2 posicaoInicial = new Vector2 (0f,0f);
    protected Vector2 andar = new Vector2(0.1f, 0.1f);
    protected Vector2 posicaoAtual = new Vector2(0f, 0f);
    [SerializeField] protected bool arrastavel = true;

    //--------------------------------------------------------

    //Troca de cursor quando clica ---------------------------
    [SerializeField] protected Texture2D hoverCursor;
    protected Vector2 customHotspot = new Vector2(8,7);

    protected Vector2 defaultHotspot = new Vector2(10, 5);

    //--------------------------------------------------------

    //Audio do mouse -----------------------------------------

    [SerializeField] protected AudioClip somMouse;
    [SerializeField] protected AudioClip somEspecial;
    protected AudioSource audioSource;
    protected AudioSource audioSourceclique;

    //--------------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSourceclique = gameObject.AddComponent<AudioSource>();
        configurarAudio(somMouse, audioSource);
        configurarAudio(somEspecial, audioSourceclique);

        posicaoInicial = transform.position; // Pega a posição inicial do objeto
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    protected void OnMouseDown()
    {
        Cursor.SetCursor(hoverCursor, customHotspot, CursorMode.Auto);
        audioSource.Play();

        posicaoAtual = posicaoInicial; // Passa a posição inicial para a atual, já que vamos alterar a atual mais a frente
    }

    protected virtual void OnMouseDrag()
    {
        // Converte a posição do mouse na tela para uma posição no mundo 3D
        Vector2 posicaoMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (arrastavel) 
        {
            transform.position = posicaoMouse; // Faz o objeto seguir o mouse    
        }

        if (Input.GetMouseButtonDown(1))
        {
            audioSourceclique.Play();
            Debug.Log("ativou efeito");
        }   
    }

    protected void ativarEfeito(string nomeEfeito)
    {
        
    }

    protected void OnMouseUp()
    {
        Cursor.SetCursor(null, defaultHotspot, CursorMode.Auto);

        transform.position = posicaoInicial; // Devolve o objeto a posição inicial
    }

    public void novaPosicao(Vector2 posicao) 
    {
        posicaoInicial = posicao;
    }

    public IEnumerator novaEscala(bool verdade) 
    {
        if (verdade == true) 
        {
            transform.localScale = new Vector3(0.075f, 0.075f, 1f);
        }
        else 
        {
            transform.localScale = new Vector3(0.25f, 0.25f, 1f);
        }

        yield return new WaitForSeconds(1f);
    }

    protected void configurarAudio(AudioClip somClique, AudioSource AudioSourceName) 
    {
        AudioSourceName.clip = somClique;
        AudioSourceName.playOnAwake = false;
        AudioSourceName.loop = false;
    }
}
