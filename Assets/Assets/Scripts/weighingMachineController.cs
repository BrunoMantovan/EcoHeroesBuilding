using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class weighingMachineController : MonoBehaviour
{
    public float totalWeight;
    public recyclingTruck recyclingTruck;
    public List<recycles> recyclesList;
    private Rigidbody2D rb;
    public Renderer wmRender;
    private Vector3 gridStartPosition;
    private Collider2D weighingMachineCollider;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        weighingMachineCollider = GetComponent<Collider2D>();
        wmRender = GetComponent<Renderer>();
        gridStartPosition = wmRender.bounds.min + new Vector3(0f, wmRender.bounds.size.y * 1f, 0f);
        recyclesList = new List<recycles>();
    }

    // Update is called once per frame
    void Update()
    {
        TotalWeight();
        OrdenRecyclables(recyclesList, gridStartPosition, 0.2f, 14);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("nets"))
        {
            foreach (recycles re in collision.gameObject.GetComponent<netController>().recyclesCatch)
                recyclesList.Add(re);
            Destroy(collision.gameObject);
        }
    }
    private void TotalWeight()
    {
        totalWeight = 0;
        foreach (recycles re in recyclesList)
        {
            totalWeight = totalWeight + re.weight;
        }
    }
    private void OrdenRecyclables(List<recycles> list, Vector3 gridStart, float cellSize, int rowSize)
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
    public void OnMouseDown()
    {
        if (Input.GetMouseButton(0) && recyclingTruck.load <= recyclingTruck.maxLoad && !recyclingTruck.onTravel && recyclesList.Count != 0)
        {
            recyclingTruck.Load(recyclesList[0]);
            recyclesList[0].transform.position = recyclingTruck.transform.position;
            recyclesList.RemoveAt(0);
            
        }
    }
    
}
