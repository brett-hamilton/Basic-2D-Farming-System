using UnityEngine;
using TMPro;

public class CurrencyDisplay : MonoBehaviour
{
    public TextMeshProUGUI currencyText;

    void Update()
    {
        currencyText.text = "Coins: " + InventoryManager.Instance.Currency;
    }
}