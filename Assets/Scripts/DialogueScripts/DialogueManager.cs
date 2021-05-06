using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Animator animator;

    public bool isSpeaking;

    private Queue<string> sentences; 

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isSpeaking);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        isSpeaking = true;
        if (isSpeaking)
        {
            animator.SetBool("isOpen", true);

            nameText.text = dialogue.name;

            //sentences.Clear();
            sentences = new Queue<string>();

            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }

            DisplayNextSentence();
        }
    }

    public void DisplayNextSentence()
    {
        if (isSpeaking)
        {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }

            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }

    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null; 
        }
    }

    public void EndDialogue()
    {
        if (isSpeaking)
        {
            isSpeaking = false;
            animator.SetBool("isOpen", false);
            Debug.Log("End of conversation");
        }
    }
}
