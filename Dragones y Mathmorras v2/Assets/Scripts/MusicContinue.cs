using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicContinue : MonoBehaviour
{
    //Para el tema del audio
    private AudioSource audioPlayer;
    public AudioClip musicAudio;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayMainTheme()
    {
        DontDestroyOnLoad(transform.gameObject);
        audioPlayer = GetComponent<AudioSource>();
        audioPlayer.clip = musicAudio;

        if (audioPlayer.isPlaying) return;
        audioPlayer.Play();
    }
}
