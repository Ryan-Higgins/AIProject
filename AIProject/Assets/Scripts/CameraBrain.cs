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
    public GameObject lasers;
    public GameObject ties;
    public List<GameObject> fleet;
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
            StartCoroutine(Warp());
        }
    }

    IEnumerator Warp()
    {
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

    IEnumerator InWarp()
    {
        yield return new WaitForSeconds(2);
        StartCoroutine(LeaveWarp());
    }
    
    IEnumerator LeaveWarp()
    {
       
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
        yield return new WaitForSeconds(3);
        for (int i = 0; i < fleet.Count; i++)
        {
         fleet[i].SetActive(true);
        }

        StartCoroutine(GrowFleet());
    }

    IEnumerator GrowFleet()
    {
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
