using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : Interactable
{

    [SerializeField] private TalkSystem ts;
    [SerializeField] private GameObject HomemPosto, PaperEigthHours;
    [SerializeField] private InicialMen Im;
    
    

    public override void Interact()
    {

        if(Im.CanDespawn){
            ts.SendMsg("A máquina esta quebrada.");
            Destroy(HomemPosto);
            PaperEigthHours.SetActive(true);
        }else ts.SendMsg("Não estou com sede.");
        

        
    }
}
