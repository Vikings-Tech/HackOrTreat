using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class L1JumpScareVideo : MonoBehaviour
{
    [SerializeField] private string videoTag = "videoScare";
    
    private void Update()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position,transform.forward, out hit))
        {
            var selection = hit.transform;
            VideoPlayer player = selection.GetComponent<VideoPlayer>();
            VideoPlaneMover mover = selection.GetComponent<VideoPlaneMover>();
            if (selection.CompareTag(videoTag))
            {
                if (!mover.played)
                {
                    hit.transform.localPosition = mover.position;
                    player.Play();
                    mover.played = true;
                }
            }
        }
    }
}
