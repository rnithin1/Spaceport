using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public EnemyManager enemyManager;
    private float enemyHealth = 2f;

    public GameObject gunHitEffect;
    public float SpriteWalkFPS = 5f;

    private Material spriteMaterial;
    private Renderer spriteRenderer;
    private MaterialPropertyBlock spriteMaterialPropertyBlock;

    public bool isMoving = false;

    public float speed;
    private Vector3 direction; 

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CalcVelocity());
        spriteRenderer = GetComponent<Renderer>();
        spriteMaterialPropertyBlock = new MaterialPropertyBlock();
    }

    IEnumerator CalcVelocity()
    {
        while (Application.isPlaying)
        {
            Vector3 lastPos = transform.position;
            yield return new WaitForSeconds(0.1f);
            direction = lastPos - transform.position;
            speed = Vector3.Distance(transform.position, lastPos) / 0.1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        isMoving = speed > 0.1f;
        updateHealth();
    }

    public void takeDamage(float damage)
    {
        Instantiate(gunHitEffect, transform.position, Quaternion.identity);
        enemyHealth -= damage;
        updateHealth();
    }

    void updateHealth()
    {
        if (enemyHealth <= 0)
        {
            if (enemyManager.enemiesInTrigger.Contains(this))
            {
                enemyManager.RemoveEnemy(this);
            }
            Destroy(this.gameObject);
        }
    }
}
