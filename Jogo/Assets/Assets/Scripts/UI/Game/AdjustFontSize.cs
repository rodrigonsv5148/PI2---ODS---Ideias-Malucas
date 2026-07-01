using UnityEngine;
using TMPro;

public class AdjustFontSize : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI thisText;

    void OnEnable()
    {
        TextSizeEngine.instance.AddTmpro(thisText);
        TextSizeEngine.instance.AdjustTextSize();
    }
}
