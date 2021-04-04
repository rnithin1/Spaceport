using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunClass : MonoBehaviour
{

    public abstract string Name { get; set; }
    public abstract Sprite Icon { get; set; }
    public abstract Sprite Image { get; set; }

    public abstract void Fire();
    
}
