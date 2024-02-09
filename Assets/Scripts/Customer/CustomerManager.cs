using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public static CustomerManager Instance;
    [SerializeField] private float timerSpeed;
    [SerializeField] private Queue<Customer> customerList = new Queue<Customer>();

    [SerializeField] private List<Customer> customerPrefabs = new List<Customer>();
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform exitPoint;
    private float currentTime = 0;
    private float lrRandom=0.75f;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (currentTime <=Random.Range(50,80))//spawnRate is random between 50 and 80 seconds
        {
            currentTime += Time.deltaTime*timerSpeed;
        }
        else
        {
            currentTime = 0;
            Vector3 spawnPos = spawnPoint.position + (spawnPoint.forward * -1 * customerList.Count)+spawnPoint.right*Random.Range(-lrRandom, lrRandom);
            Customer temp = Instantiate(customerPrefabs[Random.Range(0,customerPrefabs.Count)], spawnPos, spawnPoint.rotation);
            customerList.Enqueue(temp);
        } 
    }
    public void SellToCustomer()
    {
        if (customerList.Count == 0) return;
        Customer firstCustomer=customerList.Peek();
        firstCustomer.ExitFromArea(exitPoint.position);
        customerList.Dequeue();
        for(int i = 0; i < customerList.Count; i++)
        {
            Vector3 nextPos = spawnPoint.position + (spawnPoint.forward * -1 * i) + spawnPoint.right * Random.Range(-lrRandom, lrRandom);
            customerList.ToArray()[i].MoveNext(nextPos);
        } 

    }
}
