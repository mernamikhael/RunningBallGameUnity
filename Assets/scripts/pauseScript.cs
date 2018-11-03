using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseScript : MonoBehaviour {

    public static bool GameIsPaused = false;
    public GameObject pauseMenu;
    public AudioSource pauseSound;
    public AudioSource background;
    // Use this for initialization
    void Start () {
     

    }
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetKeyDown(KeyCode.Escape))&& (shpere.GameOver == false))
        {
            if (GameIsPaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
	}
   public void resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        pauseSound.Stop();
        background.Play();
    }

    public void pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        background.Stop();
        pauseSound.Play();
    }

    public void quit()
    {
        Application.Quit();

    }

    public void restart()
    {
        SceneManager.LoadScene("Game");
        resume();
        EndlessFloor.score = 0;
        shpere.GameOver = false;
    }
}
