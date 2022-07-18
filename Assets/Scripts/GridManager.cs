using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int height;
    public int width;

    public Tile TilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        generateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void generateGrid(){
        for(int x = 0; x < width; x++){
            for(int y = 0; y < height; y++){
                Tile newTile = Instantiate(TilePrefab, new Vector2(transform.position.x + x,transform.position.y + y), Quaternion.identity);
                newTile.name = $"Tile {x} {y}";
                bool checkered = (x % 2 == 0 && y % 2 != 0 ) || (x % 2 != 0 && y % 2 == 0 );
                newTile.Init(checkered);
            }
        }
    }
}
