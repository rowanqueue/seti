using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shortcut : MonoBehaviour
{
    public Window window;
    // Start is called before the first frame update
    public void OpenMyWindow()
    {
        window.OpenWindow();
    }
}
