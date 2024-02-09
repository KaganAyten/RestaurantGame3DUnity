using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour, IPutItemFull
{
    private bool isFull;
    [SerializeField] private GameObject cookedItem;
    [SerializeField] private UITimer timer;
    [SerializeField] private OvenBox itemBox;
    [SerializeField] private float cookTime;
    private float currentTime;

    private void Start()
    {
        timer.gameObject.SetActive(false);
        cookedItem.SetActive(false);
    }
    private void Update()
    {
        if (isFull)
        {
            currentTime += Time.deltaTime;
            timer.UpdateClock(currentTime, cookTime);
            if (currentTime >= cookTime)
            {
                currentTime = 0;
                timer.gameObject.SetActive(false);
                cookedItem.SetActive(true);
                itemBox.SetType(ItemType.COOKEDMEAT);
                itemBox.canTake = true;
                isFull = false; 
            }
        }
    }
    public void CloseCookedMeatObject()
    {
        cookedItem.SetActive(false);
    }
    public bool PutItem(ItemType item)
    {
        if (item != ItemType.MEATBALL) return false;
        if (isFull) return false;
        timer.gameObject.SetActive(true);
        isFull = true; 
        return true; 
    }
}
