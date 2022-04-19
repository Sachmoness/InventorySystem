using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    float speed = 7f;
    Inventory playerInventory;

    int HealthCount = 50;

    public Text healthText;
    public Text inventoryText;

    // Start is called before the first frame update
    void Start()
    {
        playerInventory = new Inventory();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        UseHealth();

        healthText.text = "Health = " + HealthCount;
        inventoryText.text = playerInventory.GetInventoryList();
    }

    void Move(){
        if(Input.GetKey(KeyCode.A)){
            transform.Translate(Vector2.left*speed*Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.D)){
            transform.Translate(Vector2.right*speed*Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.W)){
            transform.Translate(Vector2.up*speed*Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.S)){
            transform.Translate(Vector2.down*speed*Time.deltaTime);
        }
    }

    void UseHealth(){
        if(Input.GetKeyDown(KeyCode.H)){

            Item HealthPack = playerInventory.FindItem("Health");

            if(HealthPack != null && HealthPack.GetQuantity() > 0){
                HealthCount += 10;
                HealthPack.UseOne(); // take 1 pack out of the inventory

                if(HealthPack.GetQuantity() == 0){
                    playerInventory.RemoveItem("Health"); // remove health pack from inventory if we have no more left.
                }
            }
            else{
                print("Out of Health Packs!");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Health"){
           
            playerInventory.AddItem(new Item("Health",100,1));
            Destroy(other.gameObject);
        }
    }
}
