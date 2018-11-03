using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class shpere : MonoBehaviour {
    //public Transform point;
    public static int counter=0;
    public GameObject pauseMenu;
    public AudioSource pause;
    public AudioSource matchBall;
    public AudioSource diffBall;
    public AudioSource background;
    public AudioSource colorChange;
    public static bool GameOver = false;
    public bool android;

    // Use this for initialization
    void Start () {

        background.Play();
        if(Application.platform == RuntimePlatform.Android)
        {
            android = true;
        }else
        {
            android = false;
        }

	}
	
	// Update is called once per frame
	void Update () {
        if (android == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (pauseScript.GameIsPaused)
                {
                    transform.Translate(0, 0, 0);
                }
                else
                {
                    if (transform.position.x > -1)
                        transform.Translate(-1, 0, 0);

                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (pauseScript.GameIsPaused)
                { transform.Translate(0, 0, 0); }
                else
                {
                    if (transform.position.x < 1)
                        transform.Translate(1, 0, 0);
                }
            }
        }
        else
        {
            //if(Input.acceleration.x > -1 || Input.acceleration.x <1)
            //transform.Translate(Input.acceleration.x * 0.2f, 0, 0);
            if (Input.acceleration.x < -0.2 && transform.position.x > -1)
            {
                transform.Translate(Input.acceleration.x * 0.2f, 0, 0);
            }
            if (Input.acceleration.x > 0.2 && transform.position.x < 1)
            {
                transform.Translate(Input.acceleration.x * 0.2f, 0, 0);
            }
        }

       
    }

    //game over

    void OnTriggerEnter(Collider c)
    {
        if(c.CompareTag("collectible"))
        {
            EndlessFloor.sphereSoFar--;
            if(gameObject.GetComponent<Renderer>().material.color== c.GetComponent<Renderer>().material.color)
            {
                EndlessFloor.score += 10;
                counter++;
                matchBall.Play();
            }
            else
            {
                EndlessFloor.score /= 2;
                diffBall.Play();
                if(EndlessFloor.score<=0)
                {
                    pauseMenu.SetActive(true);
                    UnityEngine.UI.Button button = GameObject.Find("resume").GetComponent<UnityEngine.UI.Button>();
                    button.interactable = false;
                    pauseScript.GameIsPaused = true;
                    background.Stop();
                    pause.Play();
                    GameOver = true;
                }
            }

            Destroy(c.gameObject);
        }
        if(c.CompareTag("light"))
        {
            gameObject.GetComponent<Renderer>().material.color = c.GetComponent<Light>().color;
            colorChange.Play();
        }
    }
}
