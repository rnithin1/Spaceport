using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PowerUpButton : MonoBehaviour
{
    [SerializeField] private GameObject button;

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player")) return;
        button.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        if(!other.CompareTag("Player")) return;
        button.SetActive(false);
    }
}
