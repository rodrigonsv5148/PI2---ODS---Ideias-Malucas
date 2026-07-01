using UnityEngine;
using UnityEngine.UI;

public class VerticalAlignText : MonoBehaviour
{
    [SerializeField] RectTransform textHeight;
    [SerializeField] RectTransform contentBoxHeight; 
    [SerializeField] float offset;
    float height;

    void Start()
    {
        Invoke("FormatAndAlign", 0.01f);

        SettingsManager.OnSettingsSaved += RebuildTextBox;
    }

    private void OnDestroy()
    {
        SettingsManager.OnSettingsSaved -= RebuildTextBox;
    }

    public void FormatAndAlign() 
    {
        height = textHeight.rect.height;

        height = height + (2 * offset);

        contentBoxHeight.sizeDelta = new Vector2(contentBoxHeight.sizeDelta.x, height);

        contentBoxHeight.anchoredPosition = new Vector2 (contentBoxHeight.anchoredPosition.x, 0.0f);

        Debug.Log("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeiiiiiiiiiiiiiii");
    }

    public void RebuildTextBox() 
    {
        FormatAndAlign();

        LayoutRebuilder.ForceRebuildLayoutImmediate(contentBoxHeight);

    }
}
