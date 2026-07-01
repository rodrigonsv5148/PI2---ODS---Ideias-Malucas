using System.Collections;
using UnityEngine;

public class InteractionMode : MonoBehaviour
{
    Animator animator;
    bool hasAnimator;

    [SerializeField] GameObject objectStroke;
    [SerializeField] SettingsSO settings;
    [SerializeField] float timeToEndStroke = 0.5f;
    [SerializeField] string specialAnimationName;
    private ObjetosClicaveis objetosClicaveis;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        if (animator != null)
        { 
            hasAnimator = true;
        }

        objetosClicaveis = GetComponent<ObjetosClicaveis>();
    }

    private void OnMouseEnter()
    {
        if (ValidateInteractionMode() == false) return;

        StartCoroutine(turnOnObjectStroke());

    }

    private bool ValidateInteractionMode()
    {
        if (settings.InteractionMode == false) return false;

        if (hasAnimator && animator.GetCurrentAnimatorStateInfo(0).IsName(specialAnimationName)) return false;

        return true;
    }

    IEnumerator turnOnObjectStroke() 
    {
        if (objetosClicaveis != null) 
        {
            if (objetosClicaveis.DraggingState() == false) 
            {
                objectStroke.SetActive(true);

                yield return new WaitForSeconds(timeToEndStroke);

                objectStroke.SetActive(false);
            }
        }
        else 
        {
            objectStroke.SetActive(true);

            yield return new WaitForSeconds(timeToEndStroke);

            objectStroke.SetActive(false);
        }
    }
}
