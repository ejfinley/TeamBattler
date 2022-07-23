using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance;
    private int currTime = 0;
    private Dictionary<string, BaseUnit> _heroUnits;
    private Dictionary<string, BaseUnit> _enemyUnits;

    private List<BaseUnit> turnList;

    void Awake()
    {
        Instance = this;
        _heroUnits = new Dictionary<string, BaseUnit>();
        _enemyUnits = new Dictionary<string, BaseUnit>();
        turnList = new List<BaseUnit>();
    }

    public void addHero(BaseHero hero)
    {
        string id = System.Guid.NewGuid().ToString() + hero.unitName;
        _heroUnits[id] = hero;
        hero.uid = id;
        hero.nextTurn = currTime + hero.baseAgility;
        turnList.Add(hero);

    }
    public void addEnemy(BaseEnemy enemy)
    {
        string id = System.Guid.NewGuid().ToString() + enemy.unitName;
        _enemyUnits[id] = enemy;
        enemy.uid = id;
        enemy.nextTurn = currTime + enemy.baseAgility;
        turnList.Add(enemy);

    }
    public void removeUnit(BaseUnit unit)
    {
        if (unit.faction == Faction.Hero)
        {
            _heroUnits.Remove(unit.uid);
            if (_heroUnits.Count == 0)
            {
                GameManager.Instance.updateGameState(GameManager.GameState.Loss);
            }

        }
        else
        {
            _enemyUnits.Remove(unit.uid);
            if (_enemyUnits.Count == 0)
            {
                GameManager.Instance.updateGameState(GameManager.GameState.Victory);
            }

        }
        turnList.Remove(unit);
    }    

        public void nextTurn()
        {
            turnList.Sort((u1, u2) => u1.nextTurn.CompareTo(u2.nextTurn));
            BaseUnit next = turnList[0];
            currTime = next.nextTurn;
            next.nextTurn = currTime + next.baseAgility;
            next.occupiedTile.Highlight.SetActive(true);
            next.takeTurn();
        
            next.occupiedTile.Highlight.SetActive(false);

        }


    }
