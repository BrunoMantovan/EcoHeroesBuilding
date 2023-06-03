using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class recyclingTruck : MonoBehaviour
{
    public float load;
    public List<recycles> loadRecycles;
    public float maxLoad = 2f;
    //public GameObject wareHouse;
    Rigidbody2D truck;
    public Image barCurrentLoad;
    public bool onTravel = false;
    public float truckVelocity = 1f;
    public float truckDescharge = 2f;
    public wareHouseCotroller wareHouse;

    // Start is called before the first frame update
    void Start()
    {
        truck = GetComponent<Rigidbody2D>();
        loadRecycles = new List<recycles>();
    }
    void Update()
    {
        foreach (recycles re in loadRecycles) re.transform.position = transform.position;
        LoadCalculation();
        barCurrentLoad.fillAmount = load / maxLoad;

    }
    public void Load(recycles re)
    {
        loadRecycles.Add(re);
    }
    private void LoadCalculation()
    {
        load = 0;
        foreach (recycles recycle in loadRecycles) load = load + recycle.weight;
    }

    public void ToWarehouse()
    {
        onTravel = true;
        StartCoroutine("DischargeRecycles");

    }
    IEnumerator DischargeRecycles()
    {
        Vector3 loadPosition1 = transform.position;
        while (onTravel)
        {
            Vector3 wareHousePosition = wareHouse.transform.position;
            while (transform.position != wareHousePosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, wareHousePosition, truckVelocity * Time.deltaTime);
                yield return null;
            }

            while (loadRecycles.Count > 0)
            {
                wareHouse.SaveRecycle(loadRecycles[0]);
                loadRecycles.RemoveAt(0);
                yield return new WaitForSecondsRealtime(truckDescharge * Time.deltaTime);
            }
            
            while (transform.position != loadPosition1)
            {
                transform.position = Vector3.MoveTowards(transform.position, loadPosition1, truckVelocity * Time.deltaTime);
                yield return null;
            }
            onTravel = false;
        }
    }
}
