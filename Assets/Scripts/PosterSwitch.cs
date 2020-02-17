using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosterSwitch : MonoBehaviour
{
    StartPoster startPosterScript;
    MiddlePoster middlePosterScript;
    SleepPoster sleepPosterScript;
    // Start is called before the first frame update
    void Start()
    {
        startPosterScript = FindObjectOfType<StartPoster>();
        middlePosterScript = FindObjectOfType<MiddlePoster>();
        sleepPosterScript = FindObjectOfType<SleepPoster>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
