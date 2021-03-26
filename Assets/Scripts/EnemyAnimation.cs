using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{

    private Transform playerTransform;
    private EnemyAwareness enemyAwareness;

    public int currentState;

    public SpriteRenderer spriteRenderer;
    private Animator m_Animator;

    void Start()
    {
        enemyAwareness = GetComponent<EnemyAwareness>();
        playerTransform = FindObjectOfType<PlayerMove>().transform;
        m_Animator = GetComponent<Animator>();
    }

    void Update()
    {
        currentState = GetAngleIndex();
        m_Animator.SetInteger("currentState", currentState);
        //Debug.Log(GetAngleIndex());
    }

    int GetAngleIndex()
    {
        if (enemyAwareness.isAggro)
        {
            transform.LookAt(playerTransform);
        }
        Vector3 e_angle = transform.rotation.eulerAngles;
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
