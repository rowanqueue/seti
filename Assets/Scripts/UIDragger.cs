using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIDragger : EventTrigger
{
    Transform mover;
    Vector2 offset;
    Vector2 mouseOffset;
    private bool dragging;
    private void Awake()
    {
        mover = transform.parent.parent;
        offset = new Vector2(0,mover.position.y-transform.position.y);
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        dragging = true;
        mouseOffset = new Vector2(Input.mousePosition.x - mover.position.x, 0);
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
        mouseOffset = Vector2.zero;
    }
    public void Update()
    {
        if (dragging)
        {
            mover.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y)+offset-mouseOffset;
        }
    }
}
