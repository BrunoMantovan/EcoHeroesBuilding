using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recyclingTruckOrdenController : MonoBehaviour
{
    public recyclingTruck truck;
    public Renderer truckRender;
    private Vector3 gridStartPosition;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        OrdenRecyclables(truck.loadNetRecycles, gridStartPosition, 0.5f, 2);
        gridStartPosition = new Vector3(truckRender.transform.position.x - (truckRender.transform.localScale.x/4), truckRender.transform.position.y);
    }

    private void OrdenRecyclables(List<netPrefab> list, Vector3 gridStart, float cellSize, int rowSize)
    {
        int currentRow = 0;
        int currentColumn = 0;
        for (int i = 0; i < list.Count; i++)
        {
            Vector3 position = gridStart + new Vector3(currentColumn * cellSize, -currentRow * cellSize, 0f);
            list[i].transform.position = position;
            currentColumn++;
            if (currentColumn >= rowSize)
            {
                currentColumn = 0;
                currentRow++;
            }
        }
    }
}
