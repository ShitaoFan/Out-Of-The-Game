using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeyImageManager : MonoBehaviour
{
    public Image firstKeyImage;
    public Image secondKeyImage;
    public Image thirdKeyImage;
    public Image ExitButton;
    cursortest cursorTest;
    // Start is called before the first frame update
    void Start()
    {
        firstKeyImage.enabled = false;
        secondKeyImage.enabled = false;
        thirdKeyImage.enabled = false;
        ExitButton.enabled = true ;
        cursorTest = FindObjectOfType<cursortest>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ExitToMain()
    {
        SceneManager.LoadScene("Hao Yun");
    }
}
