using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Power : MonoBehaviour
{
    [SerializeField] private Material material;

    public Material GetMaterial()
    {
        return material;
    }
    public abstract void Up();
}
