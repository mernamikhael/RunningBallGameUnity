using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndlessFloor : MonoBehaviour {
    public GameObject ground;
    public Text Scoretext;
    public static int score = 0;
    float offset = 0;
    public GameObject[] collectible;
    public GameObject[] light;
    public int NBrsphere;
    public static int sphereSoFar;
    float x = 0.1f + 0.1f * 0.1f;
    float number = 0;

    // Use this for initialization
    void Start () {
        sphereSoFar = 0;
        NBrsphere = 5;
        //spwanCollectible();
        spwanLight();
        x = 0.1f + 0.35f * Time.deltaTime;
    }

    // Update is called once per frame
    void Update () {

        Scoretext.text = "Score:" + score;
        Scoretext.fontSize = 25;

        if (pauseScript.GameIsPaused == true)
        {
           // x = 0;
        }
        else
        {

            // to double the score
            if (shpere.counter == 5)
            {
                x = 2 * x;
                shpere.counter = 0;
            }
            offset += x;

            //transfor el floor
            GameObject[] objs = GameObject.FindGameObjectsWithTag("floor");
            for (int i = 0; i < objs.Length; i++)
            {
                objs[i].transform.Translate(0, 0, -x);
            }

            objs = GameObject.FindGameObjectsWithTag("light");
            for (int i = 0; i < objs.Length; i++)
            {
                objs[i].transform.Translate(0, 0, -x);
            }

            //find sphere
            objs = GameObject.FindGameObjectsWithTag("collectible");
            for (int i = 0; i < objs.Length; i++)
            {
                objs[i].transform.Translate(0, 0, -x);
            }


            //finish one floor
            if (offset > 15)
            {
                offset -= 15;
                Instantiate(ground, new Vector3(0, 0, 45 - offset), Quaternion.identity);
            }

        }

        while (sphereSoFar < NBrsphere) { spwanCollectible(); }
    }


    void spwanCollectible()
    {

        int indexObj = Random.Range(0, 3);
        int timeIntervalLight = Random.Range(1, 4);
        int lane = Random.Range(-1, 2);
        if(number > 20)
        {
            number = 0;
            Instantiate(collectible[indexObj], new Vector3(lane, 0.5f, 45 - offset - number), Quaternion.identity);
        }
        else
        {
            number += 2;
            Instantiate(collectible[indexObj], new Vector3(lane, 0.5f, 45 - offset - number), Quaternion.identity);
        }
        sphereSoFar++;
        //Invoke("spwanCollectible", timeIntervalLight);
    }

    void spwanLight()
    {
        int indexObjLight = Random.Range(0, 3);
        int timeInterval = Random.Range(5, 15);
        Instantiate(light[indexObjLight], new Vector3(0f, 0.5f, 45 - offset), Quaternion.identity);
        Invoke("spwanLight", 10);
    }
}
