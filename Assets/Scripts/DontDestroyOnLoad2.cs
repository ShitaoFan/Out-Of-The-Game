using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad2 : MonoBehaviour
{
    public GameObject outOfGame;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(outOfGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
