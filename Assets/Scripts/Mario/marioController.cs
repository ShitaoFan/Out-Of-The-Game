using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class marioController : MonoBehaviour
{
    // Start is called before the first frame update
    public int HP = 10;
    public GameObject Mario;
    public GameObject SecondKey;
    public Rigidbody2D Mariorigidbody2D;
    Animator animator;
    bool isGround = true;
    AudioManager AudioManager;
    KeyImageManager keyImageManager;
    void Start()
    {
        Mariorigidbody2D = Mario.GetComponent<Rigidbody2D>();
        animator = Mario.GetComponent<Animator>();
        AudioManager = FindObjectOfType<AudioManager>();
        keyImageManager = FindObjectOfType<KeyImageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (HP <= 0)
        {
            return;
        }*/

        HorizontalMove(Input.GetAxis("Horizontal"));
        Jump();

    }
    void HorizontalMove(float horizontal)
    {

        if (horizontal != 0)
        {
            //Vector2 v = Mariorigidbody2D.velocity;
            Mariorigidbody2D.velocity = new Vector2(horizontal * 1.0f, Mariorigidbody2D.velocity.y);
            //与transfor 区别 无抖动
            Debug.Log("平移");
            /*Vector2 v = Mariorigidbody2D.velocity;
            v.x = horizontal * 1;
            Mariorigidbody2D.velocity = v;*/
            if (horizontal > 0)
            {
                Mario.transform.localScale = new Vector2(2.0f, 2.0f);
            }

            if (horizontal < 0)
            {
                Mario.transform.localScale = new Vector2(-2.0f, 2.0f);
            }
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }
    }
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Mariorigidbody2D.AddForce(Vector2.up * 200f);
            AudioManager.PlaySound("跳");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            isGround = true;
            animator.SetBool("isJump", false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isGround = false;
            animator.SetBool("isJump", true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "enemy")
        {
            HP -= HP;
            if (HP <= 0)
            {
                animator.SetTrigger("diedie");
                Mariorigidbody2D.AddForce(Vector2.up * 200f);
                //Destroy(GetComponent<CapsuleCollider2D>());
                Mariorigidbody2D.velocity = Vector2.zero;
                Invoke("again", 1f);
                AudioManager.PlaySound("死亡2");
            }
        }
        if (collision.collider.tag == "Key")
        {
            Debug.Log("transfor");
            SceneManager.LoadScene("Hao Yun");
            SecondKey.SetActive(false);
            AudioManager.PlaySound("win");
            keyImageManager.secondKeyImage.enabled = true;
        }
    }
    void again()
    {
        Mario.transform.position = new Vector2(-15f, -0.64f);
        animator.SetTrigger("isStand");
    }

}
