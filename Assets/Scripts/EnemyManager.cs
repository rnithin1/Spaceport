using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> enemiesInTrigger = new List<Enemy>();

    public void AddEnemy(Enemy enemy)
    {
        enemiesInTrigger.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemiesInTrigger.Remove(enemy);
    }

    public void Update()
    {
        int numberOfEnemies = GameObject.FindObjectsOfType(typeof(Enemy)).Length;
        Debug.Log("No Enemies: " + numberOfEnemies);
        if (numberOfEnemies == 2 && SceneManager.GetActiveScene().name == "City")
        {
            SceneManager.LoadScene(0);
        }
    }

}

