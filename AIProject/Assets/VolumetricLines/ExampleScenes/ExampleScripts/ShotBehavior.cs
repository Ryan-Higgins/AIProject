using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour {
public float speed;

	//Basic laser script that just moves and destroys them after time.
	// Use this for initialization
	void Start ()
	{
		StartCoroutine(Destroy());
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * Time.deltaTime * speed;
	
	}


	IEnumerator Destroy()
	{
		yield return new WaitForSeconds(8f);
		Destroy(gameObject);
	}
}
