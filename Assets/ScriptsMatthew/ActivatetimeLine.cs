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

    private void Start()
    {
        timeline = GetComponent<PlayableDirector>();
    }
    private void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.CompareTag("Player"))
        {
            timeline.gameObject.SetActive(true);
            timeline.Play();
            player.SetActive(false);
            timelinePlayer.SetActive(true);
        }
    }
}
