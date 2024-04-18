using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.Audio;


public class Porta : MonoBehaviour
{
    [SerializeField] private bool spawnandoPersonagem = false;
    [SerializeField] private List<ScriptableSons> scriptableAudio;
    private ScriptableSons scriptableAudioProximo;
    private ScriptableSons scriptableAudioPassos;
    private ScriptableSons scriptableAudioPorta;

    [SerializeField]private AudioSource audioSource;
    private int qteAudiosProximo;
    private int qteAudiosPassos;
    private int qteAudiosPorta;
    private float tempoAudio;

    private void Start()
    {
        // Algoritmo para pegar a quantidade de audios do scriptable object
        scriptableAudioProximo = scriptableAudio[0];
        scriptableAudioPassos = scriptableAudio[1];
        scriptableAudioPorta = scriptableAudio[2];

        qteAudiosProximo = qteAudios(scriptableAudioProximo);
        qteAudiosPassos = qteAudios(scriptableAudioPassos);
        qteAudiosPorta = qteAudios(scriptableAudioPorta);

    }

    //Abrir a porta
    public void OnMouseDown()
    {
        if (spawnandoPersonagem == false)
        {
            //spawnandoPersonagem = true; // Variável de controle para não ativar o mesmo evento simultâneamente
            Debug.Log("ativou efeito");

            tempoAudio = playAudios(qteAudiosProximo, scriptableAudioProximo);
            StartCoroutine(tempoDeEspera(tempoAudio));

            tempoAudio = playAudios(qteAudiosPassos, scriptableAudioPassos);
            StartCoroutine(tempoDeEspera(tempoAudio));

            tempoAudio = playAudios(qteAudiosPorta, scriptableAudioPorta);
            StartCoroutine(tempoDeEspera(tempoAudio));

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
        
        audioSource.clip = scriptable.audios[numeroAudio];
        tempoAudio = scriptable.audios[numeroAudio].length; // 

        audioSource.Play();
        return(tempoAudio);
    }
}