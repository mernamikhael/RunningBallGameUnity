using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndlessFloor : MonoBehaviour {
    public GameObject ground;
    public Text Scoretext;
    public static int score = 0;
    float offset = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Scoretext.text = "Score:" + score;
        Scoretext.fontSize = 25;
            float x = 0.1f + score * 0.1f * Time.deltaTime;
            offset += x;


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
}
