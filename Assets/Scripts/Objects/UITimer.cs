using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UITimer : MonoBehaviour
{
    [SerializeField] private Image clockFilled;
    public void UpdateClock(float amount,float maxValue)
    {
        clockFilled.fillAmount = amount / maxValue;
    }
}
