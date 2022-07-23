using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singleton gameManager
    public static GameManager Instance;

    private GameState State;

    //The various game states to cycle through
    public enum GameState
    {
        GenerateGrid,
        SpawnUnits,
        InCombat,
        Victory,
        Loss,

    }
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        updateGameState(GameState.GenerateGrid);
    }

    public void updateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case (GameState.GenerateGrid):
                GridManager.Instance.generateGrid();
                break;
            case (GameState.SpawnUnits):
                handleSpawnUnits();
                break;
            case (GameState.Loss):
                handleLoss();
                break;
            case (GameState.Victory):
                handleVictory();
                break;


        }


    }
    private void handleSpawnUnits()
    {
        UnitManager.Instance.spawnHeroes();
        UnitManager.Instance.spawnEnemies();
        updateGameState(GameState.InCombat);
    }
    public void Update()
    {
        if(State == GameState.InCombat){
            TurnManager.Instance.nextTurn();
        }
       
        

        


    }
    public void handleLoss()
    {
        Debug.Log("Defeat");


    }
    public void handleVictory()
    {
        Debug.Log("Victory");


    }

}
