using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    [SerializeField] private KeyType keytype;

    public enum KeyType
    {
        schoolRoom,
        final,
        level2,
        winDoor
    }
    
    public KeyType GetKeyType()
    {
        return keytype;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
