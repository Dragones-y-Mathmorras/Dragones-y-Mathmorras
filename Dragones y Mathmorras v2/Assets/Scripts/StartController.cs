using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    //Para el audio
    private AudioSource audioPlayer; //la componente de Audio
    public AudioClip musicAudio; //la cancion

    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        audioPlayer.clip = musicAudio;
        audioPlayer.volume = 0.1f;
        PlayMusic();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            GameObject.Find("MusicObject").GetComponent<MusicContinue>().PlayMainTheme(); //al clicar donde sea se crea el objeto musica que nunca se destruye y se reproduce 
            SceneManager.LoadScene("MenuScene");
        }
    }
    public void PlayMusic()
    {
        if (audioPlayer.isPlaying) return;
        audioPlayer.Play();
    }
}
