using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jocemar : Interactable
{

    public GameObject cameraPrincipal;
    public Camera segundaCamera;
    public DialogInterativoController Dc;
    public override void Interact()
    {
        TrocarCamera();
        Dc.StartTalk();
    }

    void TrocarCamera()
    {
        if(cameraPrincipal.gameObject.activeSelf){
            
            segundaCamera.gameObject.SetActive(true);
            cameraPrincipal.SetActive(false);
        }else{
            
            segundaCamera.gameObject.SetActive(false);
            cameraPrincipal.SetActive(true);
        }
        
    }
}
