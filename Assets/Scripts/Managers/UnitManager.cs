using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;
    private List<ScriptableUnit> _units;
    void Awake()
    {
        Instance = this;
        _units = Resources.LoadAll<ScriptableUnit>("Units").ToList();
    
    }

    public void spawnHeroes()
    {
        //Temporarily Spawn random
        int heroCount = 3;
        for(int i = 0; i < heroCount; i++){
            BaseHero randomPrefab = getRandomUnit<BaseHero>(Faction.Hero);
            var spawnedHero = Instantiate(randomPrefab);
            var randomSpawnTile = GridManager.Instance.getHeroSpawnTile();
            randomSpawnTile.SetUnit(spawnedHero);
            TurnManager.Instance.addHero(spawnedHero);
        }


    }
    public void spawnEnemies()
    {
        //Temporarily Spawn random
        int enemyCount = 6;
        for(int i = 0; i < enemyCount; i++){
            BaseEnemy randomPrefab = getRandomUnit<BaseEnemy>(Faction.Enemy);
            var spawnedEnemy = Instantiate(randomPrefab);
            var randomSpawnTile = GridManager.Instance.getEnemySpawnTile();
            randomSpawnTile.SetUnit(spawnedEnemy);
            TurnManager.Instance.addEnemy(spawnedEnemy);
        }


    }

    private T getRandomUnit<T>(Faction faction) where T : BaseUnit{
        Debug.Log(_units.Where(u => u.Faction == faction).OrderBy(o => Random.value).First().UnitPrefab );
        return (T) _units.Where(u => u.Faction == faction).OrderBy(o => Random.value).First().UnitPrefab ;

    }
    
}
