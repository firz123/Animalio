using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Droppable : MonoBehaviour, IDropHandler
{
    public GameObject item
    {
        get
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }

        set { }

    }

    #region IDropHandler Members

    public void OnDrop(PointerEventData eventData)
    {
        if (!item)
        {
            Draggable.itemBeingDragged.transform.SetParent(transform);
        }

    }

    #endregion
}


