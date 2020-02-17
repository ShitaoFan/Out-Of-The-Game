using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pillowController : MonoBehaviour
{
    public Renderer BedRder1;
    public Renderer BedRder2;
    public Renderer BedRder3;
    public GameObject Bed1;
    public GameObject Bed2;
    public GameObject Bed3;
    // Start is called before the first frame update
    void Start()
    {
        BedRder1 = Bed1.GetComponent<Renderer>();
        BedRder2 = Bed2.GetComponent<Renderer>();
        BedRder3 = Bed3.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseEnter()
    {
        BedRder1.material.EnableKeyword("_EMISSION");
        BedRder2.material.EnableKeyword("_EMISSION");
        BedRder3.material.EnableKeyword("_EMISSION");
    }
    void OnMouseExit()
    {
        BedRder1.material.DisableKeyword("_EMISSION");
        BedRder2.material.DisableKeyword("_EMISSION");
        BedRder3.material.DisableKeyword("_EMISSION");
    }
}
