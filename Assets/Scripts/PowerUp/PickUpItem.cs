using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    // This value (id) exists in case you put the power-up item by hand.
    // Basically, power-up items are instantiated from a script.
    [SerializeField] private Powers.PowerId id;
    private Power _power;
    void Start()
    {
        
    }

    void Update()
    {
        PickUp();
    }

    private void PickUp()
    {
        if (!Input.GetMouseButtonUp(1)) return;
        if(_power == null) SetPower(id);
        _power.Up();
        Destroy(transform.parent.gameObject);
    }

    public void SetPower(Powers.PowerId id)
    {
        var scripts = GameObject.FindWithTag("Powers").GetComponents<Power>();
        _power = scripts[(int)id];
    }
}
