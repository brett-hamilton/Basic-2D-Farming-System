using Unity.VisualScripting;
using UnityEngine;

public class Plot : MonoBehaviour
{
    public PlotState state = PlotState.Empty;
    public CropType cropType; // Reference to the CropType ScriptableObject

    private SpriteRenderer sr;
    private Coroutine growthCoroutine;


    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        UpdateVisual();
    }

    public void SetState(PlotState newState)
    {
        state = newState;
        UpdateVisual();
    }

    public void Interact()
    {
        CycleState();
    }

    private void CycleState()
    {
        switch (state)
        {
            case PlotState.Empty:   
                SetState(PlotState.Tilled); 
                break;
            case PlotState.Tilled:
                CropType selected = CropSelector.Instance.SelectedCrop;
                if (selected == null)
                {
                    Debug.LogWarning("No crop selected!");
                    return;
                }
                cropType = selected;
                SetState(PlotState.Planted);
                StartGrowing();
                break;
            case PlotState.Planted: 
                Debug.Log("Can't harvest yet, still growing...");
                break;
            case PlotState.Grown:   
                Harvest();
                break;
        }
    }

    void StartGrowing()
    {
        if (growthCoroutine != null)
        {
            StopCoroutine(growthCoroutine);
        }
        growthCoroutine = StartCoroutine(GrowOverTime());
    }

    System.Collections.IEnumerator GrowOverTime()
    {
        yield return new WaitForSeconds(cropType.growthTime);
        SetState(PlotState.Grown);
    }

    void Harvest()
    {
        InventoryManager.Instance.AddItem(cropType.cropName, 1, cropType.sellValue);
        SetState(PlotState.Empty);
    }

    void UpdateVisual()
    {
        switch (state)
        {
            case PlotState.Empty:   sr.color = Color.green; break;
            case PlotState.Tilled:  sr.color = new Color(0.55f, 0.35f, 0.2f); break; // brown
            case PlotState.Planted: sr.color = Color.yellow; break;
            case PlotState.Grown:   sr.color = cropType != null ? cropType.grownColor : Color.red; break;
        }
    }
}
