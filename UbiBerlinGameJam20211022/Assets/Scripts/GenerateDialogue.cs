using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using TMPro;

public class GenerateDialogue : MonoBehaviour
{
    public bool isSelf = false;

    public TextMeshProUGUI currentText;

    public GameObject selfDialogue;
    public GameObject fDialogue;

    [YarnCommand("switchIdentity")]
    public void switchIdentity(string identity)
    {
        Debug.Log("Switch identity to: ");

        if (identity == "self")
        {
            isSelf = true;
            Debug.Log("Self!");
        }
        else
        {
            isSelf = false;
            Debug.Log("f!");
        }
    }

    public void CreateDialogue()
    {
        if (isSelf)
        {
            CreateSelfDialogue();
        }
        else
        {
            CreateFDialogue();
        }
    }

    void CreateFDialogue()
    {
        GameObject newDialogue = Instantiate(fDialogue, new Vector3(0,0,0), Quaternion.identity, gameObject.transform);
        newDialogue.GetComponent<InitiateDialogueContent>().InitiateText(currentText.text);

        Debug.Log("F Dialogue Created!");
    }

    void CreateSelfDialogue()
    {
        GameObject newDialogue = Instantiate(selfDialogue, new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform);
        newDialogue.GetComponent<InitiateDialogueContent>().InitiateText(currentText.text);

        Debug.Log("Self Dialogue Created!");
    }
}
