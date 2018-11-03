using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadScene : MonoBehaviour {
    public AudioSource background;
    public AudioSource pause;
    public Text buttonText;
    void Start()
    {
        pause.Play();
    }
    public void ButtonClick()
    {
        pause.Stop();
        background.Play();
        SceneManager.LoadScene("Game");
    }

    public void mute() {
        AudioListener.pause = !AudioListener.pause;
        if (AudioListener.pause == false)
        { buttonText.text = "Mute"; }
        else
        { buttonText.text = "UnMute"; }
    }
}
