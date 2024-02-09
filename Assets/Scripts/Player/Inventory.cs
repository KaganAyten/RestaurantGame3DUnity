using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ObjectnType
{
    public GameObject item;
    public ItemType type;
}
public class Inventory : MonoBehaviour
{
    [SerializeField] private List<ObjectnType> itemsToHold = new List<ObjectnType>(); 
    private ItemType currentType;
    public ItemType CurrentType { get { return currentType; } }
    private void Start()
    {
        currentType = ItemType.NONE;
    } 
    public void TakeItem(ItemType type)
    {
        if (currentType != ItemType.NONE) return;
        currentType = type;
        foreach(ObjectnType itemHold in itemsToHold)
        {
            if (itemHold.type != type)
            {
                itemHold.item.SetActive(false);
            }
            else
            {
                itemHold.item.SetActive(true);
            }
        }
    }
    public ItemType PutItem()
    {
        if (currentType == ItemType.NONE) return ItemType.NONE; 
        return currentType;

    }
    public void ClearHand()
    {
        currentType = ItemType.NONE; 
        itemsToHold.ForEach(obj => obj.item.SetActive(false));
    }

    public ItemType GetItem()
    {
        return currentType;
    }
}
