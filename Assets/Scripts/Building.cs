using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public bool placed { get; private set; }
    public BoundsInt area;

    private float startPosX;
    private float startPosY;
    public bool isBeingHeld = false;
    public GameObject placeCanvas;

    GridBuilding gridBuild;
    private bool hasBeenPlaced = false;

    private void Start()
    {
        gridBuild = GameObject.Find("Grid2").GetComponent<GridBuilding>();
    }

    void Update()
    {
        if(isBeingHeld == true && hasBeenPlaced == false)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x, mousePos.y, 0);
        }
        
    }
    
    private void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            isBeingHeld = true;
        }
        
    }

    private void OnMouseUp()
    {
        isBeingHeld = false;
       if(hasBeenPlaced == false)
        {
            placeCanvas.SetActive(true);
        }
              
    }

    public bool CanBePlaced()
    {
        Vector3Int positionInt = GridBuilding.current.gridlayout.LocalToCell(transform.position);
        BoundsInt areaTemp = area;
        areaTemp.position = positionInt;

        if (GridBuilding.current.CanTakeArea(areaTemp))
        {
           return true;
        }
        return false;
    }

    public void Place()
    {
        Vector3Int positionInt = GridBuilding.current.gridlayout.LocalToCell(transform.position);
        BoundsInt areaTemp = area;
        areaTemp.position = positionInt;
        placed = true;

        GridBuilding.current.TakeArea(areaTemp);
    }

    public void PlaceButton()
    {
        gridBuild.TickButton();
        gridBuild.gameObject.SetActive(false);
        hasBeenPlaced = true;
        transform.gameObject.tag = "PlacedBuilding";
    }
    public void CancelButton()
    {
        gridBuild.CrossButton();
    }
}
