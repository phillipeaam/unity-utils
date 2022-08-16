using UnityEngine;

public class ToggleableScreen : MonoBehaviour
{
    [SerializeField] protected CanvasGroup _canvasGroup;

    protected void ToggleCanvasGroup(bool isVisible)
    {
        _canvasGroup.alpha = isVisible ? 1 : 0;
        _canvasGroup.interactable = isVisible;
        _canvasGroup.blocksRaycasts = isVisible;
    }
}