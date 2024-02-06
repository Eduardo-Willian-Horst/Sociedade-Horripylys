using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicialMen : Interactable
{
    [SerializeField] private TalkSystem Ts;
    [SerializeField] private MovingDirections Md;
    public bool CanDespawn = false;

    public override void Interact()
    {
        Md.StartTowardFunction(this.gameObject);
        Ts.SendMsg("???: Ei moça! Pode pegar um refri pra mim? Eu pago. É que tá na melhor parte da música.");
        CanDespawn = true;
    }
}
