using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Itens;

public class ItemColectablePlanets : ItemCollectableBase
{
    public new Collider2D collider;
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.instance.AddByType(ItemType.COIN);
        collider.enabled = false;
    }
}
