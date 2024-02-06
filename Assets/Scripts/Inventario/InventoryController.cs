using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    [SerializeField] public List<Sprite> Imagens_Itens;
    [SerializeField] private TalkSystem Ts;
    [SerializeField] private Image Inv_1, Inv_2, Inv_3;
    private int[] Inventario;
    void Start(){
        Inventario = new int[3]{0,0,0};
        Inventario[0] = PlayerPrefs.GetInt("Inventario_1");
        Inventario[1] = PlayerPrefs.GetInt("Inventario_2");
        Inventario[2] = PlayerPrefs.GetInt("Inventario_3");

        Debug.Log("Slot1: " + PlayerPrefs.GetInt("Inventario_1"));
        Debug.Log("Slot2: " + PlayerPrefs.GetInt("Inventario_2"));
        Debug.Log("Slot3: " + PlayerPrefs.GetInt("Inventario_3"));
        atualizaInventario();
    }


    //Lembrar de apagar isso
    void Update(){
        if(Input.GetKeyDown(KeyCode.K)) RemoveItemInventory(1);
    }
    public bool AddItemInventory(int item_id){
        for(int i = 0; i < 3; i++){
            if(Inventario[i] == 0){
                Inventario[i] = item_id;
                atualizaInventario();
                return true;
            }
            Debug.Log("Slot: " + i);
        }
        return false;
    }

    public bool RemoveItemInventory(int item_id){
        for(int i = 0; i < 3; i++){
            if(Inventario[i] == item_id){
                Inventario[i] = 0;

                atualizaInventario();
                return true;
            }
        }
        return false;
    }
    private void atualizaInventario(){
        OrganizaInventario();
        Inv_1.sprite = Imagens_Itens[Inventario[0]];
        Inv_2.sprite = Imagens_Itens[Inventario[1]];
        Inv_3.sprite = Imagens_Itens[Inventario[2]];
        PlayerPrefs.SetInt("Inventario_1",Inventario[0]);
        PlayerPrefs.SetInt("Inventario_2",Inventario[1]);
        PlayerPrefs.SetInt("Inventario_3",Inventario[2]);
    }

    private void OrganizaInventario(){
        if(Inventario[0] == 0 && Inventario[1] != 0) {
            Inventario[0] = Inventario[1];
            Inventario[1] = 0;
        }
        if(Inventario[1] == 0 && Inventario[2] != 0) {
            Inventario[1] = Inventario[2];
            Inventario[2] = 0;
        }
    }
}
