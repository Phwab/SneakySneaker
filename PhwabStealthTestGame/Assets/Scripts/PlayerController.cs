using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 targetLoc;
    public float speed = 4f;
    public float timeLeft = 0f; 
    public bool lockedMovment = false;
    void Start()
    {
        targetLoc = new Vector3(transform.position.x,transform.position.y,transform.position.z);
    }
    void FixedUpdate()
    {
        movmentTypeC();
        
    }

    void movmentTypeA()
    {
    if(Vector3.Distance(targetLoc,transform.position) <= .25f && (Mathf.Abs(Input.GetAxisRaw("Horizontal")) <= 0.05f) && (Mathf.Abs(Input.GetAxisRaw("Vertical")) <= 0.05f))
        {
        lockedMovment = false;
        }
    else if ((lockedMovment == false) && ((Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1) || (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)))
        {
        if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                targetLoc += new Vector3((Input.GetAxisRaw("Horizontal")),0f,0f);
                lockedMovment = true;
                
            } 
        else if(Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                targetLoc += new Vector3(0f,(Input.GetAxisRaw("Vertical")),0f);
                lockedMovment = true;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, targetLoc,speed*Time.deltaTime);
    }

    void movmentTypeB()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetLoc,speed*Time.deltaTime);
        if(Vector3.Distance(targetLoc,transform.position) <= 0.25f)
        {
            if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                targetLoc += new Vector3((Input.GetAxisRaw("Horizontal")),0f,0f);
                
            }
            
            else if(Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                targetLoc += new Vector3(0f,(Input.GetAxisRaw("Vertical")),0f);

            }
            else if(Vector3.Distance(targetLoc,transform.position) <= 0f)
            {
            transform.position += Vector3.zero;
            }
        }    
    }

    void movmentTypeC()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetLoc,speed*Time.deltaTime);
        if(timeLeft - Time.deltaTime > 0f)
        {
        timeLeft -= Time.deltaTime;
        lockedMovment = true;
        }
        else
        {
            timeLeft = 0;
            lockedMovment = false;
        }

        if(Vector3.Distance(targetLoc,transform.position) <= 0.25f && lockedMovment == false)
        {
            if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                targetLoc += new Vector3((Input.GetAxisRaw("Horizontal")),0f,0f);
                timeLeft = 1/speed;
            }
            
            else if(Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                targetLoc += new Vector3(0f,(Input.GetAxisRaw("Vertical")),0f);
                timeLeft = 1/speed;

            }
        }
    }
}
