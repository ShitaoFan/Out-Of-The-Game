using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Folder : MonoBehaviour
{
    KeyImageManager keyImageManager;
    public GameObject key1;
    public GameObject key2;
    public GameObject key3;
    public GameObject folder;
    public GameObject bin;
    int showBin = 0;

    // Start is called before the first frame update
    void Start()
    {
        keyImageManager = FindObjectOfType<KeyImageManager>();
        ShowKey();
    }

    // Update is called once per frame
    void Update()
    {
        if (showBin >= 3)
        {

            folder.SetActive(false);
            bin.SetActive(true);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "key1")
        {
            key1.SetActive(false);
            Debug.Log("鼠标碰撞");
            showBin++;
        }
        if (collision.gameObject.tag == "key2")
        {
            key2.SetActive(false);
            Debug.Log("鼠标碰撞");
            showBin++;
        }
        if (collision.gameObject.tag == "key3")
        {
            key3.SetActive(false);
            Debug.Log("鼠标碰撞");
            showBin++;
        }
    }
    void ShowKey()
    {
        if(keyImageManager.firstKeyImage.enabled == true)
        {
            key1.SetActive(true);
        }
        if (keyImageManager.secondKeyImage.enabled == true)
        {
            key2.SetActive(true);
        }
        if (keyImageManager.thirdKeyImage.enabled == true)
        {
            key3.SetActive(true);
        }
    }
}
