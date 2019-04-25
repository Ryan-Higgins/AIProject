using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TIEBrain : MonoBehaviour
{
    public GameObject destroyer;

    public GameObject leadX;

    public List<GameObject> fighters;

    private Pursue pur;
    private FollowPath myPath;
    private bool notChosen = false;
    public GameObject explosion;
    public bool canAttack;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject x in GameObject.FindGameObjectsWithTag("X-Wing"))
        {
            fighters.Add(x);
        }

        myPath = GetComponent<FollowPath>();
        pur = GetComponent<Pursue>();
        pur.target = fighters[Random.Range(0, fighters.Count)].GetComponent<Boid>();
    }

    // Update is called once per frame
    void Update()
    {
        print("My next: " + myPath.path.next);
        if (Vector3.Distance(leadX.transform.position, destroyer.transform.position) <= 500 && myPath.enabled)
        {
            gameObject.GetComponent<Boid>().maxSpeed = 40;
        }

        if (Vector3.Distance(transform.position, myPath.path.waypoints[6]) <= 25 && !notChosen)
        {
            gameObject.GetComponent<Boid>().maxSpeed = 80;
            gameObject.GetComponent<Boid>().damping = 0.01f;
            gameObject.GetComponent<Boid>().maxForce = 40;
            myPath.enabled = false;
            pur.enabled = true;
            
            notChosen = true;
            canAttack = true;
            this.transform.parent = GameObject.Find("TIE Parent").gameObject.transform;
        }
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(Random.Range(50f, 70f));
        GameObject bang = GameObject.Instantiate(explosion, gameObject.transform.position, explosion.transform.rotation);
        bang.transform.SetParent(GameObject.Find("Explosions").transform);
        Destroy(gameObject);
    }
}
