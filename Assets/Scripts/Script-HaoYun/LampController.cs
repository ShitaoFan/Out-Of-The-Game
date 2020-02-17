using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LampController : MonoBehaviour
{
    // Start is called before the first frame update

    Renderer Rder1;
    Renderer Rder2;
    public GameObject bigLamp1;
    public GameObject bigLamp2;
    public GameObject lampLight;
    protected HighlightableObject ho;
    void Start()
    {
        Rder1 = bigLamp1.GetComponent<Renderer>();
        Rder2 = bigLamp2.GetComponent<Renderer>();
        ho = gameObject.AddComponent<HighlightableObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        lampLight.SetActive(!lampLight.activeSelf);
        SceneManager.LoadScene("Hao Yun");

    }
    void OnMouseEnter()
    {
        Rder1.material.EnableKeyword("_EMISSION");
        Rder2.material.EnableKeyword("_EMISSION");
        ho.ConstantOn();
    }
    void OnMouseExit()
    {
        Rder1.material.DisableKeyword("_EMISSION");
        Rder2.material.DisableKeyword("_EMISSION");
        ho.Off();
    }
}
