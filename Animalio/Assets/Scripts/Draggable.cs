using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Draggable : MonoBehaviour, IDragHandler {

    public void OnDrag( PointerEventData eventData ) { 
    transform.position = Input.mousePosition; 
    }
}
