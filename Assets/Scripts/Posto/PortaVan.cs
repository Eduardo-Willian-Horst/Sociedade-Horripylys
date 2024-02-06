using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaVan : Interactable
{

    [SerializeField] private SceneSampler ss;
    public override void Interact()
    {
        ss.LoadInsideVan();
    }
}
