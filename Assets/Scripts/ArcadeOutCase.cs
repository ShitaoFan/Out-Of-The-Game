using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeOutCase : MonoBehaviour
{
    public GameObject arcadeOutCase;
    public Renderer rder;
    protected HighlightableObject ho;
    // Start is called before the first frame update
    void Start()
    {
        rder = arcadeOutCase.GetComponent<Renderer>();
        ho = gameObject.AddComponent<HighlightableObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MouseIn()
    {
        rder.material.EnableKeyword("_EMISSION");
        ho.ConstantOn();
    }
    public void MouseOut()
    {
        rder.material.DisableKeyword("_EMISSION");
        ho.ConstantOff();
    }
}
