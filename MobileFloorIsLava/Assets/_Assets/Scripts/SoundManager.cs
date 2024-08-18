using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip jumpSound;
    static AudioSource AudioSrc;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("Jump");

        AudioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeMusic(AudioClip music)
    {
        source.Stop();
        source.clip = music;
        source.Play();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Jump":
                AudioSrc.PlayOneShot(jumpSound);
                break;


        }
    }
}
