using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboRob : BaseHero
{
    public override void takeTurn()
    {
        Debug.Log("Its " + this.uid + "Turn");
        this.takeDamage(2);


    }
    public override void takeDamage(int damage)
    {
        this.currHealth -= damage;
        if(this.currHealth <= 0){
            die();
        }
    }
    public override void die()
    {
        TurnManager.Instance.removeUnit(this);
        this.gameObject.SetActive(false);
    }
}
