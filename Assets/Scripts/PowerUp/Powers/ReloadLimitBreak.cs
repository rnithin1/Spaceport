using System.Collections;
using UnityEngine;
public class ReloadLimitBreak : Power
{
    private PlayerCondition _playerCondition;
    
    public override void Up()
    {
        _playerCondition = transform.parent.gameObject.GetComponent<PlayerCondition>(); 
        _playerCondition.reloadRate = 0;
        StartCoroutine(TimeUp());
    }

    private IEnumerator TimeUp()
    {
        yield return new WaitForSeconds(6);
        _playerCondition.reloadRate = 1;
    }
    
}