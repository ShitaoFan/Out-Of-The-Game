using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball: MonoBehaviour
{
    public float speed = 50;
    public GameObject ball;
    public GameObject LeftPlayer;
    public GameObject RightPlayer;
    public GameObject thirdKey;
    public Rigidbody2D Ball_rigidbody;
    public playersController LeftPlayerScript;
    public playersController RightPlayerScript;
    public GameObject canvas;
    ThirdKey thirdKeyScript;
    AudioSource key;
    public bool keyShowStatus = false;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        Ball_rigidbody = ball.GetComponent<Rigidbody2D>();
        //LeftPlayerScript = FindObjectOfType<playersController>();
        //RightPlayerScript = FindObjectOfType<playersController>();
        //LeftPlayerScript = GameObject.Find("LeftPlayer").GetComponent<playersController>();
        ballmove();
        thirdKeyScript = FindObjectOfType<ThirdKey>();
        animator = thirdKey.GetComponent<Animator>();
        key = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (RightPlayerScript.score >= 10)
        {
            Invoke("ShowKey", 1f);
        }
    }
    void ballmove()
    {
        if(Random.Range(-1, 2) > 0)
        {
            Ball_rigidbody.velocity = Vector2.right * speed;
        }
        else
        {
            Ball_rigidbody.velocity = Vector2.left * speed;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Leftplayer")
        {
            float y = HitPosition(ball.transform.position, other.transform.position, other.collider.bounds.size.y);
            Vector2 ball_direction = new Vector2(-1, y).normalized;
            Ball_rigidbody.velocity = ball_direction * speed;
            Debug.Log("撞到了A");
            RightPlayerScript.Addscore();
        }
        else if (other.gameObject.name == "Rightplayer")
        {
            float y = HitPosition(ball.transform.position, other.transform.position, other.collider.bounds.size.y);
            Vector2 ball_direction = new Vector2(1, y).normalized;
            Ball_rigidbody.velocity = ball_direction * speed;
            Debug.Log("撞到了B");
            RightPlayerScript.Addscore();
        }
        else if (other.gameObject.name == "LeftBorder")
        {
            ball.transform.position = new Vector2(0.0f, 0.0f);
            RightPlayerScript.score = 0;
            ballmove();
            Debug.Log("撞左面");
        }
        else if (other.gameObject.name == "RightBorder")
        {
            ball.transform.position = new Vector2(0.0f, 0.0f);
            //LeftPlayerScript.Addscore();
            RightPlayerScript.score = 0;
            ballmove();
            Debug.Log("撞右面");
        }
        else if(thirdKeyScript.keyMoveStatus == true)
        {
            Ball_rigidbody.velocity = Vector2.right * speed;
        }
    }
    float HitPosition(Vector2 ballPos, Vector2 racketPos, float racketHight)
    {
        return (ballPos.y - racketPos.y) / racketHight;
    }
    void ShowKey()
    {
        thirdKey.SetActive(true);
        canvas.SetActive(false);
        animator.SetTrigger("keyMove");
        keyShowStatus = true;
        key.Play();
    }
}
