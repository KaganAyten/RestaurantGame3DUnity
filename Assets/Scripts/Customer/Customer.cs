using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Customer : MonoBehaviour
{
    [SerializeField] private GameObject burger;
   public void ExitFromArea(Vector3 pos)
    {
        burger.SetActive(true);
        transform.DOMove(pos, 3).OnComplete(()=> { Destroy(this.gameObject);});
    }
    public void MoveNext(Vector3 pos)
    {
        transform.DOMove(pos, 2);
    }
}
