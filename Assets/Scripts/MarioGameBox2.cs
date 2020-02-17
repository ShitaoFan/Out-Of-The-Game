using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioGameBox2 : MonoBehaviour
{
    MarioGameBox marioScript;
    protected HighlightableObject ho;
    public Renderer rder1;
    public GameObject marioGameBox2;
    TVController tvScript;
    // Start is called before the first frame update
    void Start()
    {
        ho = gameObject.AddComponent<HighlightableObject>();
        rder1 = marioGameBox2.GetComponent<Renderer>();
        marioScript = FindObjectOfType<MarioGameBox>();
        tvScript = FindObjectOfType<TVController>();
    }

    // Update is called once per frame
    void Update()
    {
        //rder1.material.EnableKeyword("_EMISSION");
        ho.FlashingOn();
    }
    void OnMouseDown()
    {
        marioScript.marioGameBox2.SetActive(false);
        tvScript.tvScreen.SetActive(true);
        tvScript.tvScreen2.SetActive(false);
        tvScript.tvScreen3.SetActive(false);
        Debug.Log("消失吧，马里奥");
    }
}
