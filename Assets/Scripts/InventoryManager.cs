using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    private Dictionary<string, int> inventory = new Dictionary<string, int>();
    private Dictionary<string, int> sellValues = new Dictionary<string, int>();

    public int Currency { get; private set; } = 0;

    public CropType SelectedCrop { get; set; } = null;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void AddItem(string itemName, int amount, int sellValue)
    {
        if (!inventory.ContainsKey(itemName))
            inventory[itemName] = 0;

        inventory[itemName] += amount;
        sellValues[itemName] = sellValue;

        Debug.Log(itemName + ": " + inventory[itemName]);
    }

    public int GetAmount(string itemName)
    {
        return inventory.ContainsKey(itemName) ? inventory[itemName] : 0;
    }

    public void SellAll()
    {
        int totalEarned = 0;

        foreach (var kvp in inventory)
        {
            string itemName = kvp.Key;
            int amount = kvp.Value;
            int sellValue = sellValues.ContainsKey(itemName) ? sellValues[itemName] : 0;

            totalEarned += amount * sellValue;
        }
        inventory.Clear();
        Currency += totalEarned;

        Debug.Log("Sold everything for " + totalEarned + ". Total currency: " + Currency);
    }
}