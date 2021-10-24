using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using TMPro;

public class GenerateDialogue : MonoBehaviour
{
    public GameManager gameManager;

    public AudioSource messageReceivedSound;
    public AudioSource typingSound;
    public AudioSource messageSentSound;

    public DialogueRunner dialogueRunner;
    public DialogueUI dialogueUI;

    public AutoScroll autoScroll;

    public bool isSelf = false;

    public TextMeshProUGUI currentText;

    public GameObject selfDialogue;
    public GameObject fDialogue;

    public GameObject selfWaitDialogue;
    public GameObject fWaitDialogue;
    public GameObject timer;

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

    [YarnCommand("AddTimer")]
    public void AddTimer()
    {
        GameObject newTimer = Instantiate(timer, new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform);

        switch (gameManager.currentScene)
        {
            case 1:
                newTimer.GetComponent<TextMeshProUGUI>().text = "10/24";
                break;

            case 2:
                newTimer.GetComponent<TextMeshProUGUI>().text = "11/3";
                break;

            case 3:
                newTimer.GetComponent<TextMeshProUGUI>().text = "11/20";
                break;

            case 4:
                newTimer.GetComponent<TextMeshProUGUI>().text = "1/3";
                break;

            case 5:
                newTimer.GetComponent<TextMeshProUGUI>().text = "4/12";
                break;
        }
    }

    private void SetWaitTime(string[] parameters, System.Action onComplete)
    {
        waitTime = float.Parse(parameters[0]);

        StartCoroutine(DoWait(onComplete, waitTime));
    }

    private IEnumerator DoWait(System.Action onComplete, float time)
    {
        GameObject waitingDialogue = CreateFWaitingDialogue();

        yield return new WaitForSeconds(0.05f);

        autoScroll.ScrollToBottom();

        yield return new WaitForSeconds(time - 0.55f);

        Destroy(waitingDialogue);

        CreateFDialogue();

        yield return new WaitForSeconds(0.05f);

        autoScroll.ScrollToBottom();

        yield return new WaitForSeconds(0.45f);

        onComplete();
    }

    public void SelfWaitingStart()
    {
        if (isSelf)
        {
            currentSelfWaitDialogue = CreateSelfWaitingDialogue();

            autoScroll.ScrollToBottom();

            answerText.SetActive(true);

            typingSound.Play();
        }
    }

    public void SelfWaitingEnd()
    {
        if (isSelf)
        {
            Destroy(currentSelfWaitDialogue);

            CreateSelfDialogue();

            autoScroll.ScrollToBottom();

            answerText.SetActive(false);

            typingSound.Stop();
        }
    }


    [YarnCommand("switchIdentity")]
    public void switchIdentity(string identity)
    {
        if (identity == "self")
        {
            isSelf = true;
            dialogueUI.textSpeed = 0.08f;
            answerText.SetActive(true);
        }
        else
        {
            isSelf = false;
            dialogueUI.textSpeed = 0f;
            answerText.SetActive(false);
        }
    }

    void CreateFDialogue()
    {
        if (isSelf) return;

        GameObject newDialogue = Instantiate(fDialogue, new Vector3(0,0,0), Quaternion.identity, gameObject.transform);
        newDialogue.GetComponent<InitiateDialogueContent>().InitiateText(currentText.text);

        Debug.Log("F Dialogue Created!");

        messageReceivedSound.Play();
    }

    public void CreateSelfDialogue()
    {
        if (!isSelf) return;

        GameObject newDialogue = Instantiate(selfDialogue, new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform);
        newDialogue.GetComponent<InitiateDialogueContent>().InitiateText(currentText.text);

        Debug.Log("Self Dialogue Created!");

        messageSentSound.Play();
    }

    GameObject CreateSelfWaitingDialogue()
    {
        if (!isSelf) return null;

        GameObject newDialogue = Instantiate(selfWaitDialogue, new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform);

        Debug.Log("Self Dialogue Waiting Created!");

        autoScroll.ScrollToBottom();

        return newDialogue;
    }

    GameObject CreateFWaitingDialogue()
    {
        if (isSelf) return null;

        GameObject newDialogue = Instantiate(fWaitDialogue, new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform);

        Debug.Log("f Dialogue Waiting Created!");

        autoScroll.ScrollToBottom();

        return newDialogue;
    }
}
