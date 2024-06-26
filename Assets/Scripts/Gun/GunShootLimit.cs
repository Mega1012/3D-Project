using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunShootLimit : GunBase
{
    public List<UiFillUpdater> UiFillUpdaters;

    public float maxShoot = 5f;
    public float TimeToRecharge = 1f;

    private float _currentShoots;
    private bool _recharging = false;

    private void Awake()
    {
        GetAllUIs();
    }

    protected override IEnumerator ShootCoroutine()
    {
        if (_recharging) yield break;

        while (true)
        {
            if (_currentShoots < maxShoot)
            {
                Shoot();
                _currentShoots++;
                CheckRecharge();
                UpdateUI();
                yield return new WaitForSeconds(TimeBetweenShoot);
            }
        }
    }

    private void CheckRecharge()
    {
        if (_currentShoots >= maxShoot)
        {
            StopShoot();
            StartRecharge();
        }
    }

    private void StartRecharge()
    {
        _recharging = true;
        StartCoroutine(RechargeCoroutine());
    }

    IEnumerator RechargeCoroutine()
    {
        float time = 0;
        while (time < TimeToRecharge)
        {
            time += Time.deltaTime;
            UiFillUpdaters.ForEach(i => i.UpdateValue(time/TimeToRecharge));
            yield return new WaitForEndOfFrame();
        }
        _currentShoots = 0;
        _recharging = false;
    }

    private void UpdateUI()
    {
        UiFillUpdaters.ForEach(i => i.UpdateValue(maxShoot, _currentShoots));
    }

    private void GetAllUIs()
    {
        UiFillUpdaters = FindObjectsOfType<UiFillUpdater>().ToList();
        for(int i = UiFillUpdaters.Count -1; i >= 0; --i)
        {
            if (UiFillUpdaters[i].fillUpdaterType != UiFillUpdater.FillUpdaterType.Ammo)
            {
                UiFillUpdaters.RemoveAt(i);
            }
        }
    }
}

