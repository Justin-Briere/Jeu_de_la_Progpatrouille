using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ActivatetimeLine : MonoBehaviour
{
    [SerializeField]
    PlayableDirector timeline;

    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject timelinePlayer;

    GameObject menuPause;

    GameObject music;
    AudioSource musicSound;

    AudioSource finalMusic;

    private void Start()
    {
        timeline = GetComponent<PlayableDirector>();
        finalMusic = GetComponent<AudioSource>();
        finalMusic.Play();
        finalMusic.Pause();

        menuPause = GameObject.Find("MenuPause");

        music = GameObject.Find("Music");
        musicSound = music.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.CompareTag("Player"))
        {
            musicSound.Stop();
            menuPause.SetActive(false);
            finalMusic.time = 3f;
            finalMusic.Play();
            timeline.gameObject.SetActive(true);
            timeline.Play();
            player.SetActive(false);
            timelinePlayer.SetActive(true);
        }
    }
}
