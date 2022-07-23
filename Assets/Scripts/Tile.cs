using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Color BaseColor;
    public Color AltColor;
    public SpriteRenderer Renderer;
    public GameObject Highlight;
    public BaseUnit OccupiedUnit;

    public bool walkable => OccupiedUnit == null;
    public void Init(bool checkered)
    {
        if(checkered) {
            Renderer.color = BaseColor;
        } else {
             Renderer.color = AltColor;
        }
    }

    void OnMouseEnter(){
        Highlight.SetActive(true);
        //If User hovers a unit debug info, In future this should explain abilities in the gui
        if(this.OccupiedUnit){
            Debug.Log("Hovered unit " + OccupiedUnit);
        }
    }
    void OnMouseExit(){
        Highlight.SetActive(false);
    }
    public void SetUnit(BaseUnit unit){
        //move off of old tile
        if(unit.occupiedTile){
            unit.occupiedTile.OccupiedUnit = null;
        }
        unit.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, unit.transform.position.z);
        unit.occupiedTile = this;
        this.OccupiedUnit = unit;
    }
}
