using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recover : Power
{
    public override void Up()
    {
        var _healthBar = GameObject.FindWithTag("MyHealthBar").GetComponent<MyHealthBar>();
        _healthBar.hp = 1;
        _healthBar.UpdateHealthBar();
    }
}
