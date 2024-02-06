using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class InspecItem : Interactable
{
    [SerializeField] private Sprite Item;
    [SerializeField] private GameObject CanvasInspecItem;
    [SerializeField] private RawImage ItemStand;
    [SerializeField] private PlayerStats Stats;

    void Awake(){
        CanvasInspecItem.SetActive(false);
    }
    public override void Interact()
    {   
        
        Debug.Log("Inpecionou: " + this.gameObject.name);
        Stats.isInspecItem = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; // Esconde o cursor
        CanvasInspecItem.SetActive(true);
        ItemStand.texture = Item.texture;
        
        
        


    }

    
}
