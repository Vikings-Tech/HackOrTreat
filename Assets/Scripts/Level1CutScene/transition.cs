﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transition : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject tt;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tt.activeSelf)
        {
            
            SceneManager.LoadScene("Level1");
        }
    }
}
