using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // This function will be called when the button is clicked
    public void LoadScene(bool isTrue)
    {
        if (isTrue) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }
}
