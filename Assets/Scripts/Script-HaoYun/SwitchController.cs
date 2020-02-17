using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    // Start is called before the first frame update
    Renderer Rder;
    public GameObject Switch;
    public GameObject topLight;
    void Start()
    {
        Rder = Switch.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseEnter()
    {
        Rder.material.EnableKeyword("_EMISSION");
    }
    void OnMouseExit()
    {
        Rder.material.DisableKeyword("_EMISSION");
    }
    void OnMouseDown()
    {

        topLight.SetActive(!topLight.activeSelf);
        Debug.Log("1111");
    }
}
