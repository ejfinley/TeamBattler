using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    //Singleton Grid Manager
    public static GridManager Instance;
    public int height;
    public int width;

    private Dictionary<Vector2, Tile> _tiles;
    public Tile TilePrefab;

    void Awake(){
        
        Instance = this;
    }

    public void generateGrid(){
        _tiles = new Dictionary<Vector2, Tile>();
        for(int x = -width; x <= width; x++){
            for(int y = -height; y <= height; y++){
                Tile newTile = Instantiate(TilePrefab, new Vector3(transform.position.x + (x * TilePrefab.transform.localScale.x) ,transform.position.y + (y * TilePrefab.transform.localScale.y)), Quaternion.identity);
                newTile.name = $"Tile {x} {y}";
                bool checkered = (x + y) % 2 == 0;
                newTile.Init(checkered);
                _tiles[new Vector2(x, y)] = newTile;
            }
        }
        GameManager.Instance.updateGameState(GameManager.GameState.SpawnUnits);
    }

    public Tile getHeroSpawnTile(){
        return _tiles.Where(t=> t.Key.x <  -width/2 && t.Value.walkable).OrderBy(t=> Random.value).First().Value;
    }
    public Tile getEnemySpawnTile(){
        return _tiles.Where(t=> t.Key.x > width/2 && t.Value.walkable).OrderBy(t=> Random.value).First().Value;
    }
}
