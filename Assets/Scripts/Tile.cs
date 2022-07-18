using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Color BaseColor;
    public Color AltColor;
    public SpriteRenderer Renderer;
    public GameObject Highlight;
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
    }
    void OnMouseExit(){
        Highlight.SetActive(false);
    }
}
