using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public string itemName;
    int itemCost;
    int quantity;

    public Item(string name, int cost, int num){
        itemName = name;
        itemCost = cost;
        quantity = num;
    }

    public void AddOne(){
        quantity++;
        MonoBehaviour.print("Added 1 "+ itemName);
    }

    public void UseOne(){
        quantity--;
    }

    public int GetQuantity(){
        return quantity;
    }
}
