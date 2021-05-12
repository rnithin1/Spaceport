using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwareness : MonoBehaviour
{
    // public Material aggroMat;
    public bool isAggro;
    public float awarenessRadius = 8f;
    public bool isNPC; // enemy or NPC
    private float _shootingTime;

    private Transform playerTransform;

    private void Start()
    {
        playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    private void Update()
    {
        var dist = Vector3.Distance(transform.position, playerTransform.position);

        if (dist < awarenessRadius && !isNPC)
        {
            isAggro = true;
        }

        if (isAggro)
        {
            _shootingTime += Time.deltaTime;
            if(_shootingTime > 1) Shot();
            // GetComponent<MeshRenderer>().material = aggroMat;
        }
    }

    private void Shot()
    {
        _shootingTime = 0;
        GameObject.FindWithTag("MyHealthBar").GetComponent<MyHealthBar>().Damage(0.1f);
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.transform.CompareTag("Playe r"))
    //    {
    //        isAggro = true;
    //    }
    //}
}
