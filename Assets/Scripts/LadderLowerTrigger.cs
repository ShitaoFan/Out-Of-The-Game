using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderLowerTrigger : MonoBehaviour
{
    BedController bedScript;
    TriggerManager triggerManager;
    // Start is called before the first frame update
    void Start()
    {
        bedScript = FindObjectOfType<BedController>();
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
            triggerManager.ladderTriggerCondition = true;
            //chairScript.chairUsedCondition = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Character")
        {
            triggerManager.ladderTriggerCondition = false;
            //chairScript.chairUsedCondition = false;
        }
    }
}
