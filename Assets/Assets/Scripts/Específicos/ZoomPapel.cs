using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using TMPro;

public class ZoomPapel : MonoBehaviour
{
    public float nivelAmpliacao = 2.0f;
    public Vector3 localZoom = new Vector3 (0, 0, 0);

    private Vector3 originalLocation;
    private Vector3 originalScale;
    private bool isZoom = false;

    private GameObject papel;
    private GameObject texto;
    private TMP_Text text;
    private SpriteRenderer ajustadorDeLayer;

    // Start is called before the first frame update
    void Start()
    {
        papel = transform.Find("Square").gameObject;
        texto = transform.Find("Text (TMP)").gameObject;
        
        text = texto.GetComponent<TMP_Text>();
        ajustadorDeLayer = papel.GetComponent<SpriteRenderer>();
        
        originalLocation = transform.position;
        originalScale = transform.localScale;

    }

    private void OnMouseDown()
    {
        if (!isZoom)
        {
            zoom();
        }
        else zoomOut();
    }

    private void zoom() 
    {
        transform.position = originalLocation + localZoom;

        transform.localScale = originalScale * nivelAmpliacao;

        ajustadorDeLayer.sortingOrder = 10;
        text.GetComponent<Renderer>().sortingOrder = 10;

        isZoom = true;
    }

    private void zoomOut() 
    {
        transform.position = originalLocation;

        transform.localScale = originalScale;

        ajustadorDeLayer.sortingOrder = 8;
        text.GetComponent<Renderer>().sortingOrder = 8;

        isZoom =false;
    }
}
