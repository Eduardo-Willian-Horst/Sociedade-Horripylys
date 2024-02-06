using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedCoffe : MonoBehaviour
{
    [SerializeField] private TalkSystem TS;
    void Start()
    {
        StartCoroutine(NeedCoffeTalk());
    }

    private IEnumerator NeedCoffeTalk(){
        yield return new WaitForSeconds(1.2f);
        TS.SendMsg("Preciso de um café!");
    }
}
