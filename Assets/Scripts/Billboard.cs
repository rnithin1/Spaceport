using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform playerTransform;
    private void Start()
    {
        playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    void LateUpdate()
    {
        var target = playerTransform.position; //Camera.main.transform.position;
        target.y = transform.position.y;
        transform.LookAt(target);
    }
}