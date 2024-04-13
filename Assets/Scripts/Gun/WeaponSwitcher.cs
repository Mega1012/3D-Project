using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public int selectedGun = 0;

    private void Start()
    {
        SelectGun();
    }

    private void Update()
    {
        int previousSelectedGun = selectedGun;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedGun = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedGun = 1;
        }

        if (previousSelectedGun != selectedGun)
        {
            SelectGun();
        }
    }

    void SelectGun()
    {
        int i = 0;
        foreach (Transform gun in transform)
        {
            if (i == selectedGun)
            {
                gun.gameObject.SetActive(true);
            }
            else
            {
                gun.gameObject.SetActive(false);

            }
            i++;
        }
    }
}

