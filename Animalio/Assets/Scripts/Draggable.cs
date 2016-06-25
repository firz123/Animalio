using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemBeingDragged;
    Vector3 startposition;
    Transform startparent;


    #region IBeginDragHandler Members

    public void OnBeginDrag(PointerEventData eventData)
    {
        startparent = transform.parent;
        startposition = transform.position;
        itemBeingDragged = gameObject;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    #endregion


    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    #region IEndDragHandler Members

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged = null;
        transform.position = startposition;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    #endregion
}

