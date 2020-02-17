using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    marioController MarioScript;
    public Camera Cameraself;
    void Start()
    {
        MarioScript = FindObjectOfType<marioController>();
    }

    // Update is called once per frame
    void Update()
    {
        CameraFollow(-20.5f, 16.26f);
    }
    void CameraFollow(float MinX, float MaxX)
    {
        //Vector2 v = MarioScript.Mario.transform.position;
        Cameraself.transform.position= new Vector3 (MarioScript.Mario.transform.position.x, Cameraself.transform.position.y, Cameraself.transform.position.z);
        if (MarioScript.Mario.transform.position.x > MaxX)
        {
            MarioScript.Mario.transform.position = new Vector2(MaxX, MarioScript.Mario.transform.position.y);
        }
        else if(MarioScript.Mario.transform.position.x < MinX)
        {
            MarioScript.Mario.transform.position = new Vector2(MinX, MarioScript.Mario.transform.position.y);
        }
    }
}
