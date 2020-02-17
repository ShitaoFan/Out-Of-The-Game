using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanController : MonoBehaviour
{
    // Start is called before the first frame update
    Renderer Rder1;
    Renderer Rder2;
    AudioSource fan;
    private Rigidbody rigidbody1;
    private Rigidbody characterRigidbody;
    public GameObject FanMainPart;
    public GameObject FanPart1;
    public GameObject Character;
    bool clickCondition = false;
    int moveSpeed = 500;
    public GameObject Floor;
    WallController WallScript;
    protected HighlightableObject ho;
    BoxCollider fanCollider;
    KeyImageManager keyImageManager;
    void Start()
    {
        Rder1 = FanMainPart.GetComponent<Renderer>();
        Rder2 = FanPart1.GetComponent<Renderer>();
        rigidbody1 = Floor.GetComponent<Rigidbody>();
        characterRigidbody = Character.GetComponent<Rigidbody>();
        WallScript = FindObjectOfType<WallController>();
        fan=GetComponent<AudioSource>();
        ho = gameObject.AddComponent<HighlightableObject>();
        keyImageManager = FindObjectOfType<KeyImageManager>();
    }

    // Update is called once per frame
    void Update()
    {
       if(clickCondition == true)
       {
            //for(int moveSpeed = 100; moveSpeed <=1000; moveSpeed += 100)
            transform.Rotate(Vector3.up * Time.deltaTime * moveSpeed);
       }
        if (keyImageManager.firstKeyImage.enabled == true && keyImageManager.secondKeyImage.enabled == true && keyImageManager.thirdKeyImage.enabled == true)
        {
            fanCollider = gameObject.AddComponent<BoxCollider>();
        }
    }
    void OnMouseDown()
    {
        if (clickCondition == false)
        {
            clickCondition = true;
            rigidbody1.useGravity = true;
            rigidbody1.isKinematic = false;
            characterRigidbody.constraints = ~RigidbodyConstraints.FreezePosition;
            //WallScript.WallRigidbody.AddForce(Vector3.up * 30f);
            transform.parent = WallScript.Wall.transform;
            //WallScript.Wall.transform.localPosition = Vector3.Lerp(WallScript.Wall.transform.localPosition, new Vector3(0.0f, 2000.0f, 0.0f), Time.deltaTime);
            WallScript.LerpCondition = false;
            fan.Play();
        }
        else
        {
            clickCondition = false;
            rigidbody1.useGravity = false;
            rigidbody1.isKinematic = true;
            characterRigidbody.constraints = RigidbodyConstraints.FreezePositionY|RigidbodyConstraints.FreezeRotationX|RigidbodyConstraints.FreezeRotationY|RigidbodyConstraints.FreezeRotationZ;
        }
        
    }
    void OnMouseEnter()
    {
        Rder1.material.EnableKeyword("_EMISSION");
        Rder2.material.EnableKeyword("_EMISSION");
        Debug.Log("emissiontest");
        ho.ConstantOn();
    }
    void OnMouseExit()
    {
        Rder1.material.DisableKeyword("_EMISSION");
        Rder2.material.DisableKeyword("_EMISSION");
        ho.ConstantOff();
    }
   
}
