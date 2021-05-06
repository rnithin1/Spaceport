using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private bool isSpeaking;

    private DialogueManager dialogueManager;

    public void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    public void Update()
    {
        if (dialogueManager.isSpeaking && Input.GetKeyDown(KeyCode.F))
        {
            dialogueManager.DisplayNextSentence();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            dialogueManager.StartDialogue(dialogue);
        }
    }

    public void OnTriggerExit()
    {
        dialogueManager.EndDialogue();
    }
}
