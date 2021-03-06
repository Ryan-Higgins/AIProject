﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OffsetPursue : SteeringBehaviour
{
    //Tweaked version of offset pursue so ships fly more like X-Wings
    public Boid leader;

    Vector3 targetPos;
    Vector3 worldTarget;
    Vector3 offset;
    public int gap = 25;
    public int formationPos;

    // Start is called before the first frame update
    private void Start()
    {
        offset = transform.position - leader.transform.position;
        offset.Normalize();
        offset.x *= (gap * formationPos);
        print("My offset: " + offset);
        //orgPos = transform.position;
    }

    public override Vector3 Calculate()
    {
        worldTarget = leader.transform.TransformPoint(offset);
        worldTarget.y = leader.transform.position.y;
        

        float dist = Vector3.Distance(worldTarget, transform.position);
        float time = dist / boid.maxSpeed;
        targetPos = worldTarget + (leader.velocity * time);
        return boid.ArriveForce(targetPos);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, worldTarget);
    }
}
