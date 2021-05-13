using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class WalkAfterTalking : MonoBehaviour
{

    public Transform location;
    private DialogueManager dialogueManager;
    private DialogueTrigger dialogueTrigger;
    private NavMeshAgent agent;

    public void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        dialogueTrigger = GetComponent<DialogueTrigger>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //if (dialogueTrigger.hasSpokenOnce && !dialogueManager.isSpeaking)
        //{
        //    agent.destination = location.position;
        //}
        if (agent.remainingDistance < 0.5f)
        {
            //agent.SetDestination(transform.position);
        }
           agent.SetDestination(FindObjectOfType<PlayerMove>().transform.position);
    }

    
}
