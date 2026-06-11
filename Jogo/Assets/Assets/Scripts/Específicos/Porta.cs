using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
//using static UnityEditor.Progress;
using UnityEngine.Audio;
//using UnityEngine.Windows;


public class Porta : MonoBehaviour
{
    private bool interativo = true;
    

    //Variáveis relativas à parte de audio 

    public List<ScriptableSons> scriptableAudio;
    private AudioSource audioSource;
    private ScriptableSons scriptableAudioProximo;
    private ScriptableSons scriptableAudioPassos;
    private ScriptableSons scriptableAudioPorta;
    private int qteAudiosProximo;
    private int qteAudiosPassos;
    private int qteAudiosPorta;
    private float tempoAudio;

    //----------------------------------------------


    // Relacionados aos personagens

    public ScriptablePersonagens listaPersonagens;
    [SerializeField] private Transform personagemLocationBase;
    private int qtePersonagens;
    private int charactereAtualNumber;
    List<int> personagensUsados = new List<int>();
    private GameObject [] npcs = new GameObject[2];
    private bool spawn = true;
    [SerializeField] private GameObject cadeira;
    private Cadeiras cadeiraSecundaria;

    //----------------------------------------------


    // Relacionados ao papel

    [SerializeField] private GameObject papel;
    [SerializeField] private Transform papelLocationBase;
    public GameObject[] papelInGame = new GameObject[2];
    private TextoPapel scriptPapel;

    //----------------------------------------------


    // Relacionados a cadeira

    public GameObject cadeiraPrincipal;
    private Cadeiras script;

    //----------------------------------------------

    // Informacoes Personagens
    [SerializeField] private GameObject informacoes;
    [SerializeField] private Transform infosLocationBase;
    public GameObject[] informacoesInGame = new GameObject[2];
    private InformacoesPersonagens scriptInfos;
    //----------------------------------------------

        // Inicialização
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

        script = cadeiraPrincipal.GetComponent<Cadeiras>();

    }



    //Abrir a porta
    public void OnMouseDown()
    {
        if (interativo == true && script.qteNPC == 0 && spawn == true)
        {
            // Botar essa variável p false enquanto não tiver NPC na cadeira (Sendo assim, é melhor essa variável estar no script geral da cena) ai vai ser interativo. Nome do script
            interativo = false; // Variável de controle para não ativar o mesmo evento simultâneamente 
            
            StartCoroutine(temposTurno());

            Debug.Log("Aquiiiiiii" + tempoAudio);
        }
    }


    // Função que serve de tempo de espera entre ações
    IEnumerator tempoDeEspera(float tempoCoroutine) 
    {
        yield return new WaitForSeconds(tempoCoroutine);
    }



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

        //Aqui que entra a animação da porta (preciso da animação p fazer isso, acho q placeholder n ficaria legal)

        // Toca o áudio dos passos
        yield return StartCoroutine(playAudio(qteAudiosPassos, scriptableAudioPassos));

        // Spawn do NPC após a conclusão dos áudios
        spawnNPC();

        Debug.Log("Todos os áudios foram reproduzidos.");

        interativo = true;
    }



    private void spawnNPC() 
    {    
        if (spawn) 
        {
            charactereAtualNumber = Random.Range(0, qtePersonagens);

            while (personagensUsados.Contains(charactereAtualNumber))
            {
                charactereAtualNumber = Random.Range(0, qtePersonagens);
            }
            personagensUsados.Add(charactereAtualNumber);

            // tenho a lista atualizada e o valor do personagem que vou pegar na lista de assets

            if (personagensUsados.Count == qtePersonagens) spawn = false;

            cadeiraSecundaria = cadeira.GetComponent<Cadeiras>();
            
            if (cadeiraSecundaria.qteNPC == 0 ) 
            {
                npcs[0] = Instantiate(listaPersonagens.Characteres[charactereAtualNumber], personagemLocationBase.position, Quaternion.identity);
                papelInGame[0] = Instantiate(papel, papelLocationBase.position, Quaternion.identity);
                informacoesInGame[0] = Instantiate(informacoes, infosLocationBase.position, Quaternion.identity);

                scriptPapel = papelInGame[0].GetComponent<TextoPapel>(); // pego o código do papel
                scriptInfos = informacoesInGame[0].GetComponent<InformacoesPersonagens>();

                // Nomeando os assets
                npcs[0].name = "NPC " + charactereAtualNumber.ToString();
                papelInGame[0].name = "Papel " + charactereAtualNumber.ToString();
                informacoesInGame[0].name = "infoNPC " + charactereAtualNumber.ToString();
                
            }
            else 
            {
                npcs[1] = Instantiate(listaPersonagens.Characteres[charactereAtualNumber], personagemLocationBase.position, Quaternion.identity);
                papelInGame[1] = Instantiate(papel, papelLocationBase.position, Quaternion.identity);
                informacoesInGame[1] = Instantiate(informacoes, infosLocationBase.position, Quaternion.identity);

                scriptPapel = papelInGame[1].GetComponent<TextoPapel>(); // pego o código do papel
                scriptInfos = informacoesInGame[1].GetComponent<InformacoesPersonagens>();

                // Nomeando os assets
                npcs[1].name = "NPC " + charactereAtualNumber.ToString();
                papelInGame[1].name = "Papel " + charactereAtualNumber.ToString();
                informacoesInGame[1].name = "infoNPC " + charactereAtualNumber.ToString();
            }

            scriptPapel.atualizarIndice(charactereAtualNumber);// Se der algum erro com a exibição do texto é provável que tenha haver com essa linha.
            scriptInfos.novoIndice(charactereAtualNumber);
        }
    }   
}