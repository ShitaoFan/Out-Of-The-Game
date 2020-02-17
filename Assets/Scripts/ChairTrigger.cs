using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairTrigger : MonoBehaviour
{
    TriggerManager triggerManager;
    Chair chairScript;
    // Start is called before the first frame update
    void Start()
    {
        triggerManager = FindObjectOfType<TriggerManager>();
        chairScript = FindObjectOfType<Chair>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Character")
        {
            triggerManager.chairTriggerCondition = true;
            //chairScript.chairUsedCondition = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Character")
        {
            triggerManager.chairTriggerCondition = false;
            //chairScript.chairUsedCondition = false;
        }
    }
}
