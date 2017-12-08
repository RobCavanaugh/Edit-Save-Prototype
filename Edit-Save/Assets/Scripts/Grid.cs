using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    // Static instance of Grid
    public static Grid gridInstance = null;

    //Grid properties
    private GridLayoutGroup grid;
    public GameObject canvasGameObject;
    public int gridWidth = 0;
    public int gridHeight = 0;
    public GameObject gridPrefab;


    //Tiles
    private Tile[,] tiles;
    private float tileWidth = -1f;
    private float tileHeight = -1;
    public GameObject tileNodePrefab;

    private void Awake()
    {
        //Check if instance already exists
        if (gridInstance != null && gridInstance != this)
        {
            //If instance already exists and it's not this:
            Destroy(gameObject);
        }
        else
        {
            //Sets this to not be destroyed when reloading scene
           // DontDestroyOnLoad(gameObject);

            gridInstance = this;

        }
        PopulateGrid();
    }
    void Start ()
    {
       
	}
	
    private void PopulateGrid()
    {
        if (!grid)
        {
            GameObject gridGameObject = Instantiate(gridPrefab);
            grid = gridGameObject.GetComponent<GridLayoutGroup>();
            if (canvasGameObject)
            {
                gridGameObject.transform.SetParent(canvasGameObject.transform, true);
            }
            if (grid)
            {
                RectTransform gridRect = grid.GetComponent<RectTransform>();
                tileWidth = gridRect.rect.width / (float)gridWidth;
                tileHeight = gridRect.rect.height / (float)gridHeight;

                grid.cellSize = new Vector2(tileWidth, tileHeight);

                tiles = new Tile[gridWidth, gridHeight];

                Debug.Log("GridSetup::Setup Grid: gridWidth: " + gridWidth + " : gridHeight: " + gridHeight + " : tileWidth: " + tileWidth + " : tileHeight: " + tileHeight);

                for (int y = 0; y < gridHeight; y++)
                {

                    for (int x = 0; x < gridWidth; x++)
                    {
                        GameObject buttonObject = Instantiate(tileNodePrefab);
                        buttonObject.name = "Tile(" + x + ", " + y + ")";
                        Button button = buttonObject.GetComponent<Button>();
                        if (button)
                        {
                            Tile tile = ScriptableObject.CreateInstance<Tile>();
                            tile.gameObject = button.gameObject;
                            button.transform.SetParent(grid.transform, false);
                            tile.x = x;
                            tile.y = y;

                            //button.onClick.AddListener(() => TileClicked(tile));
                            Debug.Log("Created Tile:" + tile.x + "," + tile.y);
                        }
                    }
                }
            }
            else
            {
                Debug.LogError("No Grid !!!");
            }
        }
    }

	// Update is called once per frame
	void Update ()
    {
		
	}
}
