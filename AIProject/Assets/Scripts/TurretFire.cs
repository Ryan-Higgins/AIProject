using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFire : MonoBehaviour
{
    public List<GameObject> barrels;
    public GameObject laserPrefab;
    private int muzzle;
    private Animator myAnim;
    public Boid vsdi;
    private bool canFire;
    public bool aiming = false;
    
    void Start()
    {
        myAnim = GetComponentInChildren<Animator>();
        muzzle = 0;
        canFire = true;
        StartCoroutine(Fire());
        
    }

    // Update is called once per frame
    void Update()
    {
        if (muzzle == barrels.Count)
        {
            myAnim.SetBool("Fire", false);
            muzzle = 0;
            canFire = false;
            StartCoroutine(Pause());
        }
    }

    IEnumerator Fire()
    {
        if (canFire && aiming)
        {
            Vector3 targetPos = barrels[muzzle].transform.position + (vsdi.velocity * Time.deltaTime);
            myAnim.SetBool("Fire", true);
            GameObject laser = GameObject.Instantiate(laserPrefab, targetPos, barrels[muzzle].transform.rotation);
            laser.transform.SetParent(GameObject.Find("Lasers").transform);
            muzzle++;
        }

        yield return new WaitForSeconds(0.33f);
        StartCoroutine(Fire());
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(Random.Range(3f,5f));
        canFire = true;
    }
}
