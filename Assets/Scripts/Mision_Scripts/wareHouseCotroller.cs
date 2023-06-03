using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wareHouseCotroller : MonoBehaviour
{
    public List<recycles> savedRecycles;
    Rigidbody2D rb;
    public float load;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        savedRecycles = new List<recycles>();
    }
    public void SaveRecycle(recycles re)
    {
        savedRecycles.Add(re);
    }
    public float LoadCalculation()
    {
        load = 0;
        foreach (recycles recycle in savedRecycles) load = load + recycle.weight;
        return load;
    }
}
