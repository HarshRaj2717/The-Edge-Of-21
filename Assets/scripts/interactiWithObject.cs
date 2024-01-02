using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractWithObject : MonoBehaviour
{
    [SerializeField] Dialog dialog;
    public Canvas OptionCanvas; // Reference to the OptionCanvas with buttons
    public Button button1; // Reference to the first button on the canvas
    public Button button2; // Reference to the second button on the canvas

    private void Start()
    {
        // Disable the OptionCanvas and buttons on start
        OptionCanvas.enabled = false;
        button1.interactable = false;
        button2.interactable = false;

        // Add onClick listeners to the buttons (replace the methods with your actual methods)
        button1.onClick.AddListener(Button1Clicked);
        button2.onClick.AddListener(Button2Clicked);
    }

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

            // Enable the OptionCanvas and buttons
            if (OptionCanvas != null)
            {
                OptionCanvas.enabled = true;
                button1.interactable = true;
                button2.interactable = true;
            }
            else
            {
                Debug.LogError("OptionCanvas is null. Make sure to assign it in the inspector.");
            }

            // You might want to disable the collider temporarily to avoid triggering the dialogue multiple times
            // GetComponent<Collider2D>().enabled = false;
        }
    }

    private void Button1Clicked()
    {
        // Handle the action when the first button is clicked
        Debug.Log("Button 1 clicked");
    }

    private void Button2Clicked()
    {
        // Handle the action when the second button is clicked
        Debug.Log("Button 2 clicked");
    }
}
