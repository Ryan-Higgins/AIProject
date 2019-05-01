using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerPursue : SteeringBehaviour
{
    //Version of Pursue that locks the Y value so it doesn't rise or fall.
    public Boid target;

    Vector3 targetPos;
    private float beforeY;

    void Start()
    {
        beforeY = transform.position.y;
    }

    public void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, targetPos);
        }
    }

    public override Vector3 Calculate()
    {
        float dist = Vector3.Distance(target.transform.position, transform.position);
        float time = dist / boid.maxSpeed;
        
        targetPos = target.transform.position + (target.velocity * time);
        targetPos.y = beforeY;

        return boid.SeekForce(targetPos);
    }
}
