using UnityEngine;

public class musicManager : MonoBehaviour
{
    public AudioSource introMusic;
    bool introDone;
    private AudioSource thisMusic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisMusic = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        introDone = !introMusic.isPlaying;
        if (introDone)
        {
            playMusic();
        }
    }

    void playMusic()
    {
        if (!thisMusic.isPlaying)
        {
            thisMusic.Play();
        }
    }
}
