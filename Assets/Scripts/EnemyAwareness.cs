using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwareness : MonoBehaviour
{
    public Material aggroMat;
    public bool isAggro;
    public float awarenessRadius = 8f;

    private Transform playerTransform;

    private void Start()
    {
        playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    private void Update()
    {
        var dist = Vector3.Distance(transform.position, playerTransform.position);

        if (dist < awarenessRadius)
        {
            isAggro = true;
        }

        if (isAggro)
        {
            GetComponent<MeshRenderer>().material = aggroMat;
        }
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.transform.CompareTag("Playe r"))
    //    {
    //        isAggro = true;
    //    }
    //}
}
