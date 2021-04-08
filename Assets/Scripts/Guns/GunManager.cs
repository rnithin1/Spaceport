using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    [SerializeField] GunSwitch _gunSwitch;

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) Fire();
    }

    private void Fire()
    {
        _gunSwitch.GetGunUsing().Fire();
    }

    public void PlaySE()
    {
        AudioSource _audioSource = GameObject.FindWithTag("GunManager").GetComponent<AudioSource>();
        _audioSource.Stop();
        _audioSource.clip = _gunSwitch.GetGunUsing().SE;
        _audioSource.Play();
    }

}
