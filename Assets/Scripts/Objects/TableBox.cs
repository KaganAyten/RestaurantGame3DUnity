using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableBox : ItemBox,IPutItemFull
{
    public Table table;
    public bool canTake;
    private bool isFull;
    public bool IsFull {   get { return isFull; } }
    public override ItemType GetItem()
    {
        if (isFull)
        {
            table.CloseItem();
            canTake = false;
            return base.GetItem();
        }
        return ItemType.NONE;
    }

    public bool PutItem(ItemType item)
    {
        if (!IsFull)
        {
            return table.PutItem(item);
        }
        return false;
    }
}
