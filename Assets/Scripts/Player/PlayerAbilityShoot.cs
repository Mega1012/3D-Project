using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{
    public GunBase[] gunPrefabs;
    public Transform gunPosition;

    private GunBase _currentGun;
    private int _currentIndex;

    private GunBase[] _guns;

    protected override void Init()
    {
        base.Init();

        CreateGuns();

        inputs.Gameplay.Shoot.performed += cts => StartShoot();
        inputs.Gameplay.Shoot.canceled += cts => CancelShoot();
        inputs.Gameplay.SwitchWeapon1.performed += cts => ChangeGun(0);
        inputs.Gameplay.SwitchWeapon2.performed += cts => ChangeGun(1);
    }

    private void ChangeGun(int index)
    {
        if (index >= _guns.Length)
        {
            Debug.LogError($"Índice maior que o comprimento do array de armas: {_guns.Length}");
            return;
        }

        if (_currentIndex == index)
        {
            return;
        }

        _currentGun.gameObject.SetActive(false);
        _currentGun = _guns[index];
        _currentGun.gameObject.SetActive(true);

        _currentIndex = index;
    }

    private void CreateGuns()
    {
        _guns = new GunBase[gunPrefabs.Length];

        for(int i = 0; i < _guns.Length; ++i)
        {
            _guns[i] = Instantiate(gunPrefabs[i], gunPosition);
            _guns[i].transform.localPosition = _guns[i].transform.localEulerAngles = Vector3.zero;
            _guns[i].gameObject.SetActive(false);
        }

        _currentGun = _guns[0];
        _currentIndex = 0;
        _currentGun.gameObject.SetActive(true);
    }

    private void StartShoot()
    {
        _currentGun.StartShoot();
        Debug.Log("Start Shoot");
    }

    private void CancelShoot()
    {
        Debug.Log("Cancel Shoot");
        _currentGun.StopShoot();
    }
}
