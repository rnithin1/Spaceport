using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public GameObject player;
    void LateUpdate()
    {
        var target = player.transform.position; //Camera.main.transform.position;
        target.y = transform.position.y;
        transform.LookAt(target);
    }
}