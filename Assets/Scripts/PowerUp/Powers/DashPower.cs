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
        _playerCondition.walkSpeedRate = 3;
    }

    private void UpDate()
    {
        if(!_isActive) return;
        if(_timeLimit > 0) _timeLimit -= Time.deltaTime;
        else
        {
            _isActive = false;
            _timeLimit = 10;
            _playerCondition.walkSpeedRate = 1;
        }
    }
}
