using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using TMPro;

public class GenerateDialogue : MonoBehaviour
{
    public DialogueRunner dialogueRunner;

    public bool isSelf = false;

    public TextMeshProUGUI currentText;

    public GameObject selfDialogue;
    public GameObject fDialogue;

    public GameObject selfWaitDialogue;
    public GameObject fWaitDialogue;

    public GameObject currentSelfWaitDialogue;

    public GameObject answerText;

    public float waitTime = 0f;

    public void Awake()
    {
        dialogueRunner.AddCommandHandler(
            "SetWaitTime",     // the name of the command
            SetWaitTime // the method to run
        );
    }

    private void SetWaitTime(string[] parameters, System.Action onComplete)
    {
        waitTime = float.Parse(parameters[0]);

        StartCoroutine(DoWait(onComplete, waitTime));
    }

    private IEnumerator DoWait(System.Action onComplete, float time)
    {
        answerText.SetActive(false);

        GameObject waitingDialogue = CreateFWaitingDialogue();

        yield return new WaitForSeconds(time - 0.5f);

        Destroy(waitingDialogue);

        CreateDialogue();

        yield return new WaitForSeconds(0.5f);

        onComplete();
    }

    [YarnCommand("switchIdentity")]
    public void switchIdentity(string identity)
    {
        if (identity == "self")
        {
            isSelf = true;
        }
        else
        {
            isSelf = false;
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
        if (isSelf)
        {
            return null;
        }

        GameObject newDialogue = Instantiate(fWaitDialogue, new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform);

        Debug.Log("f Dialogue Waiting Created!");

        return newDialogue;
    }
}
