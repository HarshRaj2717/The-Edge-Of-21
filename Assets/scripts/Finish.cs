using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

using Pink_1_namespace;

public class Finish : MonoBehaviour
{
    private bool isStoryComplete = false;
    private bool storyStarted = false;

    void setIsStoryComplete(bool val = false)
    {
        isStoryComplete = val;
    }

    private void Start()
    {

    }

    void Update()
    {
        if (!storyStarted)
        {
            storyStarted = true;
            StoryRunner();
        }
    }

    async void StoryRunner()
    {
        await Task.Run(() =>
            {
                Pink_1_story story = new();
                bool val = story.Pink_1_runner();
                setIsStoryComplete(val);
            }
        );
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isStoryComplete)
            return;
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Player entered the finish zone");

            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
