using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoScroll : MonoBehaviour
{
    public Scrollbar scrollbar;

    public void ScrollToBottom()
    {
        scrollbar.value = 0f;
    }    

}
