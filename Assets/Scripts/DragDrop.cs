using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Canvas parentCanvas;
    Vector3 Offset = Vector3.zero;
    public Transform parentToReturnTo = null;

    void Awake()
    {
        GameObject CanvasObject = GameObject.Find("Canvas");
        parentCanvas = CanvasObject.GetComponent<Canvas>();
    }
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform as RectTransform, eventData.position, parentCanvas.worldCamera, out pos);
        Offset = transform.position - parentCanvas.transform.TransformPoint(pos);
        parentToReturnTo = this.transform.parent;
        //this.transform.SetParent( this.transform.parent.parent); <- this moves the object WHILST dragging
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector2 movePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform as RectTransform, eventData.position, parentCanvas.worldCamera, out movePos);
        transform.position = parentCanvas.transform.TransformPoint(movePos) + Offset;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(parentToReturnTo);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
