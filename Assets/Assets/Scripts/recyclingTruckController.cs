using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recyclingTruckController : MonoBehaviour
{
    public recyclingTruck truck;
    //public Transform wareHouseSender;
    //public Transform wareHouse;
    public Vector3 loadPosition;
    private Rigidbody2D rb;     

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnMouseDown()
    {
        if(Input.GetMouseButton(0) && !truck.onTravel & truck.loadRecycles.Count != 0) truck.ToWarehouse();
    }
}

 