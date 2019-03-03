﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPManager : MonoBehaviour
{

    public GameObject player;
    public Vector3 coordNorth;
    public Vector3 coordSouth;
    public Vector3 coordEast;
    public Vector3 coordWest;

    public AudioSource tpAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        TPtoNorth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TPtoSouth()
    {
        player.transform.SetPositionAndRotation(coordSouth, Quaternion.Euler(0,0,0));
        tpAudioSource.Play();
    }

    public void TPtoNorth()
    {
        player.transform.SetPositionAndRotation(coordNorth, Quaternion.Euler(0, 180, 0));
        tpAudioSource.Play();
    }

    public void TPtoEast()
    {
        player.transform.SetPositionAndRotation(coordEast, Quaternion.Euler(0, 270, 0));
        tpAudioSource.Play();
    }

    public void TPtoWest()
    {
        player.transform.SetPositionAndRotation(coordWest, Quaternion.Euler(0, 90, 0));
        tpAudioSource.Play();
    }

}
