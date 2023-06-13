using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class weighingMachineController : MonoBehaviour
{
    public weighingMachine wm;
    public Renderer wmRender;
    private Vector3 gridStartPosition;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        OrdenRecyclables(wm.netList, gridStartPosition, 0.5f, 6);
        gridStartPosition = new Vector3(wmRender.transform.position.x - (wmRender.transform.localScale.x/2) + 0.2f, wmRender.transform.position.y + (wmRender.transform.localScale.y / 2));
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
