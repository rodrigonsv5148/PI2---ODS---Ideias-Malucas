using UnityEngine;
using TMPro;

public class TextoPapel : MonoBehaviour
{
    public TextMeshProUGUI paper;
    public int indice;
    public Ideias ideiasPersonagem;
    public int investimento;
    public int sustentabilidade;

    void Start()
    {
        TextSizeEngine.instance.AddTmpro(paper);
        TextSizeEngine.instance.AdjustTextSize();

        ideiasPersonagem = IdeiasControle.Informacoes(indice);

        paper.text = ideiasPersonagem.ideia + "\n\n$$" + ideiasPersonagem.valorInvestimento;

        investimento = ideiasPersonagem.valorInvestimento;
        sustentabilidade = ideiasPersonagem.valorSustentabilidade;
    }

    public void atualizarIndice (int novoInidice) 
    {
        indice = novoInidice;
    }
}
