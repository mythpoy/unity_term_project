﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObsHeight : MonoBehaviour
{
	public float speed = 1f;
	private GuiControl guiControl;
	private int randomStartDirection;
	private bool isUp;
   
    void Awake()
    {
        guiControl = GameObject.Find("GameManager").GetComponent<GuiControl>();
        speed += (guiControl.level / 3.0f);

        randomStartDirection = Random.Range(0, 2);

        if(randomStartDirection == 0){
            isUp = true;
        }
        else{
            isUp = false;
        }

        this.transform.position = new Vector3(this.transform.position.x, Random.Range(2.0f, 7.0f), this.transform.position.z);  

		}

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y < 2.0f) //아래쪽 닿으면 위로
            isUp = true;
            

        if(this.transform.position.y > 7.0f)  //위로 닿으면 아래로
            isUp = false;
        
        if(isUp)
        {
            this.transform.Translate(Vector3.up / 50 * speed);
        }
        else
        {
            this.transform.Translate(Vector3.down / 50 * speed);
        }
    }
}
