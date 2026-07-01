using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImagensTutorial : MonoBehaviour
{
    [SerializeField] List<Sprite> imagens;
    [SerializeField] Image actualImage; 
    private int counti;

    void Start()
    {
        counti = 0;
        mostrarImagem();
    }

    public void mostrarImagem()
    {
        if (imagens.Count == 0)
            return;

        if (counti < imagens.Count)
        {
            actualImage.sprite = imagens[counti];
            counti++;
        }
        else
        {
            SceneManager.UnloadSceneAsync(gameObject.scene);
        }
    }
}
