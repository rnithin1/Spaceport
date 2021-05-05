using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class DashPower : Power
{
    private PlayerCondition _playerCondition;

    public override void Up()
    {
        _playerCondition = transform.parent.gameObject.GetComponent<PlayerCondition>(); 
        _playerCondition.walkSpeedRate = 1.5f;
        StartCoroutine(TimeUp());
    }

    private IEnumerator TimeUp()
    {
        yield return new WaitForSeconds(6);
        _playerCondition.walkSpeedRate = 1;
    }
}
