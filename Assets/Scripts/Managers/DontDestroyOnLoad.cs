using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public GameObject managers;
    public GameObject keyImages;
    public GameObject Cursor;
    void Start()
    {
        if (managers == null) // Is the variable 'laptopCamera' empty?
        {
            managers = GameObject.FindGameObjectWithTag("Managers");
        }
        DontDestroyOnLoad(managers);
        DontDestroyOnLoad(keyImages);
        DontDestroyOnLoad(Cursor);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
