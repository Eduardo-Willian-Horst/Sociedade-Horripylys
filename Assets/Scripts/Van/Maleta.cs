using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class Maleta : Interactable
{
    [SerializeField] InventoryController Ic;
    public override void Interact()
    {
        Ic.AddItemInventory(1);
    }
}
