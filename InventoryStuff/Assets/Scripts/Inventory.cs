using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> items;

    // constructor
    public Inventory(){
        items = new List<Item>();
    }

    public void AddItem(Item newItem){
       // Item existing = items.Find(x=> x.itemName == newItem.itemName);
       Item existing = FindItem(newItem.itemName);

        if(existing == null){
            items.Add(newItem);
            MonoBehaviour.print("New item added");
        }
        else{ // if item already exists then just add 1 to the count
            
            existing.AddOne();

            MonoBehaviour.print("Added one");
        }
        
    }

    public void RemoveItem(string name){
        Item existing = FindItem(name);

        if(existing != null){
            items.RemoveAll(x=> x.itemName == name);
        }
    }

    public Item FindItem(string name){
        Item itemFound = items.Find(x=> x.itemName == name);

        return itemFound;
    }

    public string GetInventoryList(){
        string output = "Inventory: ";
        foreach(Item x in items){
            output += "\n" + x.itemName + " : " + x.GetQuantity() + "."; 
        }

        return output;
    }
}
