using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ImagensTutorial : MonoBehaviour
{
    [SerializeField] List<GameObject> imagens;
    private int counti = 0;
    [SerializeField] string cena;

    // Start is called before the first frame update
    void Start()
    {
        mostrarImagem();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) 
        {
            SceneManager.LoadScene(cena);
        }
    }

    protected void OnMouseDown()
    {
        mostrarImagem();
    }

    private void mostrarImagem()
    {
        if (imagens.Count != 0)
        {
            if (counti < imagens.Count)
            {
                if (counti > 0)
                {
                    imagens[counti - 1].SetActive(false);
                }
                imagens[counti].SetActive(true);
                counti++;                
            }
            else 
            {
                SceneManager.LoadScene(cena);
            }
        }
    }
}
