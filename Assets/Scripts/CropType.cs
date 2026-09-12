using UnityEngine;

[CreateAssetMenu(fileName = "NewCrop", menuName = "Farming/Crop Type")]
public class CropType : ScriptableObject
{
    public string cropName = "Carrot";
    public float growthTime = 5f;
    public int sellValue = 10;
    public Color grownColor = Color.red; // placeholder visual until sprites are created
}