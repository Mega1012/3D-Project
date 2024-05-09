using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Itens;

public class ActionLifePack : MonoBehaviour
{
    public KeyCode KeyCode = KeyCode.E;
    public SOInt soInt;

    private void RecoverLife()
    {
        if(soInt.value > 0)
        {
            Debug.Log("RecoverLife");
            ItemManager.instance.RemoveByType(ItemType.LIFE_PACK);
            Player.instance.healthBase.ResetLife();
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode))
        {
            Debug.Log("KeyDown");
            RecoverLife();
        }
    }
}
