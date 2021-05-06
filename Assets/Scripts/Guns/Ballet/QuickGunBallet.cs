using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is attached on the Ballete prefab
public class QuickGunBallet : MonoBehaviour
{
    private float _lifeTime;
    private float _speed;

    private const float MAX_LIFE_TIME = 20;
    private const float MAX_SPEED = 0.1f;
    private const float DAMAGE_RATE = 13f;


    void Update()
    {
        _lifeTime += Time.deltaTime;
        _speed = MAX_SPEED;
        if (_lifeTime > MAX_LIFE_TIME) Destroy(gameObject);
        transform.Translate(0, _speed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player") return;
        if (other.gameObject.tag == "Untagged") return;
        if (other.gameObject.layer == LayerMask.NameToLayer("UI")) return;
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit");
            var enemy = other.GetComponent<Enemy>();
            enemy.takeDamage(_speed * DAMAGE_RATE);
        }

        Destroy(gameObject);
    }
}
