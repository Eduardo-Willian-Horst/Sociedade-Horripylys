using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MuzySpawner : MonoBehaviour
{
    [SerializeField] private ReturnInspecBtn Rb;
    [SerializeField] private GameObject Muzy, Porta;
    [SerializeField] private Clock clock;
    private bool isFirstFrame = true;

    void Start(){
        Muzy.SetActive(false);
    }
    void Update(){
        if(Rb.OutInspecItem){
            if(isFirstFrame){
                Muzy.SetActive(true);
                clock.AlteraMinuto(30);
                isFirstFrame = false;
                Porta.SetActive(true);
            }
        }
        
    }
}
