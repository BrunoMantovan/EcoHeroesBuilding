using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class recyclingTruck : MonoBehaviour
{
    Rigidbody2D truck;
    public bool onTravel = false;

    public List<netPrefab> loadNetRecycles;

    public float load;
    public float maxLoad = 2f;

    public float truckVelocity = 1f;
    public float truckDescharge = 3f;

    public Image barCurrentLoad;

    // Start is called before the first frame update
    void Start()
    {
        truck = GetComponent<Rigidbody2D>();
        loadNetRecycles = new List<netPrefab>();
        load = 0;
    }
    void Update()
    {
        barCurrentLoad.fillAmount = load / maxLoad;
    }
    public void Load(netPrefab net)
    {
        loadNetRecycles.Add(net);
        load = load + net.netWeight;
    }
    public void Dischard(netPrefab net)
    {
        loadNetRecycles.Remove(net);
        load = load - net.netWeight;
    }
}
