using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAwareness : MonoBehaviour
{
    // public Material aggroMat;
    public bool isAggro;
    public float awarenessRadius = 8f;
    public bool isNPC; // enemy or NPC

    [SerializeField] private Material[] lineColorMaterials;
    private LineRenderer _lineRenderer;
    private float _shootingTime;
    private Transform playerTransform;
    private bool _withinDistance;

    private const float SHOOTING_WIDTH_RATE = 7;
    private const float SHOOTNG_DISTANCE = 15;
    
    private void Start()
    {
        playerTransform = FindObjectOfType<PlayerMove>().transform;
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        var dist = Vector3.Distance(transform.position, playerTransform.position);

        if (dist < awarenessRadius && !isNPC)
        {
            isAggro = true;
        }

        if (isAggro)
        {
            GetDrawGunLine();
            _shootingTime += Time.deltaTime;
            if(_shootingTime > 1) Shot();
            // GetComponent<MeshRenderer>().material = aggroMat;
        }
    }

    private void GetDrawGunLine()
    {
        var enemyPos = transform.position;
        // right hand position;
        enemyPos.x -= 0.7f;
        var playerPos = playerTransform.position;
        playerPos.y += 0.6f;
        float rate =  SHOOTNG_DISTANCE / Vector3.Distance(enemyPos, playerPos);
        if (rate < 1)
        {
            playerPos = Vector3.Lerp(enemyPos, playerPos, rate);
            _withinDistance = false;
        }
        else _withinDistance = true;
        Vector3[] positions = {enemyPos, playerPos};
        _lineRenderer.SetPositions(positions);
    }
    private void Shot()
    {
        _shootingTime = 0;
        if(_withinDistance) GameObject.FindWithTag("MyHealthBar").GetComponent<MyHealthBar>().Damage(0.04f);
        StartCoroutine("ResetLineWidth");
    }

    private IEnumerator ResetLineWidth()
    {
        _lineRenderer.endWidth *= SHOOTING_WIDTH_RATE;
        _lineRenderer.material = lineColorMaterials[1];
        yield return new WaitForSeconds(0.05f);
        _lineRenderer.endWidth /= SHOOTING_WIDTH_RATE;
        _lineRenderer.material = lineColorMaterials[0];
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.transform.CompareTag("Playe r"))
    //    {
    //        isAggro = true;
    //    }
    //}
}
