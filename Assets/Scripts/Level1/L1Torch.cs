using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class L1Torch : MonoBehaviour
{
    public Sprite[] torchSprites;
    public Image torch;
    public GameObject camCoverCanvas;
    public GameObject camCoverBlack;
    public GameObject camCoverBig;
    public GameObject camCoverSmall;
    private static float _battery;
    private bool _torchIsOn = false;
    public GameObject[] batteryStick;
    private bool lightOut;
    private L1TimeEvents _l1TimeEvents;
    private void Start()
    {
        _battery = 600;
        lightOut = false;
        _l1TimeEvents = FindObjectOfType<L1TimeEvents>();
        _l1TimeEvents.lightout += lightOutEventCalled;
    }

    private void lightOutEventCalled()
    {
        lightOut = true;
        camCoverCanvas.SetActive(true);
        torchOff();
    }
    public void torchToggle()
    {
        if (lightOut)
        {
            if (_torchIsOn)
            {
                torchOff();
            }
            else
            {
                torchOn();
            }
        }
    }
    public void torchOn()
    {
        torch.sprite = torchSprites[1];
        _torchIsOn = true;
        if (_battery > 200)
        {
            camCoverBig.SetActive(true);
            camCoverBlack.SetActive(false);
            camCoverSmall.SetActive(false);
        }
        else if (_battery > 0)
        {
            camCoverBig.SetActive(false);
            camCoverBlack.SetActive(false);
            camCoverSmall.SetActive(true);
        }
        else
        {
            camCoverBig.SetActive(false);
            camCoverSmall.SetActive(false);
            camCoverBlack.SetActive(true);
        }
    }

    public void torchOff()
    {
        torch.sprite = torchSprites[0];
        _torchIsOn = false;
        camCoverBig.SetActive(false);
        camCoverSmall.SetActive(false);
        camCoverBlack.SetActive(true);
    }
    void Update()
    {
        if (_torchIsOn)
        {
            _battery -= Time.deltaTime;
            Debug.Log(_battery);
            if (_battery < 480)
            {
                batteryStick[0].SetActive(false);
            }

            if (_battery < 360)
            {
                batteryStick[1].SetActive(false);
            }

            if (_battery < 240)
            {
                batteryStick[2].SetActive(false);
            }

            if (_battery < 120)
            {
                batteryStick[3].SetActive(false);
            }

            if (_battery <= 0)
            {
                batteryStick[4].SetActive(false);
            }
        }

        if (_battery < 200 && _torchIsOn)
        {
            camCoverBig.SetActive(false);
            camCoverSmall.SetActive(true);
        }
        
          
    }
}
