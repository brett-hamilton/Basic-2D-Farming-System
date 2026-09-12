using UnityEngine;
using UnityEngine.UI;

public class CropToggleUI : MonoBehaviour
{
    public CropType cropType;

    public void OnToggleSelected(bool isOn)
    {
        if (isOn)
        {
            CropSelector.Instance.SelectCrop(cropType);
        }
    }
}