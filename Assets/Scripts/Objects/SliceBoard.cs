using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class SliceBoard : Functionality,IPutItemFull
{
    [SerializeField] private List<ObjectnType> itemsToHold = new List<ObjectnType>();
    private ItemType currentType; 
    private void Start()
    {
        currentType = ItemType.NONE;
        timer.gameObject.SetActive(false);
    }
    public override ItemType Process()
    {
        if (currentType == ItemType.NONE) return ItemType.NONE;
        if (processStarted == true && timer.gameObject.activeSelf == false)
        {
            timer.gameObject.SetActive(true);
        }
        processStarted = true;
        currentTime += Time.deltaTime;
        timer.UpdateClock(currentTime, maxTime);
        if (currentTime >= maxTime)
        {
            currentTime = 0;
            timer.gameObject.SetActive(false);
            processStarted = false;
            timer.UpdateClock(currentTime, maxTime);
            switch (currentType)
            {
                case ItemType.TOMATO: 
                    return ItemType.SLICEDTOM;
                case ItemType.LETTUCE:  
                    return ItemType.SLICEDLET;
                case ItemType.ONION: 
                    return ItemType.SLICEDON;
                case ItemType.CHEESE: 
                    return ItemType.SLICEDCHE;
                case ItemType.BREAD:
                    return ItemType.SLICEDBREAD;
            }
        }
        return ItemType.NONE;
    }
    public override void ClearObject()
    {
        base.ClearObject();
        currentType = ItemType.NONE;
        itemsToHold.ForEach(obj => obj.item.SetActive(false));
    }
    public bool PutItem(ItemType item)
    {
        if (FilterItem(item)==false) return false;
        if (currentType != ItemType.NONE) return false;
        currentType = item;
        foreach (ObjectnType itemHold in itemsToHold)
        {
            if (itemHold.type != currentType)
            {
                itemHold.item.SetActive(false);
            }
            else
            {
                itemHold.item.SetActive(true);
            }
        }
        return true;
    } 
    private bool FilterItem(ItemType type)
    { 
        switch (type)
        {
            case ItemType.TOMATO:
            case ItemType.LETTUCE:
            case ItemType.ONION:
            case ItemType.CHEESE:
            case ItemType.BREAD: return true;
            default:
                return false; 
        } 
    }
}
