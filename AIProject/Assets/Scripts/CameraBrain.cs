using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraBrain : MonoBehaviour
{
    //Everything we need to keep track of in the scene
    public List<GameObject> cams;
    public GameObject tieLeader;
    public GameObject frigate;
    public GameObject leadFighter;
    public GameObject destroyer;
    public GameObject lasers;
    public GameObject ties;
    public List<GameObject> fleet;
    private bool firstSwitch = false;
    private bool secondSwitch = false;
    private bool thirdSwitch = false;
    private bool fourthSwitch = false;

    void Update()
    {
        //Checking distance of the Nebulon-B frigate to its second waypoint
        if (Vector3.Distance(frigate.transform.position, frigate.GetComponent<FollowPath>().path.waypoints[1]) <= 2 && !firstSwitch)
        {
            cams[0].SetActive(false);
            cams[1].SetActive(true);
            //These switches keep the cameras from switching back and forth.
            firstSwitch = true;
        }
        //Checking the distance of the Lead X-Wing to the VSDI
        if (Vector3.Distance(leadFighter.transform.position, destroyer.transform.position) <= 750 && !secondSwitch)
        {
            cams[1].SetActive(false);
            cams[2].SetActive(true);
            secondSwitch = true;
        }
        //Same as above just with less distance
        if (Vector3.Distance(leadFighter.transform.position, destroyer.transform.position) <= 600 && !thirdSwitch)
        {
            cams[2].SetActive(false);
            cams[3].SetActive(true);
            thirdSwitch = true;
        }
        //Checking the position of the First Tie fighter on the path. 
        if (Vector3.Distance(tieLeader.transform.position, tieLeader.GetComponent<FollowPath>().path.waypoints[6]) <= 25 && !fourthSwitch)
        {
            cams[3].SetActive(false);
            cams[4].SetActive(true);
            fourthSwitch = true;   
            StartCoroutine(Warp());
        }
    }

    IEnumerator Warp()
    {
        //Timer started for the battle to end.
        yield return new WaitForSeconds(28);
        cams[4].SetActive(false);
        cams[5].SetActive(true);
        yield return new WaitForSeconds(1);
        destroyer.SetActive(false);
        lasers.SetActive(false);
        ties.SetActive(false);
        StartCoroutine(EnterWarp());
    }

    IEnumerator EnterWarp()
    {
        //Giving the illusion of warp through camera FOV
        yield return new WaitForSeconds(0);
        if (cams[5].GetComponent<Camera>().fieldOfView < 179)
        {
            cams[5].GetComponent<Camera>().fieldOfView++;
            StartCoroutine(EnterWarp());
        }
        else
        {
            StartCoroutine(InWarp());
        }
        
    }

    //Delay on exit warp.
    IEnumerator InWarp()
    {
        yield return new WaitForSeconds(2);
        StartCoroutine(LeaveWarp());
    }
    
    IEnumerator LeaveWarp()
    {
        //Returning FOV to normal
        yield return new WaitForSeconds(0);
        if (cams[5].GetComponent<Camera>().fieldOfView >= 60)
        {
            cams[5].GetComponent<Camera>().fieldOfView--;
            StartCoroutine(LeaveWarp());
        }

        frigate.GetComponent<Boid>().maxSpeed = 0;
        StartCoroutine(Fleet());
    }

    IEnumerator Fleet()
    {
        //Setting the VSDIs to active
        yield return new WaitForSeconds(3);
        for (int i = 0; i < fleet.Count; i++)
        {
         fleet[i].SetActive(true);
        }

        StartCoroutine(GrowFleet());
    }

    IEnumerator GrowFleet()
    {
        //Growing the VSDIs scale to give illusion of warping in
        yield return new WaitForSeconds(0f);
        for (int i = 0; i < fleet.Count; i++)
        {
            if (fleet[i].transform.localScale.x < 1)
            {
                fleet[i].transform.localScale = new Vector3(fleet[i].transform.localScale.x + 0.4f,fleet[i].transform.localScale.y + 0.4f, fleet[i].transform.localScale.z + 0.4f);
            }
        }
        StartCoroutine(GrowFleet());
    }
}
