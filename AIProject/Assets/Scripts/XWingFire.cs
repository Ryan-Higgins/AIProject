using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class XWingFire : MonoBehaviour
{
    public GameObject shot;
    public List<GameObject> cannons;
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fire());
    }

    // Update is called once per frame
    void Update()
    {       
        
    }

    IEnumerator Fire()
    {
        //Laser firing, only happens after animation is played.
        yield return new WaitForSeconds(Random.Range(0f,1f));
        if (gameObject.GetComponent<XWingBrain>().attackPosition)
        {
            for (int i = 0; i < cannons.Count; i++)
            {
                GameObject bang = Instantiate(shot, cannons[i].transform.position, cannons[i].transform.rotation);
                bang.transform.SetParent(GameObject.Find("Lasers").transform);
            }
        }

        StartCoroutine(Pause());
    }

    IEnumerator Pause()
    {
        //Delay so lasers aren't constant.
        yield return new WaitForSeconds(Random.Range(0f,3f));
        StartCoroutine(Fire());
    }
}
