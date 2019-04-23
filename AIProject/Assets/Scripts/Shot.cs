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
        if (shot.CompareTag("Laser"))
        {
            print("Boom");
            GameObject bang = GameObject.Instantiate(explosion, shot.transform.position, explosion.transform.rotation);
            bang.transform.SetParent(GameObject.Find("Explosions").transform);
            Destroy(shot.gameObject);
            
        }
    }
}
