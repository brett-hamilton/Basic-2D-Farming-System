using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactRange = 1.5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    void TryInteract()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactRange);

        Plot closest = null;
        float closestDist = Mathf.Infinity;

        foreach (var hit in hits)
        {
            Plot plot = hit.GetComponent<Plot>();
            if (plot != null)
            {
                float dist = Vector2.Distance(transform.position, plot.transform.position);
                if (dist < closestDist)
                {
                    closestDist = dist;
                    closest = plot;
                }
            }
        }

        if (closest != null)
        {
            closest.Interact();
        }
        else
        {
            Debug.Log("No plot in range");
        }
    }
}