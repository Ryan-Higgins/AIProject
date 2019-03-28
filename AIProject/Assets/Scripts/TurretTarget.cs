using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTarget : MonoBehaviour
{
    public GameObject target;
    private GameObject body;
    private GameObject wheel;
    private float turretAngle;
    private float baseAngle;
    private float distance;
    private Vector3 sideCheck;

    void Start()
    {
        if (gameObject.name == "HeavyQuadTurboLaserBattery")
        {
            body = transform.Find("HeavyQuadTurboLaserBattery").transform.Find("Base").gameObject;
            wheel = transform.Find("HeavyQuadTurboLaserBattery").transform.Find("Base").transform.Find("Wheel")
                .gameObject;
        }
        else
        {
            body = transform.Find("TwinTurboLaserTurret").gameObject;
            wheel = transform.Find("TwinTurboLaserTurret").transform.Find("Wheel").gameObject; 
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
            }
        }
        /*else
        {
            wheel.transform.rotation = Quaternion.Euler(turretAngle - 180, baseAngle, 0.0f);
        }*/

       
        
    }
}
