using TMPro;
using UnityEngine;

[RequireComponent(typeof(VerticalAlignText))]
public class ZoomPapel : MonoBehaviour
{
    public float paperZoomLevel = 2.0f;
    [SerializeField] float horizontalRectZoomLevel = 0.813f;
    [SerializeField] float topRectZoomLevel = 0.654f;
    public Vector3 adjustPositionToZoom = new Vector3 (0, 0, 0);

    private Vector3 originalLocation;
    private Vector3 originalScale;
    private bool isZoom = false;

    [SerializeField] private SpriteRenderer paperModel;
    [SerializeField] private TMP_Text textBox;
    [SerializeField] private RectTransform scrollViewRect;
    private Vector2 originalScrollViewRectOffsetMin = new Vector2();
    private Vector2 originalScrollViewRectOffsetMax = new Vector2();
    private VerticalAlignText verticalAlignText;
    private Vector2 originalTextSize;

    private void Awake()
    {
        verticalAlignText = GetComponent<VerticalAlignText>();
    }

    void Start()
    {
        originalLocation = transform.position;
        originalScale = transform.localScale;

        originalScrollViewRectOffsetMin = scrollViewRect.offsetMin;
        originalScrollViewRectOffsetMax = scrollViewRect.offsetMax;

        originalTextSize = textBox.rectTransform.sizeDelta;
    }

    public void ApplyZoom() 
    {
        if (!isZoom)
        {
            zoom();
        }
        else zoomOut();
    }

    private void zoom() 
    {
        transform.position = originalLocation + adjustPositionToZoom;

        transform.localScale = originalScale * paperZoomLevel;

        textBox.rectTransform.anchoredPosition = new Vector2(0.0f, 0.0f);

        AdjustZoomScroolView();

        paperModel.sortingOrder = 75;

        isZoom = true;
    }

    private void zoomOut() 
    {
        transform.position = originalLocation;

        transform.localScale = originalScale;

        scrollViewRect.offsetMin = originalScrollViewRectOffsetMin;
        scrollViewRect.offsetMax = originalScrollViewRectOffsetMax;

        textBox.rectTransform.sizeDelta = originalTextSize;

        Canvas.ForceUpdateCanvases();

        verticalAlignText.RebuildTextBox();

        paperModel.sortingOrder = 7;

        isZoom = false;
    }

    private void AdjustZoomScroolView()
    {
        Vector2 offsetMin = scrollViewRect.offsetMin;
        Vector2 offsetMax = scrollViewRect.offsetMax;

        offsetMin.x *= horizontalRectZoomLevel;
        offsetMin.y = 0f;

        offsetMax.x *= horizontalRectZoomLevel;
        offsetMax.y *= topRectZoomLevel;

        scrollViewRect.offsetMin = offsetMin;
        scrollViewRect.offsetMax = offsetMax;

        textBox.rectTransform.sizeDelta =  new Vector2(-scrollViewRect.offsetMax.x, textBox.rectTransform.sizeDelta.y);

        Canvas.ForceUpdateCanvases();

        verticalAlignText.RebuildTextBox();
    }
}
