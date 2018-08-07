using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour {

    public GameObject itemPrefab;
    public GameObject slotPrefab;
    public GameObject player;
    public PlayerHealth playerHealth;
    public PlayerHunger playerHunger;

    public int inventoryFull = 0;

    public Text[] textList = new Text[16];
    public Item2[] itemsList = new Item2[16];
    public Transform[] slotsList = new Transform[16];
    public int[] amountsList = new int[16];

    void Start () {
        //initialize playerHealth and playerHunger
        playerHealth = player.GetComponent<PlayerHealth>();
        playerHunger = player.GetComponent<PlayerHunger>();

        //Create slots
        for (int i = 0; i < 16; i++)
        {
            GameObject slotInstance = Instantiate(slotPrefab);
            slotInstance.transform.SetParent(this.gameObject.transform, false);
            slotsList[i] = slotInstance.transform;
        }
        //Fill up itemsList with empty Items
        for (int i = 0; i < itemsList.Length; i++)
        {
            Item2 emptyItem = new Item2();
            itemsList[i] = emptyItem;
        }
    }

    public void AddItem(int id, string title, string description, int health, int food, bool consumable, int stackMax)
    {
        for (int i = 0; i < itemsList.Length; i++)   //adding on to a stackable slot
        {
            if (itemsList[i].id == id && amountsList[i] < stackMax)
            {
                amountsList[i]++;
                Text getText = textList[i];
                getText.text = amountsList[i].ToString();
                return;
            }
        }
        for (int i = 0; i < itemsList.Length; i++)   //starting a new slot because item didnt previously exist in inventory or it did but it already reached its stackMax
        {
            if (itemsList[i].id == 0)
            {
                Item2 newItem = new Item2(id, title, description, health, food, consumable, stackMax);
                itemsList[i] = newItem;
                amountsList[i] = 1;
                GameObject itemInstance = Instantiate(itemPrefab);
                itemInstance.transform.SetParent(slotsList[i], false);
                InventoryItem inventoryItem = itemInstance.GetComponent<InventoryItem>();
                inventoryItem.initializeValues(id, title, description, health, food, consumable, stackMax);
                Text child = itemInstance.transform.GetChild(0).gameObject.GetComponent<Text>();
                textList[i] = child;
                child.text = amountsList[i].ToString();
                return;
            }
        }
    }

    public bool UseItem(Transform transform)
    {
        for (int i = 0; i < slotsList.Length; i++)   //find which slot this item is in
        {
            if (slotsList[i] == transform)          //by using the transform as the common factor
            {
                amountsList[i]--;
                Text aText = textList[i];
                playerHealth.AddHealth(itemsList[i].health);
                playerHunger.AddHunger(itemsList[i].food);
                if (amountsList[i] == 0)
                {
                    itemsList[i] = new Item2();  //create empty item
                    amountsList[i] = 0;
                    aText.text = amountsList[i].ToString();  //i dont really think this is actually necessary
                    return true;
                }
                aText.text = amountsList[i].ToString();
            }
        }
        return false;
    }

}

public struct Item2
{
    public int id;
    public string title;
    public string description;
    public int health;
    public int food;
    public bool consumable;
    public int stackMax;

    public Item2(int id, string title, string description, int health, int food, bool consumable, int stackMax)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.health = health;
        this.food = food;
        this.consumable = consumable;
        this.stackMax = stackMax;
    }
}