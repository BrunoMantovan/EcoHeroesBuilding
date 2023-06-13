using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weighingBarController : MonoBehaviour
{
    public GameObject truck;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(truck.transform.position.x + 0.1f, truck.transform.position.y - 0.1f); 
    }
}
