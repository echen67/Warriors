using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

    public int id;
    public string title;
    public string description;
    public int health;
    public int food;
    public bool consumable;
    public int stackMax;

    public GameObject inventoryUI;
    public InventoryPanel inventoryPanel;

    void Awake()
    {
        inventoryUI = GameObject.FindGameObjectWithTag("Inventory");
        inventoryPanel = inventoryUI.GetComponent<InventoryPanel>();

        id = 1;
        title = "fish";
        description = "Yum!";
        health = 0;
        food = 10;
        consumable = true;
        stackMax = 4;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inventoryPanel.AddItem(id, title, description, health, food, consumable, stackMax);
            Destroy(gameObject);
        }
    }

}
