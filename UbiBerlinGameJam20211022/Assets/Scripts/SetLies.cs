using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class SetLies : MonoBehaviour
{
    public GameObject option1LieText;
    public GameObject option2LieText;

    public DialogueRunner dialogueRunner;

    public void Awake()
    {
        dialogueRunner.AddCommandHandler(
            "SetLie1",     // the name of the command
            SetLie1 // the method to run
        );

        dialogueRunner.AddCommandHandler(
            "SetLie2",     // the name of the command
             SetLie2 // the method to run
        );
    }

    private void SetLie1(string[] parameters)
    {
        bool isLie;

        if (parameters[0] == "true")
        {
            isLie = true;
        }
        else
        {
            isLie = false;
        }

        option1LieText.SetActive(isLie);

        Debug.Log("Lie 1 Set!");
    }

    private void SetLie2(string[] parameters)
    {
        bool isLie;

        if (parameters[0] == "true")
        {
            isLie = true;
        }
        else
        {
            isLie = false;
        }

        option2LieText.SetActive(isLie);

        Debug.Log("Lie 2 Set!");
    }
}
