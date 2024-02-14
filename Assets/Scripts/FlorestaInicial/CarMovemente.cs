using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovemente : MonoBehaviour
{
    [SerializeField] private List<GameObject> WayPoints;
    [SerializeField] private float Speed = 2f;
    private int index = 0;
    public bool Inicia = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(Inicia){
            if(transform.rotation.y <= 0f){
                transform.Rotate(0f, 0.25f, 0f);
            }
            Vector3 destino = WayPoints[index].transform.position;
            Vector3 novaPosicao = Vector3.MoveTowards(transform.position, destino, Speed * Time.deltaTime);
            transform.position = novaPosicao;

            float distancia = Vector3.Distance(transform.position, destino);
            if(distancia <= 0.05){
                if(index < WayPoints.Count -1) index++;
                else{
                    Destroy(this.gameObject);
                }
            }
        }
    }

    
}
