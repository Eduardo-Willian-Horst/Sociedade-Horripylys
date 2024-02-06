using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Men : Interactable
{

    [SerializeField] private TalkSystem Ts;
    [SerializeField] private MovingDirections Md;

    public override void Interact()
    {
        Md.StartTowardFunction(this.gameObject);
        Ts.SendMsg("???: ...");
    }

    
}
