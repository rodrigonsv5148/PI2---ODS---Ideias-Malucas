using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomPapel : MonoBehaviour
{
    public float nivelAmpliacao = 2.0f;
    public Vector3 localZoom = new Vector3 (0, 0, 0);

    private Vector3 originalLocation;
    private Vector3 originalScale;
    private bool isZoom = false;

    // Start is called before the first frame update
    void Start()
    {
     
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

        isZoom = true;
    }

    private void zoomOut() 
    {
        transform.position = originalLocation;

        transform.localScale = originalScale;

        isZoom=false;
    }
}
