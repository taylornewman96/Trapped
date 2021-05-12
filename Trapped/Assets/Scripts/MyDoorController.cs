using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDoorController : MonoBehaviour
{

    [SerializeField] private KeyCode openDoorKey = KeyCode.F;

    private Animator doorAnim;

    private bool contact;

    private bool doorOpen = false;
    public float timer;


    void Start()
    {
        doorAnim = gameObject.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            contact = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            contact = false;
        }
    }

    void Update()
    {
    
        if(contact && !doorOpen && Input.GetKeyDown(openDoorKey))
        {
            
            doorAnim.SetBool("open", true);
            doorOpen = true;
            timer = 5.0f;
        }

        if(doorOpen)
        {
            timer -= Time.deltaTime;

        }

        if(timer <= 0.0f)
            {
                doorAnim.SetBool("open", false);
                doorOpen = false;  
                timer = 5.0f;
            }
    
        
    }

    /*public void PlayAnimation()
    {
        if(!doorOpen)
        {
            doorAnim.Play("DoorOpen", 0, 0.0f);
            doorOpen = true;
        }
        else
        {
            doorAnim.Play("DoorClose", 0, 0.0f);
            doorOpen = false;
        }
    }
    */
}
