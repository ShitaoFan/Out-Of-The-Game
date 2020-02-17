using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyBoxTrigger : MonoBehaviour
{
    TriggerManager triggerManager;
    // Start is called before the first frame update
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
            triggerManager.toyboxTriggerCondition = true;
            //chairScript.chairUsedCondition = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Character")
        {
            triggerManager.toyboxTriggerCondition = false;
            //chairScript.chairUsedCondition = false;
        }
    }
}
