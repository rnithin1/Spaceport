using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public float range = 20f;
    public float verticalRange = 20f;
    public float fireRate = 1f;
    public float gunShotRadius = 20f;

    public float smallDamage = 1f;
    public float bigDamage = 2f;

    private float nextTimeToFire;
    private BoxCollider gunTrigger;

    public LayerMask raycastLayerMask;
    public LayerMask enemyLayerMask;

    public EnemyManager enemyManager;

    // Start is called before the first frame update
    void Start()
    {
        gunTrigger = GetComponent<BoxCollider>();
        gunTrigger.size = new Vector3(1, verticalRange, range);
        gunTrigger.center = new Vector3(0, 0, range * 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextTimeToFire)
        {   
            fire();
        }
    }

    void fire()
    {
        // Simulate gun shot radius
        Collider[] enemyColliders = Physics.OverlapSphere(transform.position, gunShotRadius, enemyLayerMask);

        // Alert enemies in the gunshot radius
        foreach (var enemyCollider in enemyColliders)
        {
            enemyCollider.GetComponent<EnemyAwareness>().isAggro = true;
        }

        // Play gunshot audio 
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();

        // Damage all enemies that are visible on the screen (code in EnemyManager)
        foreach (var enemy in enemyManager.enemiesInTrigger)
        {
            // get direction to enemy, send out a raycast
            var dir = enemy.transform.position - transform.position;
            RaycastHit hit;

            if (Physics.Raycast(transform.position, dir, out hit, range * 1.5f, raycastLayerMask))
            {
                if (hit.transform == enemy.transform)
                {
                    float dist = Vector3.Distance(enemy.transform.position, transform.position);

                    if (dist > range * 0.5f)
                    {
                        enemy.takeDamage(smallDamage);
                    }
                    else
                    {
                        enemy.takeDamage(bigDamage);
                    }
                }
            }
        }

        nextTimeToFire = Time.time + fireRate;
    }

    private void OnTriggerEnter(Collider other)
    {
        // add potential enemy
        Enemy enemy = other.transform.GetComponent<Enemy>();
        if (enemy)
        {
            enemyManager.AddEnemy(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // remove potential enemy
        Enemy enemy = other.transform.GetComponent<Enemy>();
        if (enemy)
        {
            enemyManager.RemoveEnemy(enemy);
        }
    }
}
