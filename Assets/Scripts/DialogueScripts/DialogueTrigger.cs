using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;

public class DialogueTrigger : MonoBehaviour
{
    public string filepath;

    private Dialogue dialogue;
    private bool isSpeaking;
    private bool hasSpokenOnce;
    private bool isInTrigger;

    public GameObject exclamation;

    private DialogueManager dialogueManager;

    public void Start()
    {
        string jsonString = File.ReadAllText("Assets/Scripts/Dialogue/" + filepath);
        dialogue = JsonUtility.FromJson<Dialogue>(jsonString);
        dialogueManager = FindObjectOfType<DialogueManager>();

        if (!System.String.IsNullOrEmpty(jsonString))
        {
            hasSpokenOnce = false;
        }
        else
        {
            hasSpokenOnce = true;
        }
    }

    public void Update()
    {
        if (hasSpokenOnce && exclamation)
        {
            Destroy(exclamation);
        }
        if (dialogueManager.isSpeaking && Input.GetKeyDown(KeyCode.F))
        {
            dialogueManager.DisplayNextSentence();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            isInTrigger = true;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (isInTrigger && !dialogueManager.isSpeaking && Input.GetMouseButtonUp(1))
        {
            hasSpokenOnce = true;
            dialogueManager.StartDialogue(dialogue);
        }
    }

    public void OnTriggerExit()
    {
        isInTrigger = false;
        dialogueManager.EndDialogue();
    }
}
