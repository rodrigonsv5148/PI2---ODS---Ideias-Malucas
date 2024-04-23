using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.Audio;


public class Porta : MonoBehaviour
{
    private bool interativo = true;
    
    //Variáveis relativas à parte de audio 
    [SerializeField] private List<ScriptableSons> scriptableAudio;
    private AudioSource audioSource;
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
    [SerializeField] private Transform personagemLocationBase;
    private int qtePersonagens;
    private int charactereAtualNumber;
    List<int> personagensUsados = new List<int>();
    private GameObject[] personagensInGame = new GameObject[2];
    private GameObject[] papelInGame = new GameObject[2];
    private GameObject npc;

    //----------------------------------------------

    // Relacionados ao papel
    [SerializeField] private GameObject papel;
    [SerializeField] private Transform papelLocationBase;
    
    //---------------------------------------------------

    private void Start()
    {
        // Algoritmo para pegar a quantidade de audios do scriptable object
        scriptableAudioProximo = scriptableAudio[0];
        scriptableAudioPassos = scriptableAudio[1];
        scriptableAudioPorta = scriptableAudio[2];
        qteAudiosProximo = scriptableAudioProximo.audios.Count;
        qteAudiosPassos = scriptableAudioPassos.audios.Count;
        qteAudiosPorta = scriptableAudioPorta.audios.Count;

        qtePersonagens = listaPersonagens.Characteres.Count;

        audioSource = GetComponent<AudioSource>();
    }

    //Abrir a porta
    public void OnMouseDown()
    {
        if (interativo == true && Cadeiras.NPCaqui == false)
        {
            // Botar essa variável p false enquanto não tiver NPC na cadeira (Sendo assim, é melhor essa variável estar no script geral da cena) ai vai ser interativo. Nome do script
            interativo = false; // Variável de controle para não ativar o mesmo evento simultâneamente 
            
            StartCoroutine(temposTurno());

            Debug.Log("Aquiiiiiii " + tempoAudio);
        }
    }

    // Função que serve de tempo de espera entre ações
    /*IEnumerator tempoDeEspera(float tempoCoroutine) 
    {
        yield return new WaitForSeconds(tempoCoroutine);
    }*/

    // Função que seleciona um audio aleatório do scriptable object, da play e retorna a duração desse audio
    private IEnumerator playAudio(int qteAudios,ScriptableSons scriptable) 
    {
        int numeroAudio = Random.Range(0, qteAudios);
        
        audioSource.clip = scriptable.audios[numeroAudio]; // seta o clip no audio source        
        
        audioSource.Play();
        yield return new WaitForSeconds(scriptable.audios[numeroAudio].length);
    }

    private IEnumerator temposTurno() 
    {
        // Toca o áudio do próximo
        yield return StartCoroutine(playAudio(qteAudiosProximo, scriptableAudioProximo));

        // Toca o áudio da porta
        yield return StartCoroutine(playAudio(qteAudiosPorta, scriptableAudioPorta));

        //Aqui que entra a animação (preciso da animação p fazer isso, acho q placeholder n ficaria legal)

        // Toca o áudio dos passos
        yield return StartCoroutine(playAudio(qteAudiosPassos, scriptableAudioPassos));

        // Spawn do NPC após a conclusão dos áudios
        spawnNPC();

        Debug.Log("Todos os áudios foram reproduzidos.");

        interativo = true;
    }

    private void spawnNPC() 
    {
        charactereAtualNumber = Random.Range(0, qtePersonagens);
        while (personagensUsados.Contains(charactereAtualNumber))
        {
            charactereAtualNumber = Random.Range(0, qtePersonagens);
        }
        personagensUsados.Add(charactereAtualNumber);
        // tenho a lista atualizada e o valor do personagem que vou pegar na lista de assets

        npc = Instantiate(listaPersonagens.Characteres[charactereAtualNumber], personagemLocationBase.position, Quaternion.identity);

        Instantiate(papel, papelLocationBase.position, Quaternion.identity);
    }   
}