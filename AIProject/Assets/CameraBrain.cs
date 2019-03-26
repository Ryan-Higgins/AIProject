using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBrain : MonoBehaviour
{
    public List<GameObject> cams;
    public GameObject frigate;
        
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
    }
}
