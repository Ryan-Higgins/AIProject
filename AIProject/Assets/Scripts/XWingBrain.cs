using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XWingBrain : MonoBehaviour
{
    private Animator myAnim;
    public GameObject explosion;
    private GameObject destroyer;

    public bool attackPosition;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponentInChildren<Animator>();
        destroyer = GameObject.Find("VSDI");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, destroyer.transform.position) <= 850)
        {
            myAnim.SetBool("InRange", true);
            attackPosition = true;
            StartCoroutine(Explode());
        }
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(Random.Range(50f,55f));
        GameObject bang = GameObject.Instantiate(explosion, gameObject.transform.position, explosion.transform.rotation);
        bang.transform.SetParent(GameObject.Find("Explosions").transform);
        Destroy(gameObject);

    }
}
