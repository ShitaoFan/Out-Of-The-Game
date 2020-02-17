using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    AudioSource falling;
    public GameObject Eye;
    public Rigidbody CharacterRigidbody;
    public int moveSpeed = 40;
    // Start is called before the first frame update
    void Start()
    {
        CharacterRigidbody = GetComponent<Rigidbody>();
        falling = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        TankUpdate();
        transfromLimit();
        UseGravity();
        //HorizontalMove(Input.GetAxis("Horizontal"));
        //VerticalMove(Input.GetAxis("Vertical"));
    }
    private void TankUpdate()
    {
        if (Input.GetAxis("Mouse X") != 0)
        {
            //Debug.Log(Input.GetAxis("Mouse X"));
            if (Input.GetAxis("Mouse X") < 0.1f && Input.GetAxis("Mouse X") > -0.1f)
            {
                // return;
            }
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * Time.fixedDeltaTime * 200, 0));
            //clearArrow(false);
        }
        if (Input.GetAxis("Mouse Y") != 0)
        {
            if (Input.GetAxis("Mouse Y") < 0.1f && Input.GetAxis("Mouse Y") > -0.1f)
            {
                //bug.Log("Mouse Y");
                //  return;
            }
            Eye.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * Time.fixedDeltaTime * -200, 0, 0));

        }
        //}
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKeyUp(KeyCode.W)&& Input.GetKeyUp(KeyCode.S)&& Input.GetKeyUp(KeyCode.A)&& Input.GetKeyUp(KeyCode.D))
        {
            CharacterRigidbody.velocity = Vector3.zero;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Vector3.right * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {

        }
    }
    void transfromLimit()
    {
        /*if (transform.position.x < -1094.5f)
        {
            transform.position = new Vector3(-1094.5f, transform.position.y, transform.position.z);
        }
        if (transform.position.z < 411.81f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 411.81f);
        }
        if (transform.position.z > 505.93f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 505.93f);
        }
        if (transform.position.x > -906.8f)
        {
            transform.position = new Vector3(-906.8f, transform.position.y, transform.position.z);
        }*/
        if (Eye.transform.eulerAngles.x > 80f & Eye.transform.eulerAngles.x <= 180f)
        {
            Eye.transform.eulerAngles = new Vector3(80f, transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }
    public void UseGravity()
    {
        if (transform.position.x < -1135.19f | transform.position.z < 84.91f)
        {
            moveSpeed = 80;
            //CharacterRigidbody.useGravity = true;
            CharacterRigidbody.constraints = ~RigidbodyConstraints.FreezePosition;
            falling.Play();
            Debug.Log("超过界限");
            CharacterRigidbody.velocity = new Vector3(CharacterRigidbody.velocity.x,0.0f, CharacterRigidbody.velocity.z);
        }
    }
    void HorizontalMove(float horizontal)
    {

        if (horizontal != 0)
        {
            CharacterRigidbody.velocity = new Vector3(-horizontal * 100.0f, CharacterRigidbody.velocity.x);
            Debug.Log("right");
        }
    }
    void VerticalMove(float veritical)
    {

        if (veritical != 0)
        {
            CharacterRigidbody.velocity = new Vector3(veritical * 100.0f, CharacterRigidbody.velocity.z);
            Debug.Log("forward");
        }
    }
}
