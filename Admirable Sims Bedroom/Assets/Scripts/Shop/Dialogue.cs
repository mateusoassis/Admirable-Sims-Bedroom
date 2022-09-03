using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public PlayerManager playerManager;

    public GameObject dialogueGameObject;

    public string[] dialogueString;
    public float typeInterval;
    public float skipDuration;
    private float skipTimer;

    public TextMeshProUGUI dialogueText;

    private int index;
    private bool started;
    public bool ended;
    private bool canSkip;

    void Start()
    {
        skipTimer = skipDuration;
        dialogueText.text = string.Empty;
        //StartDialogue();
    }

    void Update()
    {
        if((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.F)) && canSkip)
        {
            if(dialogueText.text == dialogueString[index])
            {
                NextDialogue();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueString[index];
                RefreshSkipTimer();
            }
        }

        if(started)
        {
            if(skipTimer > 0 && !canSkip)
            {
                skipTimer -= Time.unscaledDeltaTime;
            }
            else
            {
                canSkip = true;
            }
        }
    }

    public void RefreshSkipTimer()
    {
        skipTimer = skipDuration;
        canSkip = false;
    }

    public void StartDialogue()
    {
        dialogueGameObject.SetActive(true);
        dialogueText.text = string.Empty;
        started = true;
        //Pause();
        index = 0;
        StartCoroutine(TypeDialogue());
    }

    public IEnumerator TypeDialogue()
    {
        foreach(char c in dialogueString[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSecondsRealtime(typeInterval);
        }
    }

    public void NextDialogue()
    {
        if(index < dialogueString.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeDialogue());
        }
        else
        {
            dialogueGameObject.SetActive(false);
            ended = true;
            playerManager.isWindowOpen = false;
        }
    }
}
