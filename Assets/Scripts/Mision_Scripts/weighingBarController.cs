using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weighingBarController : MonoBehaviour
{
    public GameObject truck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = truck.transform.position;
    }
}
