using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunSwitch : MonoBehaviour
{
    [SerializeField] private GameObject _left, _center, _right;
    [SerializeField] private GameObject _scripts;
    private List<GunClass> _guns = new List<GunClass>();
    private int _id;

    void Start()
    {
        GunClass[] gunClasses = _scripts.GetComponents<GunClass>();
        foreach (GunClass g in gunClasses) _guns.Add(g);
        ChangeIcons();
    }
    
    void Update()
    {
        SwitchGuns();
    }

    private void SwitchGuns()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _id = GetIdPlus(1);
            ChangeIcons();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _id = GetIdPlus(-1);
            ChangeIcons();
        }
    }

    public GunClass GetGunUsing()
    {
        return _guns[_id];
    }

    private void ChangeIcons()
    {
        _center.GetComponent<Image>().sprite = _guns[_id].Icon;
        _left.GetComponent<Image>().sprite = _guns[GetIdPlus(-1)].Icon;
        _right.GetComponent<Image>().sprite = _guns[GetIdPlus(1)].Icon;

        _center.GetComponentInChildren<Text>().text = _guns[_id].Name;
        _left.GetComponentInChildren<Text>().text = _guns[GetIdPlus(-1)].Name;
        _right.GetComponentInChildren<Text>().text = _guns[GetIdPlus(1)].Name;

        //TODO: Play SE here;
    }

    private int GetIdPlus(int num)
    {
        int id = _id;
        id += num;
        if (id >= _guns.Count) id = 0;
        if (id < 0) id = _guns.Count - 1;

        return id;
    }
}
