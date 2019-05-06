using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlyphDragger : MonoBehaviour
{
    Glyph glyph;
    Vector2 mouseOffset;
    private bool dragging;
    // Start is called before the first frame update
    void Awake()
    {
        glyph = transform.parent.GetComponent<Glyph>();
    }

    private void OnMouseDown()
    {
        dragging = true;
        //mouseOffset = new Vector2(Input.mousePosition.x - glyph.transform.position.x, Input.mousePosition.y-glyph.transform.position.y);
    }
    private void OnMouseUp()
    {
        dragging = false;
        mouseOffset = Vector2.zero;
    }
    public void Update()
    {
        if (dragging)
        {
            glyph.transform.position = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y))+ new Vector3(-transform.localPosition.x,-transform.localPosition.y,10f);// + offset - mouseOffset;
        }
    }
}
