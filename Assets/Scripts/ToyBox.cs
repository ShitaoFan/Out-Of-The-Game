using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyBox : MonoBehaviour
{
    FirstKey firstKeyScript;
    protected HighlightableObject ho;
    TriggerManager triggerManager;
    public Renderer boxRder;
    public Renderer rder1;
    public Renderer rder2;
    public Renderer rder3;
    public Renderer rder4;
    public Renderer rder5;
    public Renderer rder6;
    public Renderer rder7;
    public GameObject toyBox;
    public GameObject toy1;
    public GameObject toy2;
    public GameObject toy3;
    public GameObject toy4;
    public GameObject toy5;
    public GameObject toy6;
    public GameObject toy7;
    AudioSource key;
    // Start is called before the first frame update
    void Start()
    {
        ho = gameObject.AddComponent<HighlightableObject>();
        boxRder = toyBox.GetComponent<Renderer>();
        rder1 = toy1.GetComponent<Renderer>();
        rder2 = toy2.GetComponent<Renderer>();
        rder3 = toy3.GetComponent<Renderer>();
        rder4 = toy4.GetComponent<Renderer>();
        rder5 = toy5.GetComponent<Renderer>();
        rder6 = toy6.GetComponent<Renderer>();
        rder7 = toy7.GetComponent<Renderer>();
        triggerManager = FindObjectOfType<TriggerManager>();
        firstKeyScript = FindObjectOfType<FirstKey>();
        key =GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerManager.toyboxTriggerCondition == false)
        {
            boxRder.material.DisableKeyword("_EMISSION");
            rder1.material.DisableKeyword("_EMISSION");
            rder2.material.DisableKeyword("_EMISSION");
            rder3.material.DisableKeyword("_EMISSION");
            rder4.material.DisableKeyword("_EMISSION");
            rder5.material.DisableKeyword("_EMISSION");
            rder6.material.DisableKeyword("_EMISSION");
            rder7.material.DisableKeyword("_EMISSION");
            ho.Off();
        }
    }
    private void OnMouseDown()
    {
        if (triggerManager.toyboxTriggerCondition == true)
        {
            firstKeyScript.glowing();
            triggerManager.toyboxTriggerCondition = false;
            firstKeyScript.showCondition = true;
            key.Play();
        }
    }
    void OnMouseOver()
    {
        if (triggerManager.toyboxTriggerCondition == true)
        {
            boxRder.material.EnableKeyword("_EMISSION");
            rder1.material.EnableKeyword("_EMISSION");
            rder2.material.EnableKeyword("_EMISSION");
            rder3.material.EnableKeyword("_EMISSION");
            rder4.material.EnableKeyword("_EMISSION");
            rder5.material.EnableKeyword("_EMISSION");
            rder6.material.EnableKeyword("_EMISSION");
            rder7.material.EnableKeyword("_EMISSION");
            ho.ConstantOn();
        }
    }
    void OnMouseExit()
    {
        boxRder.material.DisableKeyword("_EMISSION");
        rder1.material.DisableKeyword("_EMISSION");
        rder2.material.DisableKeyword("_EMISSION");
        rder3.material.DisableKeyword("_EMISSION");
        rder4.material.DisableKeyword("_EMISSION");
        rder5.material.DisableKeyword("_EMISSION");
        rder6.material.DisableKeyword("_EMISSION");
        rder7.material.DisableKeyword("_EMISSION");
        ho.Off();
    }
}
