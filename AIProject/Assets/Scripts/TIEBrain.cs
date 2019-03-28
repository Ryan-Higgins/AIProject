using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TIEBrain : MonoBehaviour
{
    public GameObject destroyer;

    public GameObject leadX;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(leadX.transform.position, destroyer.transform.position) <= 500)
        {
            gameObject.GetComponent<Boid>().maxSpeed = 40;
        }
    }
}
