using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameParticle : MonoBehaviour
{
    public GameObject modelObject;
    public GameObject flameObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // float flameX = 
        flameObject.transform.localScale = modelObject.transform.localScale / 21.5f;
    }
}
