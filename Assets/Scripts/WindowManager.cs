using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    public static WindowManager me;
    public List<Window> windows;
    public List<Bar> bars;
    public Transform toolBar;

    public GameObject barObject;
    // Start is called before the first frame update
    void Awake()
    {
        me = this;
        bars = new List<Bar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddWindow(Window window)
    {
        if(windows.Contains(window) == false)
        {
            windows.Add(window);
            GameObject barObj = Instantiate(barObject, toolBar);
            Bar bar = barObj.GetComponent<Bar>();
            bar.rect.anchoredPosition = new Vector2(85+(100*bars.Count), 0);
            bar.window = window;
            bars.Add(bar);
        }
    }
    public void RemoveWindow(Window window)
    {
        if (windows.Contains(window))
        {
            windows.Remove(window);
            Bar removeBar = null;
            foreach(Bar bar in bars)
            {
                if(bar.window == window)
                {
                    removeBar = bar;
                    break;
                }
            }
            if(removeBar != null)
            {
                bars.Remove(removeBar);
                Destroy(removeBar.gameObject);
            }
        }
    }
}
