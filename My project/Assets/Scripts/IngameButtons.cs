using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameButtons : MonoBehaviour
{

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
