using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameButtons : MonoBehaviour
{
    void Update()
{
    if (Input.GetKeyDown(KeyCode.Space))
    {
        // Code to execute when the space key is pressed down
        Debug.Log("Space key was pressed down!");
        Restart();
    }
}

    public void Restart()
    {
        Debug.Log("Restart button pressed.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
