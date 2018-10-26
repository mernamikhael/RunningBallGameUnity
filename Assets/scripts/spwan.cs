


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwan : MonoBehaviour
{
    float offset = 0;
    int score = 50;
    public GameObject[] light;
    public GameObject[] collectible;

    void Start()

    {
        spwanCollectible();
        spwanLight();
    }
    // Update is called once per frame
    void Update()
    {

        //float x = 0.1f + score * 0.1f * Time.deltaTime;
        //offset += x;

    }

    //void OnTriggerEnter(Collider c)
    //{
    //    if (c.transform.parent != null)
    //        Destroy(c.transform.parent.gameObject);
    //    else
    //    { Destroy(c.gameObject); }
    //}

    void spwanLight()
    {
        int indexObj = Random.Range(0, 3);
        int timeInterval = Random.Range(5, 15);
        Instantiate(light[indexObj], new Vector3(0f, 0.5f, 25), Quaternion.identity);
        Invoke("spwanLight", timeInterval);
    }

    void spwanCollectible()
    {
        int indexObj = Random.Range(0, 3);
        int timeIntervalLight = Random.Range(2, 5);
        int lane = Random.Range(-1, 2);
        Instantiate(collectible[indexObj], new Vector3(lane, 0.5f, 35), Quaternion.identity);
        Invoke("spwanCollectible", timeIntervalLight);
    }
}