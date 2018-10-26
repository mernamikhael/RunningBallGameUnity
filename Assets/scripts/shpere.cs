using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class shpere : MonoBehaviour {
    //public Transform point;

    // Use this for initialization
    void Start () {
       // gameObject.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(transform.position.x > -1)
            {
                transform.Translate(-1, 0, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(transform.position.x < 1)
            transform.Translate(1, 0, 0);
        }
    }

    //game over

    void OnTriggerEnter(Collider c)
    {
        if(c.CompareTag("collectible"))
        {  
            if(gameObject.GetComponent<Renderer>().material.color== c.GetComponent<Renderer>().material.color)
            {
                EndlessFloor.score += 10;
            }
            else
            {
                EndlessFloor.score /= 2;
                if(EndlessFloor.score<=0)
                {
                    SceneManager.LoadScene("pause");
                }
            }

            Destroy(c.gameObject);
        }
        if(c.CompareTag("light"))
        {
            gameObject.GetComponent<Renderer>().material.color = c.GetComponent<Light>().color;
        }
    }
}
