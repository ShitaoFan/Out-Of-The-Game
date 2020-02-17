using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FanTrigger : MonoBehaviour
{
    KeyImageManager keyImageManager;
    // Start is called before the first frame update
    void Start()
    {
        keyImageManager = FindObjectOfType<KeyImageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (keyImageManager.firstKeyImage.enabled == true && keyImageManager.secondKeyImage.enabled == true && keyImageManager.thirdKeyImage.enabled == true)
            SceneManager.LoadScene("Hao Yun");
    }
}
