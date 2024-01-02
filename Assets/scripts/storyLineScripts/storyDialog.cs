using UnityEngine;
using UnityEngine.UI;

public class StoryDialogBoxManager : MonoBehaviour
{
    // Tag for identifying dialog boxes
    public string dialogBoxTag = "StoryDialog";

    // Index to track the currently active dialog box
    private GameObject activeDialogBox;

    private void Start()
    {
        // Initialize the active dialog box
        activeDialogBox = null;
    }

    public void ActivateDialog(string dialogTag)
    {
        // Deactivate the currently active dialog box
        DeactivateCurrentDialog();

        // Find the dialog box with the specified tag
        GameObject[] dialogBoxes = GameObject.FindGameObjectsWithTag(dialogBoxTag);
        foreach (GameObject dialogBox in dialogBoxes)
        {
            if (dialogBox.CompareTag(dialogTag))
            {
                // Activate the specified dialog box
                dialogBox.SetActive(true);
                activeDialogBox = dialogBox;
                break;
            }
        }
    }

    public void ChangeText(string newText)
    {
        // Ensure there is an active dialog box
        if (activeDialogBox != null)
        {
            // Change the text on the active dialog box
            Text dialogText = activeDialogBox.GetComponentInChildren<Text>();
            if (dialogText != null)
            {
                dialogText.text = newText;
            }
        }
    }

    private void DeactivateCurrentDialog()
    {
        // Deactivate the currently active dialog box, if any
        if (activeDialogBox != null)
        {
            activeDialogBox.SetActive(false);
        }
    }
}
