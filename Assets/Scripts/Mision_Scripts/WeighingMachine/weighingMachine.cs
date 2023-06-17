using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weighingMachine : MonoBehaviour
{
    public float totalWeight;
    public recyclingTruck recyclingTruck;
    public List<netPrefab> netList;
    private Rigidbody2D rb;
    private Vector3 gridStartPosition;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        netList = new List<netPrefab>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("nets"))
        {
            netList.Add(collision.gameObject.GetComponent<netPrefab>());
            totalWeight = totalWeight + collision.gameObject.GetComponent<netPrefab>().netWeight;
        }
    }
    public void OnMouseDown()
    {
        if (Input.GetMouseButton(0) && recyclingTruck.load <= recyclingTruck.maxLoad && !recyclingTruck.onTravel && netList.Count != 0)
        {
            foreach (netPrefab net in netList)
            {
                if ((recyclingTruck.maxLoad - recyclingTruck.load) >= net.netWeight)
                {
                    recyclingTruck.Load(net);
                    totalWeight = totalWeight - net.netWeight;
                    net.transform.position = recyclingTruck.transform.position;
                    netList.Remove(net);
                    break;
                }
            }
        }
    }

}
