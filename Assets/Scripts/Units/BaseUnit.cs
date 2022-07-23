using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUnit : MonoBehaviour
{
    public Tile occupiedTile;

    public string unitName;
    public Faction faction;
    public int nextTurn;
    //units unique identifier
    public string uid;
    //Units base health
    public int baseHealth;
    // The base number of tiles to move in an action
    public int baseMoveRange;
    // The base number of tiles attack can reach
    public int baseAttackRange;
    // Determines turn order
    // This is the time between attacks 
    // A high number means a longer wait
    public int baseAgility;

    // Base damage done by an attack
    public int baseStrength;

    public int currHealth;

    public abstract void takeTurn();

    public abstract void takeDamage(int damage);
    public abstract void die();


}
