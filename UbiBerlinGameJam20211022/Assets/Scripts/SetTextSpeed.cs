using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class SetTextSpeed : MonoBehaviour
{
    public DialogueUI dialogueUI;

    public void AddTextSpeed()
    {
        dialogueUI.textSpeed = 0.08f;
    }

    public void RemoveTextSpeed()
    {
        dialogueUI.textSpeed = 0f;
    }

}
