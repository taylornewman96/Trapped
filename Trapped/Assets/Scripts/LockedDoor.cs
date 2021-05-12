using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LockedDoor : MonoBehaviour
{

    [SerializeField] private Key.KeyType keyType;
    [SerializeField] private KeyCode openDoorKey = KeyCode.F;
    private Animator doorAnim;
    private bool contact;

    private bool doorOpen = false;

    void Start()
    {
        doorAnim = gameObject.GetComponent<Animator>();
    }

    public Key.KeyType GetKeyType()
    {
        return keyType;
    }

    public void Open()
    {
        if(contact && !doorOpen)
        {
            doorAnim.SetBool("open", true);
            doorOpen = true;
        }
        
    }
    // Start is called before the first frame update
    
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            contact = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
