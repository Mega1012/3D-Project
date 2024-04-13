using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunShootLimit : GunBase
{
    public float maxShoot = 5f;
    public float TimeToRecharge = 1f;

    private float _currentShoots;
    private bool _recharging = false;

    protected override IEnumerator ShootCoroutine()
    {
        /*while (true)
        {
            Shoot();
            yield return new WaitForSeconds(TimeBetweenShoot);
        }*/
        if( _recharging) yield break;

        while (true)
        {
            if(_currentShoots < maxShoot)
            {
                Shoot();
                _currentShoots++;
                CheckRecharge();
                yield return new WaitForSeconds(TimeBetweenShoot);
            }
        }
    }

    private void CheckRecharge()
    {
        if( _currentShoots >-maxShoot)
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
        while(time < TimeToRecharge)
        {
            time += Time.deltaTime;
            Debug.Log("Recharging" + time);
            yield return new WaitForEndOfFrame();
        }
        _currentShoots = 0;
        _recharging = false;
    }
}
