﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RExplosionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject,0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
