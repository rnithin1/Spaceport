using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    // This value (id) exists in case you put the power-up item by hand.
    // Basically, power-up items are instantiated from a script.
    [SerializeField] private Powers.PowerId id;
    private Power _power;
    private RectTransform _rectTransform;
    private GameObject _player;
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        PickUp();
        LookAtPlayer();
    }

    private void PickUp()
    {
        if (!Input.GetMouseButtonUp(1)) return;
        if(_power == null) SetPower(id);
        _power.Up();
        GameObject.FindWithTag(nameof(PowerUpUIController)).GetComponent<PowerUpUIController>().DisplayPowerUI(id);
        Destroy(transform.parent.gameObject);
    }

    private void SetPower(Powers.PowerId id)
    {
        var scripts = GameObject.FindWithTag("Powers").GetComponents<Power>();
        _power = scripts[(int) id];
    }

    private void LookAtPlayer()
    {
        var direction = _player.transform.position - _rectTransform.position;
        direction.y = 0;
 
        var lookRotation = Quaternion.LookRotation(direction, Vector3.up);
        _rectTransform.rotation = Quaternion.Lerp(_rectTransform.rotation, lookRotation, 0.1f);
    }
}
