using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private Sprite[] images = new Sprite[4];
    private Transform playerTransform;
    private EnemyAwareness enemyAwareness;

    public int currentState;

    public SpriteRenderer spriteRenderer;
    private Animator m_Animator;
    private Enemy enemy;

    void Start()
    { 
        enemy = GetComponent<Enemy>();
        enemyAwareness = GetComponent<EnemyAwareness>();
        playerTransform = FindObjectOfType<PlayerMove>().transform;
        m_Animator = GetComponent<Animator>();
    }

    void Update()
    {
        currentState = GetAngleIndex();
        if (enemy.isMoving)
        {
            m_Animator.enabled = true;
            m_Animator.SetInteger("currentState", currentState);
        }
        else
        {
            m_Animator.enabled = false;
            GetComponent<SpriteRenderer>().sprite = images[currentState];
        }
        
        //Debug.Log(GetAngleIndex());
    }

    int GetAngleIndex()
    {
        if (enemyAwareness.isAggro)
        {
            //transform.LookAt(playerTransform);
            return 0;
        }
        Vector3 e_angle = transform.rotation.eulerAngles;
        //Debug.Log(e_angle);
        float enemyAngle = e_angle.y;

        if (enemyAngle >= 60f && enemyAngle < 120f)
            return 1;
        else if (enemyAngle >= 120f && enemyAngle < 240f)
            return 2;
        else if (enemyAngle >= 240f && enemyAngle < 300f)
            return 3;
        else return 0;

    }
}
