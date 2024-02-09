using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Functionality : MonoBehaviour
{
    public float maxTime;
    public float currentTime;
    public bool processStarted;
    public UITimer timer;
    public virtual ItemType Process()
    {
        return ItemType.NONE;
    }
    public virtual void ClearObject()
    {

    }  
    public void ResetTimer()
    {
        currentTime = 0;
        timer.gameObject.SetActive(false);
        timer.UpdateClock(currentTime, maxTime);
    }
}
