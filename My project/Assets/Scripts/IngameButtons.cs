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

    public void GodPOV()
    {
        //SFX
        ButtonSFX();

        Debug.Log("GodPOV button pressed.");
    }

    public void Restart()
    {
        //SFX
        ButtonSFX();

        Debug.Log("Restart button pressed.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void CheatMode()
    {
        //SFX
        ButtonSFX();

        Debug.Log("CheatMode button pressed.");

    }

    private void ButtonSFX()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClickSFX);
    }
}
