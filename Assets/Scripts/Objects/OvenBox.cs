using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenBox : ItemBox
{
    [SerializeField] private Oven oven;
    public bool canTake;
    public override ItemType GetItem()
    {
        if (!canTake) return ItemType.NONE;
        oven.CloseCookedMeatObject();
        canTake = false;
        return base.GetItem();
    } 

}
