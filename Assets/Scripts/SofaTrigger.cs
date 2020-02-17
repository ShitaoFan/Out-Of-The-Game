using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofaTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    TriggerManager triggerManager;
    void Start()
    {
        triggerManager = FindObjectOfType<TriggerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Character")
        {
            triggerManager.sofaTriggerCondition = true;
            //chairScript.chairUsedCondition = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Character")
        {
            triggerManager.sofaTriggerCondition = false;
            //chairScript.chairUsedCondition = false;
        }
    }
}
