using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManger : MonoBehaviour
{
    KeyImageManager keyImageManager;
    public bool firstKey = false;
    public bool secondKey = false;
    public bool thirdKey = false;
    // Start is called before the first frame update
    void Start()
    {
        keyImageManager = FindObjectOfType<KeyImageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
