using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public GameObject Wall;
    public Rigidbody WallRigidbody;
    public bool LerpCondition = false;
    // Start is called before the first frame update
    void Start()
    {
        WallRigidbody = Wall.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(LerpCondition == false)
        {
            WallLerp();
        }
    }
    void WallLerp()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0.0f, 2000.0f, 0.0f), Time.deltaTime * 0.01f);
    }
}
