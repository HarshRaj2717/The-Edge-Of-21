using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithObject : MonoBehaviour
{
    [SerializeField] Dialog dialog;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (DialogManager.Instance != null)
            {
                DialogManager.Instance.ShowDialog(dialog);
            }
            else
            {
                Debug.LogError("DialogManager is null.");
            }

            // You might want to disable the collider temporarily to avoid triggering the dialogue multiple times
            // GetComponent<Collider2D>().enabled = false;
        }
    }
}
