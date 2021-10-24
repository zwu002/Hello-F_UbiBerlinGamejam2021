using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class GameManager : MonoBehaviour
{
    static GameManager instance = null;

    public DialogueRunner dialogueRunner;

    public int currentScene = 1;

    public bool isGameOver = false;
    public bool isPaused = false;

    public Animator anim;
    void Awake()
    {
        currentScene = 1;

        StartCoroutine(StartScene());
    }

    public IEnumerator StartScene()
    {
        anim.Play("StartScene");

        Debug.Log("Start scene");

        yield return new WaitForSeconds(3f);

        StartDialogue();
    }

    public void StartDialogue()
    {
        dialogueRunner.StartDialogue("Scene" + currentScene.ToString());

        currentScene++;

        Debug.Log("Start Dialogue");
    }

    [YarnCommand("SetSceneEnd")]
    public void SetSceneEnd()
    {
        anim.Play("EndScene");
    }

    [YarnCommand("StartNextScene")]
    public void StartNextScene()
    {
        StartCoroutine(StartScene());
    }


    public static GameManager GetInstance()
    {
        return instance;
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        isGameOver = true;

        Debug.Log("Game Over!");

        Time.timeScale = 0f;
    }
}
