using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class L1TimeEvents : MonoBehaviour
{
    public event Action lightout;
    private float timePassed;
    private void Start()
    {
        
        StartCoroutine(lightsout());
    }


    IEnumerator lightsout()
    {
        yield return new WaitForSeconds(60);
        lightout?.Invoke();
    }
}
