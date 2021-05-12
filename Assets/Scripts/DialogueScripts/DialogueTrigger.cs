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

    private DialogueManager dialogueManager;

    public void Start()
    {
        string jsonString = File.ReadAllText("Assets/Scripts/Dialogue/" + filepath);
        dialogue = JsonUtility.FromJson<Dialogue>(jsonString);
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
