using System.Collections.Generic;
using UnityEngine;

public class BarrierDisable : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;

    private Collider2D playerCol;
    private readonly HashSet<Collider2D> ignored = new HashSet<Collider2D>();

    private void Awake()
    {
        playerCol = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (playerMovement.isDashing)
        {
            IgnoreAllBarriers();
        }
        else
        {
            RestoreAll();
        }
    }

    private void IgnoreAllBarriers()
    {
        Collider2D[] allColliders = FindObjectsOfType<Collider2D>();

        foreach (var col in allColliders)
        {
            if (col == null) continue;
            if (!col.CompareTag("barrier")) continue;  //if tag is not barrier, skip
            if (ignored.Contains(col)) continue;

            Physics2D.IgnoreCollision(playerCol, col, true);
            ignored.Add(col);
        }
    }

    private void RestoreAll()
    {
        foreach (var col in ignored) 
        {
            if (col != null)
                Physics2D.IgnoreCollision(playerCol, col, false); // Restore collision
        }

        ignored.Clear();
    }
}