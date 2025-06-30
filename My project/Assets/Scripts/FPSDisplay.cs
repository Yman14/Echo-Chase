using UnityEngine;
using TMPro; // Required for TextMeshPro

public class FPSDisplay : MonoBehaviour
{
    public float updateInterval = 0.5f; // How often to update the FPS
    private float accum = 0; // FPS accumulated over the interval
    private int frames = 0; // Frames drawn over the interval
    private float timeleft; // Left time for current interval
    private TextMeshProUGUI fpsText; // Reference to the Text component

    void Start()
    {
        if (GetComponent<TextMeshProUGUI>() != null)
        {
            fpsText = GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Debug.LogError("FPSDisplay: No TextMeshProUGUI component found on this GameObject. Please add one or use the standard Text component.");
            enabled = false; // Disable the script if no Text component is found
            return;
        }
        timeleft = updateInterval;
    }

    void Update()
    {
        timeleft -= Time.deltaTime;
        accum += Time.timeScale / Time.deltaTime;
        ++frames;

        if (timeleft <= 0.0)
        {
            // display two fractional digits (f2 format)
            float fps = accum / frames;
            string format = System.String.Format("{0:F2} FPS", fps);
            fpsText.text = format;

            if (fps < 30)
            {
                fpsText.color = Color.yellow;
            }
            else if (fps < 10)
            {
                fpsText.color = Color.red;
            }
            else
            {
                fpsText.color = Color.green;
            }

            timeleft = updateInterval;
            accum = 0.0f;
            frames = 0;
        }
    }
}