﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    private Animator anim;
    private bool moving = false;
    private int countLetters;
    private float position = 0;
    private Vector3 moveTo;
    public float botSpeed;
    public GameObject platform;
    public GameObject botPlatformEnd;
    private float time = 0;
    private float currLetter = 0;
    // Start is called before the first frame update
    void Start()
    {
        countLetters = string.Join(" ", FindObjectOfType<CreatePlatformWithLetters>().letters).Length;
        anim = this.GetComponent<Animator>();
        moveTo = this.transform.position;
        position = botPlatformEnd.transform.position.z - 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<Moving>().start) time += Time.deltaTime;
        if(currLetter<countLetters)
        if (time > botSpeed) 
        {
                currLetter++;
            Instantiate(platform, new Vector3(botPlatformEnd.transform.position.x, botPlatformEnd.transform.position.y, position), Quaternion.Euler(0, 0, 0));
            moveTo = new Vector3(botPlatformEnd.transform.position.x, this.transform.position.y, position);
            position -= .5f;
            time = 0;
        }
        Move(moveTo);
        AnimateBot();
    }
    void Move(Vector3 toPosition)
    {
        if (Vector3.Distance(this.transform.position, toPosition) > 0.1) moving = true; else moving = false;
        transform.position = Vector3.Lerp(this.transform.position, toPosition, 0.1f);
    }
    void AnimateBot()
    {
        if (moving) anim.SetBool("run", true);
        else anim.SetBool("run", false);
    }
}
