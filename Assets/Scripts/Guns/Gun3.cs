using UnityEngine;

public class Gun3 : GunClass
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon, _image;

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

    public override void Fire()
    {

    }
}
