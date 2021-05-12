using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyHealthBar : MonoBehaviour
{
    [SerializeField] private Image bar;
    public float hp;
    private const float MAX_HP = 1.0f;
    void Start()
    {
        hp = MAX_HP;
    }

    void Update()
    {
        
    }

    public void Damage(float damageAmount)
    {
        hp -= damageAmount;
        if (hp <= 0) GameOver();
        UpdateHealthBar();
    }
    
    public void UpdateHealthBar()
    {
        // Change the length of bar
        bar.fillAmount = hp;
        // Change the color of bar
        Color color;
        if(hp > 0.5f) color = Color.green;
        else if(hp > 0.2F) color = Color.yellow;
        else color = Color.red;
        bar.color = color;
    }

    private void GameOver()
    {
        Debug.Log("GameOver");
    }
}
