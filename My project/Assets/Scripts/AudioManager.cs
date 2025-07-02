using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Sound Effects")]
    public AudioClip rippleSFX;
    public AudioClip moveSFX;
    public AudioClip obstacleHitSFX;
    public AudioClip collectibleSFX;
    public AudioClip buttonClickSFX;
    public AudioClip gameOverSFX;

    private AudioSource sfxSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            
            sfxSource = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
            sfxSource.PlayOneShot(clip);
    }

    //temp solution for pitch value
    public void PlaySFXWithPitch(AudioClip clip, float pitch)
    {
        if (clip == null) return;

        GameObject tempGO = new GameObject("TempAudio"); // Temporary GameObject
        AudioSource aSource = tempGO.AddComponent<AudioSource>();

        aSource.clip = clip;
        aSource.pitch = pitch;
        aSource.Play();

        Destroy(tempGO, clip.length / pitch); // Destroy after the sound finishes
    }

}
