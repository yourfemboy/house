using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    
    [Header("General")]

    public List<itemType> inventoryList;
    public int selectedItem;
    
    [Space(20)]
    [Header("Keys")]
    [SerializeField] GameObject throwItemKey;
    [SerializeField] GameObject pickItemKey;

    [Space(20)]
    [Header("Item gameobjects")]
    [SerializeField] GameObject gun_item;



    private Dictionary<itemType, GameObject> itemSetActive = new Dictionary<itemType, GameObject>() { };


    void Start()
    {
        itemSetActive.Add(itemType.AssaultRifle6_06, gun_item);

        NewItemSelected();

    }
     
     void Update()
     {
        if (Input.GetKeyDown(KeyCode.Alpha1) && inventoryList.Count > 0)
        {
            selectedItem = 0;
            NewItemSelected();

        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && inventoryList.Count > 1)
        {
            selectedItem = 1;
            NewItemSelected();
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && inventoryList.Count > 2)
        {
            selectedItem = 2;
            NewItemSelected();
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && inventoryList.Count > 3)
        {
            selectedItem = 3;
            NewItemSelected();
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) && inventoryList.Count > 4)
        {
            selectedItem = 4;
            NewItemSelected();
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha6) && inventoryList.Count > 5)
        {
            selectedItem = 5;
            NewItemSelected();
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha7) && inventoryList.Count > 6)
        {
            selectedItem = 6;
            NewItemSelected();
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha8) && inventoryList.Count > 7)
        {
            selectedItem = 7;
            NewItemSelected();

        }

        if (Input.GetKeyDown(KeyCode.Alpha9) && inventoryList.Count > 8)
        {
            selectedItem = 8;
            NewItemSelected();
            
        }
     }


     private void NewItemSelected()
     {
        gun_item.SetActive(false);

        GameObject selectedItemGameObject =itemSetActive[inventoryList[selectedItem]];

     }
     

}
