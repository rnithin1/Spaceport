using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpUIController : MonoBehaviour
{
    [SerializeField] private GameObject powerUpUI;
    [SerializeField] private Sprite[] icons;
    private string[] _names = {"∞ Reload", "Dash Speed Up"};
    public bool[] slots = new bool[10];
    public void DisplayPowerUI(Powers.PowerId powerId)
    {
        var ui = Instantiate(powerUpUI, transform);
        ui.GetComponent<PowerUpUI>().SetIcon(icons[(int)powerId], _names[(int)powerId]);
    }
}