using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioEnemy : MonoBehaviour
{
    public int hp = 10;
    public GameObject enemy;
    int dir = 1;
    Animator ani;
    AudioManager audioManager;
    void Start()
    {
        ani = enemy.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <=0 )
        {
            ani.SetTrigger("die");
            Destroy(enemy, 1f);
            audioManager.PlaySound("踩敌人");
        }
        transform.Translate(Vector2.right * dir * 1f * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        dir = -dir;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            hp -= hp;
            Destroy(enemy.GetComponent<Collider2D>());
            Destroy(enemy.GetComponent<Rigidbody2D>());
            ani.SetTrigger("die");
            Destroy(enemy, 1f);
            audioManager.PlaySound("踩敌人");
        }
    }
}
