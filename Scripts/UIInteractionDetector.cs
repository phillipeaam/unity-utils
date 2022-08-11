using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInteractionDetector : MonoBehaviour
{
    [SerializeField] private EventSystem _eventSystem;

    private PointerEventData _pointerEventData;
    private List<RaycastResult> _results;

    private void Start() => InitVariables();

    private void InitVariables()
    {
        _results = new List<RaycastResult>();
        _pointerEventData = new PointerEventData(_eventSystem);
    }

    public bool IsPointerOverUI()
    {
        _results.Clear();
        _pointerEventData.position = Input.mousePosition;
        _eventSystem.RaycastAll(_pointerEventData, _results);

        return _results.Count > 0;
    }
}