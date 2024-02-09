using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Plate : MonoBehaviour
{
    [SerializeField] private List<ObjectnType> objects = new List<ObjectnType>();
    [SerializeField]private int currentObjectIndex = 0;
    public bool isDone = false;
    public bool PutItem(ItemType type)
    {
        if (currentObjectIndex > objects.Count-1) return false;
        if (type == objects[currentObjectIndex].type)
        {
            objects[currentObjectIndex].item.SetActive(true);
            currentObjectIndex++;
            if(currentObjectIndex > objects.Count - 1)
            {
                isDone = true;
            }
            return true;
        }
        return false;
    }
    public void ResetPlate()
    {
        isDone = false;
        currentObjectIndex = 0;
        foreach(ObjectnType obj in objects)
        {
            obj.item.SetActive(false);
        }
    }
}
