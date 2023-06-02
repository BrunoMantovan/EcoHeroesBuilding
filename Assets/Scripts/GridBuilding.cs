using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;


public class GridBuilding : MonoBehaviour
{
    public static GridBuilding current;
    public GridLayout gridlayout;

    public Tilemap Tilemap;
    public Tilemap tempTilemap;

    private static Dictionary<TileType, TileBase> tileBases = new Dictionary<TileType, TileBase>();

    private Building temp;
    private Vector3 prevPos;
    private BoundsInt prevArea;
    Vector2 offset;

    TimedBuilding timeBuilding;
    //Unity Methods
    private void Awake()
    {
        current = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        string tilepath = @"Tiles\";
        
        tileBases.Add(TileType.empty, null);
        tileBases.Add(TileType.white, Resources.Load<TileBase>(tilepath + "white"));
        tileBases.Add(TileType.green, Resources.Load<TileBase>(tilepath + "green"));
        tileBases.Add(TileType.red, Resources.Load<TileBase>(tilepath + "red"));

    }

    // Update is called once per frame
    void Update()
    {
        if (!temp)
        {
            return;
        }
        if (temp.isBeingHeld == true)
        {
            /*if (EventSystem.current.IsPointerOverGameObject(0))
            {
                return;
            }*/
            if (!temp.placed)
            {
                Vector3 buildingPos = temp.transform.position;
                //Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3Int cellPos = gridlayout.LocalToCell(buildingPos);

                if(prevPos != cellPos)
                {
                    temp.transform.localPosition = gridlayout.CellToLocalInterpolated(cellPos);
                    prevPos = cellPos;
                    FollowBuilding();
                }
            }
        }
    }

    //Building Placement
    public void InitializeWithBuilding(GameObject building)
    {
        temp = Instantiate(building, Vector3.zero, Quaternion.identity).GetComponent<Building>();
        FollowBuilding();
    }

    public void ClearArea()
    {
        TileBase[] toClear = new TileBase[prevArea.size.x * prevArea.size.y * prevArea.size.z];
        FillTiles(toClear, TileType.empty);
        tempTilemap.SetTilesBlock(prevArea, toClear);
    }

    void FollowBuilding()
    {
        ClearArea();
        temp.area.position = gridlayout.WorldToCell(temp.gameObject.transform.position);

        BoundsInt buildingArea = temp.area;

        TileBase[] baseArray = GetTilesBlock(buildingArea, Tilemap);

        int size = baseArray.Length;
        TileBase[] tileArray = new TileBase[size];

        for(int i=0; i < baseArray.Length; i++)
        {
            if(baseArray[i] == tileBases[TileType.white])
            {
                tileArray[i] = tileBases[TileType.green];
            }
            else
            {
                FillTiles(tileArray, TileType.red);
                break;
            }
        }

        tempTilemap.SetTilesBlock(buildingArea, tileArray);
        prevArea = buildingArea;
    }

    public bool CanTakeArea(BoundsInt area)
    {
        TileBase[] baseArray = GetTilesBlock(area, Tilemap);
        foreach (var b in baseArray)
        {
            if(b != tileBases[TileType.white])
            {
                Debug.Log("nao nao manito, en otro lugar va eso");
                return false;
            }
        }
        return true;
    }

    public void TakeArea(BoundsInt area)
    {
        SetTilesBlock(area, TileType.empty, tempTilemap);
        SetTilesBlock(area, TileType.green, Tilemap);
    }

    private static void SetTilesBlock(BoundsInt area, TileType type, Tilemap tilemap)
    {
        int size = area.size.x * area.size.y * area.size.z;
        TileBase[] tileArray = new TileBase[size];
        FillTiles(tileArray, type);
        tilemap.SetTilesBlock(area, tileArray);
    }

    private static TileBase[] GetTilesBlock(BoundsInt area, Tilemap tilemap)
    {
        TileBase[] array = new TileBase[area.size.x * area.size.y * area.size.z];
        int counter = 0;

        foreach (var v in area.allPositionsWithin)
        {
            Vector3Int pos = new Vector3Int(v.x, v.y, 0);
            array[counter] = tilemap.GetTile(pos);
            counter++;
        }
        return array;
    }

    private static void FillTiles(TileBase[] arr, TileType type)
    {
        for (int i=0; i < arr.Length; i++)
        {
            arr[i] = tileBases[type];
        }
    }

    public enum TileType
    {
        empty,
        white,
        green,
        red,
    }
}
