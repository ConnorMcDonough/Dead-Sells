﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public GameObject target;
 

    // Update is called once per frame
    void Update()
    {
        if (target != null) 
        {
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
        }
    }
}
