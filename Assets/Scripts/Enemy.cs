using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    [SerializeField] private Image healthBar;
    public EnemyManager enemyManager;
    private float enemyHealth = 2f;
    private const float MAX_HEALTH = 2f;

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
        enemyHealth = MAX_HEALTH;
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
        UpdateHealthBar();
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

    private void UpdateHealthBar()
    {
        // 0.0 ~ 1.0
        float rate = enemyHealth / MAX_HEALTH;
        // Change the length of bar
        healthBar.fillAmount = rate;
        // Change the color of bar
        Color color;
        if(rate > 0.5f) color = Color.green;
        else if(rate > 0.2F) color = Color.yellow;
        else color = Color.red;
        healthBar.color = color;
    }
    
}
