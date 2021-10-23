using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitScroll : MonoBehaviour
{
    private void OnEnable()
    {
        gameObject.GetComponent<Scrollbar>().value = 0f;
    }
}
