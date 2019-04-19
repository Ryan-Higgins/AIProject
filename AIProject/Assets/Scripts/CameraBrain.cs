using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBrain : MonoBehaviour
{
    public List<GameObject> cams;
    public GameObject tieLeader;
    public GameObject frigate;
    public GameObject leadFighter;
    public GameObject destroyer;
    private bool firstSwitch = false;
    private bool secondSwitch = false;
    private bool thirdSwitch = false;
    private bool fourthSwitch = false;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(frigate.transform.position, frigate.GetComponent<FollowPath>().path.waypoints[1]) <= 2 && !firstSwitch)
        {
            cams[0].SetActive(false);
            cams[1].SetActive(true);
            firstSwitch = true;
        }

        if (Vector3.Distance(leadFighter.transform.position, destroyer.transform.position) <= 750 && !secondSwitch)
        {
            cams[1].SetActive(false);
            cams[2].SetActive(true);
            secondSwitch = true;
        }

        if (Vector3.Distance(leadFighter.transform.position, destroyer.transform.position) <= 600 && !thirdSwitch)
        {
            cams[2].SetActive(false);
            cams[3].SetActive(true);
            thirdSwitch = true;
        }

        if (Vector3.Distance(tieLeader.transform.position, tieLeader.GetComponent<FollowPath>().path.waypoints[6]) <= 25 && !fourthSwitch)
        {
            cams[3].SetActive(false);
            cams[4].SetActive(true);
            fourthSwitch = true;
        }

    }
}
