using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is attached on the Ballete prefab
public class BazookaBallet : MonoBehaviour
{
    [SerializeField] private GameObject _bazookaExplosion;
    private float _lifeTime;
    private float _speed;

    private const float MAX_LIFE_TIME = 3;
    private const float MAX_SPEED = 0.7f;
    private const float DAMAGE_RATE = 10f;


    void Update()
    {
        _lifeTime += Time.deltaTime;
        _speed = MAX_SPEED - _lifeTime * MAX_SPEED / MAX_LIFE_TIME;
        if (_lifeTime > MAX_LIFE_TIME) Destroy(gameObject);
        transform.Translate(0, _speed, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") return;
        if (collision.gameObject.layer == LayerMask.NameToLayer("UI")) return;
            var pos = transform.position;
        Instantiate(_bazookaExplosion, pos, Quaternion.identity);
        Destroy(gameObject);
    }

}
