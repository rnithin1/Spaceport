using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pen : GunClass
{
    [SerializeField] private Sprite _icon, _image;
    [SerializeField] private GameObject _penBallet;
    private string _name = "Pen";
    [SerializeField] private AudioClip _se;
    private const float _RELOAD_TIME = 0f;
    public readonly float DISTANCE = 10f;

    public override string Name
    {
        get { return _name; }
        set { Name = _name; }
    }

    public override Sprite Icon
    {
        get { return _icon; }
        set { Icon = _icon; }
    }

    public override Sprite Image
    {
        get { return _image; }
        set { Image = _image; }
    }

    public override AudioClip SE
    {
        get { return _se; }
        set { SE = _se; }
    }

    public override float ReloadTime
    {
        get { return _RELOAD_TIME; }
        set { ReloadTime = _RELOAD_TIME; }
    }

    public override void Fire()
    {
        StartDrawing();

        // Play gunshot audio
        GameObject.FindWithTag("GunManager").GetComponent<GunManager>().PlaySE();
    }

    private void StartDrawing()
    {
        var player = GameObject.FindWithTag("Player").transform;
        // Get the initial pen position from the mouse position
        Debug.Log("Input.mousePosition.x " + Input.mousePosition.x);
        Debug.Log("Input.mousePosition.y " + Input.mousePosition.y);
        Vector3 pos = Camera.main.ScreenToWorldPoint(
            new Vector3(
           Input.mousePosition.x,
           Input.mousePosition.y,
           Camera.main.WorldToScreenPoint(player.transform.position).z + DISTANCE
           ));
        // line size
        // float width = widthSlider.value / 2 + 0.03f;
        float width = 1;
        
        GameObject pen = Instantiate(_penBallet, pos, Quaternion.identity);
        pen.transform.localScale = new Vector3(width, width, width);
    }

}