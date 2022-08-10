using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoldClickableButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float _holdDuration;

    public event Action OnClicked;
    public event Action OnHoldClicked;

    private bool _isHoldingButton;
    private float _elapsedTime;

    public void OnPointerDown(PointerEventData eventData) => ToggleHoldingButton(true);

    private void ToggleHoldingButton(bool isPointerDown)
    {
        _isHoldingButton = isPointerDown;

        if (isPointerDown)
            _elapsedTime = 0;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ManageButtonInteraction(true);
        ToggleHoldingButton(false);
    }

    private void ManageButtonInteraction(bool isPointerUp = false)
    {
        if (!_isHoldingButton)
            return;

        if (isPointerUp)
        {
            Click();
            return;
        }

        _elapsedTime += Time.deltaTime;
        var isHoldClickDurationReached = _elapsedTime > _holdDuration;

        if (isHoldClickDurationReached)
            HoldClick();
    }

    private void Click()
    {
        OnClicked?.Invoke();
    }

    private void HoldClick()
    {
        ToggleHoldingButton(false);
        OnHoldClicked?.Invoke();
    }

    private void Update() => ManageButtonInteraction();
}