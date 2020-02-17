using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource playerSound;
    public GameObject player;
    void Start()
    {
        playerSound = player.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySound(string name)
    {
        AudioClip Clip = Resources.Load<AudioClip>(name);
        //资源库中寻找 —————实用
        playerSound.PlayOneShot(Clip);
        //PlayOneShot() can control volume;
    }
    public void StopSound()
    {
        playerSound.Stop();
    }
}
