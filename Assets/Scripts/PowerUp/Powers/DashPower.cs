using System.Collections;
using UnityEngine;
public class DashPower : Power
{
    private float _timeLimit = 10;
    private PlayerCondition _playerCondition;
    private bool _isActive;
    
    public override void Up()
    {
        _isActive = true;
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
