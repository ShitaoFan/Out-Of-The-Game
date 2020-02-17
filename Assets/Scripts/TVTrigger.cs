using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVTrigger : MonoBehaviour
{
    MarioGameBox marioGameBox;
    TriggerManager triggerManager;
    TVController tvScript;
    // Start is called before the first frame update
    void Start()
    {
        triggerManager = FindObjectOfType<TriggerManager>();
        marioGameBox = FindObjectOfType<MarioGameBox>();
        tvScript = FindObjectOfType<TVController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Character")
        {
            triggerManager.tvTriggerCondition = true;
            //chairScript.chairUsedCondition = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Character")
        {
            triggerManager.tvTriggerCondition = false;
            //chairScript.chairUsedCondition = false;
            tvScript.ConstantOff();
        }
    }
}
