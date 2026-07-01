using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickScrollViewEvent : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent OnScrollClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnScrollClick.Invoke();
    }
}
