using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBrain : MonoBehaviour
{
    public List<GameObject> cams;
    public GameObject frigate;
    public GameObject leadFighter;
    public GameObject destroyer;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(frigate.transform.position, frigate.GetComponent<FollowPath>().path.waypoints[1]) <= 2)
        {
            cams[0].SetActive(false);
            cams[1].SetActive(true);
        }

        if (Vector3.Distance(leadFighter.transform.position, destroyer.transform.position) <= 750)
        {
            cams[1].SetActive(false);
            cams[2].SetActive(true);
        }

        if (Vector3.Distance(leadFighter.transform.position, destroyer.transform.position) <= 600)
        {
            cams[2].SetActive(false);
            cams[3].SetActive(true);
        }

    }
}
