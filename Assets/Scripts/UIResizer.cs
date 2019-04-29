using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIResizer : EventTrigger
{
    int whichSide;
    Window window;
    RectTransform display;
    Vector2 offset;
    Vector2 mouseOffset;
    Vector2 lastMousePos;
    RectTransform self;
    private bool dragging;
    private void Awake()
    {
        self = transform.GetComponent<RectTransform>();
        window = transform.parent.parent.parent.GetComponent<Window>();
        if(gameObject.name == "Left")
        {
            whichSide = 0;
        }
        if(gameObject.name == "Right")
        {
            whichSide = 1;
        }
        if(gameObject.name == "Bottom")
        {
            whichSide = 3;
        }
        //offset = new Vector2(0, mover.position.y - transform.position.y);
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        dragging = true;
        lastMousePos = Input.mousePosition;
        //mouseOffset = new Vector2(Input.mousePosition.x - mover.position.x, 0);
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
        //mouseOffset = Vector2.zero;
    }
    public void Update()
    {
        if (whichSide == 0)
        {
            self.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, window.displaySize.y - 15);
        }
        if (whichSide == 1)
        {
            self.anchoredPosition = new Vector2(window.displaySize.x - 5, self.anchoredPosition.y);
            self.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, window.displaySize.y - 15);
        }
        if(whichSide == 3)
        {
            self.anchoredPosition = new Vector2(self.anchoredPosition.x, -5);
            self.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, window.displaySize.x);
        }
        if (dragging)
        {
            //mover.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y) + offset - mouseOffset;
            Vector2 mousePos = Input.mousePosition;
            float diff = 0;
            if (whichSide == 0 || whichSide == 1)
            {
                diff = mousePos.x - lastMousePos.x;
            }
            else
            {
                diff = mousePos.y - lastMousePos.y;
            }
            diff *= 0.5f;
            if (diff != 0)
            {
                if (whichSide == 0 && window.displaySize.x - diff > 100)//grabbing left side
                {
                    window.rect.anchoredPosition = new Vector2(window.rect.anchoredPosition.x+ diff, window.rect.anchoredPosition.y);
                    window.displaySize.x -= diff;
                    window.UpdateSizes();
                    lastMousePos = mousePos;
                }
                if (whichSide == 1 && window.displaySize.x + diff >= 100)//grabbing right side
                {
                    window.displaySize.x += diff;
                    window.UpdateSizes();
                    lastMousePos = mousePos;
                }
                if (whichSide == 3 && window.displaySize.y - diff >= 100)
                {
                    window.displaySize.y -= diff;
                    window.UpdateSizes();
                    lastMousePos = mousePos;
                }
                if (whichSide == 2 && window.displaySize.y - diff >= 100)//grabbing top
                {
                    window.rect.anchoredPosition = new Vector2(window.rect.anchoredPosition.y, mousePos.y);
                    window.displaySize.y -= diff;
                    window.UpdateSizes();
                    lastMousePos = mousePos;
                }
            }
        }
    }
}
