using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Formation : SteeringBehaviour
{
    public Boid leader;

    private Vector3 side;
    // Start is called before the first frame update
    void Start()
    {
        side = transform.position - leader.transform.position;
        side.Normalize();
    }

    public override Vector3 Calculate()
    {
        return Vector3.zero;
    }
}
