using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoStart : MonoBehaviour
{
    public GameObject universalMediaPlayer;
    void Start()
    {
        universalMediaPlayer = GameObject.Find("UniversalMediaPlayer");
        universalMediaPlayer.SetActive(false);
    }

    public void StartClick()
    { 
        universalMediaPlayer.SetActive(true);

    }

    public void StopClick()
    {
        universalMediaPlayer.SetActive(false);

    }
}
