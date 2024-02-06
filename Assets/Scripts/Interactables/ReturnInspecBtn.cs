using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnInspecBtn : MonoBehaviour
{
    [SerializeField] private PlayerStats Stats;
    [SerializeField] private GameObject CanvasInspecItem;
    public bool OutInspecItem = false;
    void Awake(){
        CanvasInspecItem.SetActive(false);
    }
    public void OnClickExitInspec(){
        Debug.Log("era pra sair essa poga");
        Stats.isInspecItem = false; 
        CanvasInspecItem.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; // Esconde o cursor
        StartCoroutine(Notification());
    }

    IEnumerator Notification(){
        OutInspecItem = true;
        yield return new WaitForSeconds(0.1f);
        OutInspecItem = false;
        yield return null;
    }
}
