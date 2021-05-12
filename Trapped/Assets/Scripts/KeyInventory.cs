using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeyInventory : MonoBehaviour
{
    private List<Key.KeyType> keyList;
    public string sceneName;
    public AudioSource audio;
    public AudioClip keyPickup;
   
    // Start is called before the first frame update
    void Start()
    {
        keyList = new List<Key.KeyType>();
    }

    public void AddKey(Key.KeyType keytype)
    {
        Debug.Log("Added Key: " + keytype);
        audio.Play();
        keyList.Add(keytype);
    }

    public void RemoveKey(Key.KeyType keytype)
    {
        keyList.Remove(keytype);
    }

    public bool ContainsKey(Key.KeyType keytype)
    {
        return keyList.Contains(keytype);
    }

    private void OnTriggerEnter(Collider collider)
    {
        Key key = collider.GetComponent<Key>();
        if(key != null) 
        {
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);

        } 

        LockedDoor lockedDoor = collider.GetComponent<LockedDoor>();
        if(lockedDoor != null)
        {
            if(ContainsKey(lockedDoor.GetKeyType()))
            {
                lockedDoor.Open();
                if(lockedDoor.tag == "Final")
                {
                    SceneManager.LoadScene(sceneName);
                }
            }
                
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
