using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recyclePlasticBottle : recycles
{

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.weight = 0.2f;
    }
}
