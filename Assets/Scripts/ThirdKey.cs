using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ThirdKey : MonoBehaviour
{
    public GameObject thirdKey;
    int dir = 1;
    public GameObject canvas;
    public Animator animator;
    Ball ballScript;
    public bool keyMoveStatus = false;
    KeyImageManager keyImageManager;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = thirdKey.GetComponent<Animator>();
        ballScript = FindObjectOfType<Ball>();
        keyImageManager = FindObjectOfType<KeyImageManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //thirdKey.transform.Translate(Vector2.down * dir * 300f * Time.deltaTime);
        if (ballScript.keyShowStatus == true)
        {
            Invoke("KeyMove", 1f);
            keyMoveStatus = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        dir = -dir;
        if (collision.collider.tag == "ball")
        {
            SceneManager.LoadScene("Hao Yun");
            keyImageManager.thirdKeyImage.enabled = true;
        }
    }
    public void KeyMove()
    {
        thirdKey.transform.Translate(Vector2.down * dir * 300f * Time.deltaTime);
        //animator.SetBool("KeyMove", false);
        Destroy(animator);
        Debug.LogWarning("yun");
        //ballScript.Ball_rigidbody.velocity = Vector2.right * ballScript.speed;
    }

}
