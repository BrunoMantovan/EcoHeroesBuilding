using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Building : MonoBehaviour
{
    public bool placed { get; private set; }
    public BoundsInt area;

    private float startPosX;
    private float startPosY;
    public bool isBeingHeld = false;
    public GameObject placeCanvas;
    public GameObject timerCanvas;

    Grid gr_obj;
    Grid gr_obj2;
    GridBuilding gridBuild;
    private bool hasBeenPlaced = false;
    TimedBuilding timedBuild;

    public Canvas xpCanvas;
    public TextMeshProUGUI xpAnim;
    public int buildingXp;
    public bool finishedBuilding = false;
    ProgressBar progressB;
    Vector3 offset;
    Vector3 mousePosition;

    private void Start()
    {
        gr_obj = GameObject.Find("Grid").GetComponent<Grid>();
        gridBuild = GameObject.Find("Grid2").GetComponent<GridBuilding>();
        progressB = GameObject.FindGameObjectWithTag("ProgressBar").GetComponent<ProgressBar>();
    }

    void Update()
    {
        if(isBeingHeld == true && hasBeenPlaced == false)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x + offset.x, mousePos.y + offset.y, 0);
        }        
    }
    
    private void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {            
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            offset = transform.position - mousePosition;
            
            isBeingHeld = true;
            if (isBeingHeld == true && hasBeenPlaced == false)
            {
                placeCanvas.SetActive(false);
            }
            if(finishedBuilding == true)
            {
                StartCoroutine(GiveXp());
            }
        }        
    }
    private void OnMouseUp()
    {
        isBeingHeld = false;
       if(hasBeenPlaced == false && isBeingHeld == false)
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
        Vector3Int cp = gr_obj.LocalToCell(transform.position);
        transform.position = gr_obj.GetCellCenterLocal(cp);
        Vector3Int positionInt = GridBuilding.current.gridlayout.LocalToCell(transform.position);
        BoundsInt areaTemp = area;
        areaTemp.position = positionInt;
        placed = true;

        GridBuilding.current.TakeArea(areaTemp);
    }

    public void PlaceButton()
    {
        if (CanBePlaced())
        {
            Place();
            timedBuild = this.gameObject.GetComponent<TimedBuilding>();
            timedBuild.StartTimer();
            gridBuild.gameObject.SetActive(false);
            hasBeenPlaced = true;
            transform.gameObject.tag = "PlacedBuilding";
        }
    }
    public void CancelButton()
    {
        gridBuild.ClearArea();
        Destroy(this.gameObject);
    }

    IEnumerator GiveXp()
    {
        progressB.currentXp += buildingXp;
        xpCanvas.gameObject.SetActive(true);
        xpAnim.text = buildingXp + "xp";
        timerCanvas.SetActive(false);

        yield return new WaitForSeconds(2);

        Destroy(xpCanvas.gameObject);
    }
}
