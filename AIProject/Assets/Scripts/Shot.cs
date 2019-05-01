using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider shot)
    {
        //Checking if the laser hits, if its an enemy laser and then spawns an explosion particle at the impact point.
        if (shot.CompareTag("Laser") && gameObject.name == "Nebulon-B")
        {
            print("Boom");
            GameObject bang = GameObject.Instantiate(explosion, shot.transform.position, explosion.transform.rotation);
            bang.transform.SetParent(GameObject.Find("Explosions").transform);
            Destroy(shot.gameObject);   
        } else if (shot.CompareTag("Laser1") && gameObject.name == "VSDI")
        {
            GameObject bang = GameObject.Instantiate(explosion, shot.transform.position, explosion.transform.rotation);
            bang.transform.SetParent(GameObject.Find("Explosions").transform);
            Destroy(shot.gameObject);
        }
        
        
    }
}
