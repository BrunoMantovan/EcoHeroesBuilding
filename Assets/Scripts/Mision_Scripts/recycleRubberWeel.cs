using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recycleRubberWeel : recycles
{

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.weight = 1.2f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
