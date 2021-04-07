using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickGun : GunClass
{
    [SerializeField] private Sprite _icon, _image;
    [SerializeField] private GameObject _quickBullet;
    private string _name = "Quick Gun";
    [SerializeField] private AudioClip _se;
    private const float _RELOAD_TIME = 0.4f;

    private bool _reloaded = true;

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
        // If it hasn't reloaded, you can't shoot.
        if (!_reloaded) return;
        _reloaded = false;

        // Instantiate a ballet
        var player = GameObject.FindWithTag("Player").transform;
        var pos = player.position;
        var rot = player.rotation * Quaternion.Euler(90f, 0, 0);
        GameObject ballet = Instantiate(_quickBullet, pos, rot);

        // Play gunshot audio
        GameObject.FindWithTag("GunManager").GetComponent<GunManager>().PlaySE();

        // Reload soon
        StartCoroutine(nameof(Reload));
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(_RELOAD_TIME);
        _reloaded = true;
    }
}
