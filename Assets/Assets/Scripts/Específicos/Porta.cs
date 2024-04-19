using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.Audio;


public class Porta : MonoBehaviour
{
    [SerializeField] private bool interativo = false;
    
    //Variáveis relativas à parte de audio 
    [SerializeField] private List<ScriptableSons> scriptableAudio;
    [SerializeField] private AudioSource audioSource;
    private ScriptableSons scriptableAudioProximo;
    private ScriptableSons scriptableAudioPassos;
    private ScriptableSons scriptableAudioPorta;
    private int qteAudiosProximo;
    private int qteAudiosPassos;
    private int qteAudiosPorta;
    private float tempoAudio;
    //-----------------------------------------------

    // Relacionados aos personagens
    [SerializeField] private ScriptablePersonagens listaPersonagens;
    [SerializeField] private ScriptablePersonagens personagemLocationBase;
    private int qtePersonagens;
    private int charactereAtualNumber;
    List<int> personagensUsados;
    private GameObject[] personagensInGame = new GameObject[4];
    private GameObject[] papelInGame = new GameObject[4];

    //----------------------------------------------

    // Relacionados ao papel
    [SerializeField] private GameObject papel;
    [SerializeField] private GameObject papelLocationBase;
    
    //---------------------------------------------------

    private void Start()
    {
        // Algoritmo para pegar a quantidade de audios do scriptable object
        scriptableAudioProximo = scriptableAudio[0];
        scriptableAudioPassos = scriptableAudio[1];
        scriptableAudioPorta = scriptableAudio[2];

        qteAudiosProximo = qteAudios(scriptableAudioProximo);
        qteAudiosPassos = qteAudios(scriptableAudioPassos);
        qteAudiosPorta = qteAudios(scriptableAudioPorta);

        qtePersonagens = listaPersonagens.Characteres.Count;  
    }

    //Abrir a porta
    public void OnMouseDown()
    {
        if (interativo == false)
        {
            
            //spawnandoPersonagem = true; // Variável de controle para não ativar o mesmo evento simultâneamente
            Debug.Log("ativou efeito");

            tempoAudio = playAudios(qteAudiosProximo, scriptableAudioProximo);
            StartCoroutine(tempoDeEspera(tempoAudio));

            tempoAudio = playAudios(qteAudiosPorta, scriptableAudioPorta);
            //Aqui que entra a animação (preciso da animação p fazer isso, acho q placeholder n ficaria legal)
            StartCoroutine(tempoDeEspera(tempoAudio));

            tempoAudio = playAudios(qteAudiosPassos, scriptableAudioPassos);
            StartCoroutine(tempoDeEspera(tempoAudio));

            charactereAtualNumber = Random.Range(0, qtePersonagens);
            while (personagensUsados.Contains(charactereAtualNumber)) 
            {
                charactereAtualNumber = Random.Range(0, qtePersonagens);
            }
            personagensUsados.Add(charactereAtualNumber);

            // tenho a lista atualizada e o valor do personagem que vou pegar na lista de assets


            Debug.Log("Aquiiiiiii " + tempoAudio);
        }
    }

    // Função que serve de tempo de espera entre ações
    IEnumerator tempoDeEspera(float tempoCoroutine) 
    {
        yield return new WaitForSeconds(tempoCoroutine);
    }

    // Bloco que pega um scriptable objetc com audios e devolve a quantidade de audios
    private int qteAudios(ScriptableSons scriptable)
    {
        List<AudioClip> audio = scriptable.audios;
        return (audio.Count);
    }

    // Função que seleciona um audio aleatório do scriptable object, da play e retorna a duração desse audio
    private float playAudios(int qteAudios, ScriptableSons scriptable) 
    {
        int numeroAudio = Random.Range(0, qteAudios);
        float tempoAudio;
        
        audioSource.clip = scriptable.audios[numeroAudio]; // seta o clip no audio source
        tempoAudio = scriptable.audios[numeroAudio].length; // pega o tempo do audio

        audioSource.Play();
        return(tempoAudio);
    }
}