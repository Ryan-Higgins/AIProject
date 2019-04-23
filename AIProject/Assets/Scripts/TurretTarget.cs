using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTarget : MonoBehaviour
{
    public GameObject target;
    public GameObject body;
    public GameObject wheel;
    public float turretAngle;
    public float baseAngle;
    private float distance;
    private Vector3 sideCheck;
    public List<GameObject> fighters;

    void Start()
    {
        foreach (GameObject x in GameObject.FindGameObjectsWithTag("X-Wing"))
        {
            fighters.Add(x);
        }
        
        if (gameObject.name == "HeavyQuadTurboLaserBattery")
        {
            body = transform.Find("HeavyQuadTurboLaserBattery").transform.Find("Base").gameObject;
            wheel = transform.Find("HeavyQuadTurboLaserBattery").transform.Find("Base").transform.Find("Wheel")
                .gameObject;

            target = fighters[Random.Range(0, fighters.Count)].gameObject;
        }
        else
        {
            body = transform.Find("TwinTurboLaserTurret").gameObject;
            wheel = transform.Find("TwinTurboLaserTurret").transform.Find("Wheel").gameObject;

            if (target == null)
            {
                target = fighters[Random.Range(0, fighters.Count)].gameObject;
            }
        }
        
    }

    void Update()
    {  
        sideCheck = target.transform.position - body.transform.position;
        
        turretAngle = Mathf.Atan2(sideCheck.y,sideCheck.z) * Mathf.Rad2Deg;
        baseAngle = Mathf.Atan2(sideCheck.x, sideCheck.z) * Mathf.Rad2Deg;
        
        print("My Distance: " + distance);
        //print(angle);

        if (baseAngle >= -45 && baseAngle <= 45)
        {
            if (turretAngle >= 0 && turretAngle <= 45)
            {
                wheel.transform.rotation = Quaternion.Euler(-turretAngle, baseAngle, 0.0f);
                body.transform.rotation = Quaternion.Euler(0.0f, baseAngle, 0.0f);
                gameObject.GetComponent<TurretFire>().aiming = true;
            }

            if (turretAngle <= 0 && turretAngle >= -45)
            {
                wheel.transform.rotation = Quaternion.Euler(-turretAngle, baseAngle, 0.0f);
                body.transform.rotation = Quaternion.Euler(0.0f, baseAngle, 180);
                gameObject.GetComponent<TurretFire>().aiming = true;
            }
        }
        else
        {
            target = fighters[Random.Range(0, fighters.Count)].gameObject;
        }        
    }
}
