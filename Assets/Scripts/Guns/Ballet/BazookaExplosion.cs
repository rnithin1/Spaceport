using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazookaExplosion : MonoBehaviour
{
    private float _lifeTime;
    private float _speed;
    private float _size;

    private const float MAX_LIFE_TIME = 1;
    private const float MAX_SPEED = 1;
    private const float DAMAGE_RATE = 10f;


    void Update()
    {
        _lifeTime += Time.deltaTime;
        if (_lifeTime > MAX_LIFE_TIME) Destroy(gameObject);
        _size = _lifeTime * 10;
        transform.localScale = new Vector3 (_size, _size, _size);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit");
            var enemy = other.GetComponent<Enemy>();
            enemy.takeDamage(DAMAGE_RATE);
        }

    }
}
