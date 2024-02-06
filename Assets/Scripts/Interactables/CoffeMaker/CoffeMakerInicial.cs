using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeMakerInicial : Interactable
{
    [SerializeField] private GameObject CartaInicial;
    public override void Interact()
    {
        CartaInicial.SetActive(true);
    }
}
