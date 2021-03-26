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

    private bool isMoving = false;
    private bool wasMovingLastFrame = true;

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
            yield return new WaitForFixedUpdate();
            direction = lastPos - transform.position;
            speed = Vector3.Distance(transform.position, lastPos) / Time.fixedDeltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //MoveAndUpdateSprite();
        updateHealth();
    }

    public void takeDamage(float damage)
    {
        Instantiate(gunHitEffect, transform.position, Quaternion.identity);
        enemyHealth -= damage;
    }

    //void MoveAndUpdateSprite()
    //{
    //    cameraYRotation = Quaternion.Euler(0, cameraTransform.rotation.eulerAngles.y, 0);

    //    if (speed > 0.1f)
    //    {
    //        isMoving = true;
    //    }
    //    else
    //    {
    //        speed = 0;
    //        isMoving = false;
    //    }

    //    if (direction.magnitude > 0)
    //    {
    //        transform.rotation = Quaternion.LookRotation(direction);
    //    }

    //    if (isMoving != wasMovingLastFrame)
    //    {
    //        spriteMaterialPropertyBlock.SetFloat("_AnimFPS", isMoving ? SpriteWalkFPS : 0);
    //        spriteRenderer.SetPropertyBlock(spriteMaterialPropertyBlock);
    //    }

    //    wasMovingLastFrame = isMoving;
    //}

    void updateHealth()
    {
        if (enemyHealth <= 0)
        {
            enemyManager.RemoveEnemy(this);
            Destroy(this.gameObject);
        }
    }
}
