using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InitiateDialogueContent : MonoBehaviour
{
    public TextMeshProUGUI textContainer;

    public void InitiateText(string content)
    {
        textContainer.text = content;
    }
}
