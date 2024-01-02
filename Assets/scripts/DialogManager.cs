using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;
    [SerializeField] int lettersPerSecond;

    public static DialogManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        CloseDialog(); // Make sure the dialog is closed at the start
    }

    public void ShowDialog(Dialog dialog)
    {
        dialogBox.SetActive(true);

        // Check if the dialog has any lines before trying to access them
        if (dialog.Lines != null && dialog.Lines.Count > 0)
        {
            StartCoroutine(TypeDialog(dialog.Lines[0]));
        }
        else
        {
            Debug.LogWarning("Dialog has no lines.");
        }
    }

    public IEnumerator TypeDialog(string line)
    {
        dialogText.text = "";
        foreach (var letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
    }

    public void CloseDialog()
    {
        dialogBox.SetActive(false);
    }
}
