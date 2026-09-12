using UnityEngine;

public class CropSelector : MonoBehaviour
{
    public static CropSelector Instance { get; private set; }

    public CropType SelectedCrop { get; private set; }
    public CropType defaultCrop; // Assign this in the Inspector to Carrot crop

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        // Set the default crop at the start of the game
        if (defaultCrop != null)
        {
            SelectCrop(defaultCrop);
        }
        else
        {
            Debug.LogWarning("Default crop is not assigned in the Inspector!");
        }
    }

    public void SelectCrop(CropType crop)
    {
        SelectedCrop = crop;
        Debug.Log("Selected crop: " + crop.cropName);
    }
}