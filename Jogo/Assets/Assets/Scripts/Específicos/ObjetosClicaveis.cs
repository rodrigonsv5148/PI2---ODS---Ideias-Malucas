using FMODUnity;
using System.Collections;
using UnityEngine;

public class ObjetosClicaveis : MonoBehaviour
{
    //--------------------------------------------------------
    protected Vector2 posicaoInicial = new Vector2 (0f,0f);
    protected Vector2 andar = new Vector2(0.1f, 0.1f);
    protected Vector2 posicaoAtual = new Vector2(0f, 0f);
    [SerializeField] protected bool arrastavel = true;
    [SerializeField] float characterScaleOnSitOnBackChair;
    SpriteRenderer sr;
    int sortingLayerBase;
    bool isDragging;
    [SerializeField] bool isObject;
    //--------------------------------------------------------

    //Troca de cursor quando clica ---------------------------
    [SerializeField] protected Texture2D hoverCursor;
    protected Vector2 customHotspot = new Vector2(8,7);

    protected Vector2 defaultHotspot = new Vector2(10, 5);

    //--------------------------------------------------------

    //Audio do mouse -----------------------------------------

    /*[SerializeField] protected AudioClip somMouse;
    [SerializeField] protected AudioClip somEspecial;
    protected AudioSource audioSource;
    protected AudioSource audioSourceclique;*/

    //--------------------------------------------------------

    // Animacoes
    private Animator controlador;
    [SerializeField] private string nomeAnimacao;
    private bool AnimatorControler = false;
    //----------------------------------------------


    private void Awake()
    {
        controlador = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        if (sr != null && isObject) sortingLayerBase = sr.sortingOrder;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        if (controlador != null) AnimatorControler = true;

        /*audioSource = gameObject.AddComponent<AudioSource>();
        audioSourceclique = gameObject.AddComponent<AudioSource>();
        configurarAudio(somMouse, audioSource);
        configurarAudio(somEspecial, audioSourceclique);*/

        posicaoInicial = transform.position; // Pega a posição inicial do objeto   
    }

    protected virtual void OnMouseDown()
    {
        Cursor.SetCursor(hoverCursor, customHotspot, CursorMode.Auto);
        RuntimeManager.PlayOneShot(FMOD_Names.Events.SFXS.clickInteractible);
        //audioSource?.Play();
        if (arrastavel == false && AnimatorControler == true) 
        {
            controlador.SetTrigger(nomeAnimacao);

        } else posicaoAtual = posicaoInicial; // Passa a posição inicial para a atual, já que vamos alterar a atual mais a frente
    }

    protected virtual void OnMouseDrag()
    {
        isDragging = true;

        // Converte a posição do mouse na tela para uma posição no mundo 3D
        Vector2 posicaoMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (sr != null && isObject) sr.sortingOrder = 70;

        if (arrastavel) 
        {
            transform.position = posicaoMouse; // Faz o objeto seguir o mouse    
        }

        if (Input.GetMouseButtonDown(1))
        {
            
            //audioSourceclique.Play();
            Debug.Log("ativou efeito");
        }   
    }

    private void OnMouseExit()
    {
        if (sr != null && isObject) sr.sortingOrder = sortingLayerBase;

        isDragging = false;
    }

    public bool DraggingState() 
    {
        return isDragging;
    }

    protected void ativarEfeito(string nomeEfeito)
    {
        
    }

    protected virtual void OnMouseUp()
    {
        Cursor.SetCursor(null, defaultHotspot, CursorMode.Auto);

        if (arrastavel) transform.position = posicaoInicial; // Devolve o objeto a posição inicial
    }

    public void novaPosicao(Vector2 posicao) 
    {
        posicaoInicial = posicao;
    }

    public IEnumerator novaEscala(bool verdade) 
    {
        if (verdade == true) 
        {
            transform.localScale = new Vector3(characterScaleOnSitOnBackChair, characterScaleOnSitOnBackChair, 1f);
        }
        else 
        {
            transform.localScale = Vector3.one;
        }

        yield return new WaitForSeconds(1f);
    }

    /*protected void configurarAudio(AudioClip somClique, AudioSource AudioSourceName) 
    {
        AudioSourceName.clip = somClique;
        AudioSourceName.playOnAwake = false;
        AudioSourceName.loop = false;
    }*/
}
