using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SimpleTalk : Interactable
{
    [SerializeField] private TalkSystem TS;
    [SerializeField] private List<string> Talk_Phrases;
    [SerializeField] private MovingDirections md;
    private bool isTalking = false;
    public delegate void FuncaoInteractHandler();
    public static event FuncaoInteractHandler OnInteractCalled;

    

    public override void Interact(){
        md = this.GetComponent<MovingDirections>();
        if(md != null){
            //md.StartTowardFunction();
        }
        if(!isTalking){
            StartCoroutine(TalkController());
        }
        
        if (OnInteractCalled != null)
        {
            OnInteractCalled();
        }
        

    }

    private IEnumerator TalkController()
    {   isTalking = true;
        
        yield return StartCoroutine(Talk(Talk_Phrases[0]));
        
        isTalking = false;
    }

    IEnumerator Talk(string texto)
    {
        TS.SendMsg(texto);

        // Aguarde um tempo ou outro evento antes de prosseguir
        yield return new WaitForSeconds(3f);

        // Se necessário, faça outras operações aqui

        // Conclua a corrotina
        yield return null;
    }
}
