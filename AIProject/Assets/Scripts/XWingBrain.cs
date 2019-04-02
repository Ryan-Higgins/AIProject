using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XWingBrain : MonoBehaviour
{
    private Animator myAnim;

    private GameObject destroyer;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponentInChildren<Animator>();
        destroyer = GameObject.Find("VSDI");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, destroyer.transform.position) <= 850)
        {
            myAnim.SetBool("InRange", true);
        }
    }
}
