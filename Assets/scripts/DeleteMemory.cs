﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteMemory : MonoBehaviour {

    void OnTriggerEnter(Collider c)
    {
        if (c.transform.parent != null)
            Destroy(c.transform.parent.gameObject);
        else
        { Destroy(c.gameObject); }
    }

}
