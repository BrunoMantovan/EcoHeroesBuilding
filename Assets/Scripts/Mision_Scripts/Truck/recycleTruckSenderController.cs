using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recycleTruckSenderController : MonoBehaviour
{
    public recyclingTruck truck;
    public wareHouseCotroller wh;
    public GameObject wareHouse;
    public GameObject waighingMachine;

    private void OnMouseDown()
    {
        if (Input.GetMouseButton(0) && !truck.onTravel & truck.loadNetRecycles.Count != 0)
            StartCoroutine("DischargeRecycles");
    }
    IEnumerator DischargeRecycles()
    {
        truck.onTravel = true;

        while (truck.onTravel)
        {
            Vector3 wareHousePosition = wareHouse.transform.position;
            while (transform.position != wareHousePosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, wareHousePosition, truck.truckVelocity * Time.deltaTime);
                yield return null;
            }

            while (truck.loadNetRecycles.Count > 0)
            {
                 wh.SaveRecycle(truck.loadNetRecycles[0]);
                 truck.Dischard(truck.loadNetRecycles[0]);
                 yield return new WaitForSecondsRealtime(truck.truckDescharge * Time.deltaTime);
            }

            Vector3 loadPosition = waighingMachine.transform.position;
            while (transform.position != loadPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, loadPosition, truck.truckVelocity * Time.deltaTime);
                yield return null;
            }
            truck.onTravel = false;
        }
    }
}