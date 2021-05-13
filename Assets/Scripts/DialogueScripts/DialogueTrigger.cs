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
    public bool hasSpokenOnce;
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
            string[] temp = new string[dialogue.sentences.Length + 1];
            for (int i = 0; i < dialogue.sentences.Length; i++)
            {
                temp[i + 1] = dialogue.sentences[i];
            }
            dialogue.sentences = temp; 
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
        if (dialogueManager.isSpeaking && hasSpokenOnce && Input.GetKeyDown(KeyCode.F))
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
        if (isInTrigger && !dialogueManager.isSpeaking && Input.GetKeyDown(KeyCode.F))
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
