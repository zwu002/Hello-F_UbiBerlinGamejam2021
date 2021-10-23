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

    public GameObject selfWaitDialogue;
    public GameObject fWaitDialogue;

    public GameObject currentSelfWaitDialogue;

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
            StartCoroutine(CreateFDialogue());
        }
    }

    IEnumerator CreateFDialogue()
    {
        GameObject waitingDialogue = CreateFWaitingDialogue();

        yield return new WaitForSeconds(1.0f);

        Destroy(waitingDialogue);

        GameObject newDialogue = Instantiate(fDialogue, new Vector3(0,0,0), Quaternion.identity, gameObject.transform);
        newDialogue.GetComponent<InitiateDialogueContent>().InitiateText(currentText.text);

        Debug.Log("F Dialogue Created!");
    }

    public void CreateSelfDialogue()
    {
        GameObject newDialogue = Instantiate(selfDialogue, new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform);
        newDialogue.GetComponent<InitiateDialogueContent>().InitiateText(currentText.text);

        Debug.Log("Self Dialogue Created!");
    }

    public void CreateSelfWaitingDialogue()
    {
        currentSelfWaitDialogue = Instantiate(selfWaitDialogue, new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform);

        Debug.Log("Self Dialogue Waiting Created!");
    }

    public void DestroySelfWaitingDialogue()
    {
        Destroy(currentSelfWaitDialogue);
    }

    GameObject CreateFWaitingDialogue()
    {
        GameObject newDialogue = Instantiate(fWaitDialogue, new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform);

        Debug.Log("f Dialogue Waiting Created!");

        return newDialogue;
    }
}
