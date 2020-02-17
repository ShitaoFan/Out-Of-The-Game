using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playersController : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D player_rigidbody;
    public string vertical;
    public int score = 0;
    public Text Text_score;
    // Start is called before the first frame update
    void Start()
    {
        player_rigidbody = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move(300f);
        Text_score.text = "SCORE:" + score + "/10";
    }
    public void Move(float speed)
    {
        float v = Input.GetAxis(vertical);
        player_rigidbody.velocity = new Vector2(0, v) * speed;
    }
    public void Addscore()
    {
        score += 1;
    }
}
