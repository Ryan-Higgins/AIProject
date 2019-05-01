using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Delete());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Delete()
    {
        //Deleting the game object of the explosion after finish playing
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
