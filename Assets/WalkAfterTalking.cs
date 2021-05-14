// Patrol.cs
using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class WalkAfterTalking : MonoBehaviour
{

    public Transform points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private DialogueManager dialogueManager;
    private DialogueTrigger dialogueTrigger;
    private bool hasSet;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        dialogueTrigger = GetComponent<DialogueTrigger>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = true;
        hasSet = false;
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up

        // Set the agent to go to the currently selected destination.
        //agent.destination = points[destPoint].position;
        agent.SetDestination(points.position);
        transform.LookAt(points);

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
    }


    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (dialogueTrigger.hasSpokenOnce && !dialogueManager.isSpeaking && !hasSet)
        {
            hasSet = true;
            GotoNextPoint();
        }
        else if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            Destroy(this.gameObject);
        }
    }
}