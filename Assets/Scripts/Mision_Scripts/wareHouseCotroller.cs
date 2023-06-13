using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wareHouseCotroller : MonoBehaviour
{
    public List<netPrefab> savedNetRecycles;
    Rigidbody2D rb;
    public float load;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        savedNetRecycles = new List<netPrefab>();
    }
    public void SaveRecycle(netPrefab net)
    {
        savedNetRecycles.Add(net);
    }
    public float LoadCalculation()
    {
        load = 0;
        foreach (netPrefab net in savedNetRecycles) load = load + net.netWeight;
        return load;
    }
}
