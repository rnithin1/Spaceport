using UnityEngine;

public class Gun2 : GunClass
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon, _image;
    [SerializeField] private AudioClip _se;
    private const float _RELOAD_TIME = 0.2f;

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

    public override float ReloadTime
    {
        get { return _RELOAD_TIME; }
        set { ReloadTime = _RELOAD_TIME; }
    }

    public override AudioClip SE
    {
        get { return _se; }
        set { SE = _se; }
    }

    public override void Fire()
    {

    }
}
