using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float distToRaise = 40f;
    public float standingThreshold =3f;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Angle of pins is:" + IsStanding());
        
	}

    //returns true if the pin is still standing, wihtin standingThreshold 
    public bool IsStanding()
    {
        Vector3 pinAngle = transform.eulerAngles;
        bool angleWithinThresholdX = (pinAngle.x <= standingThreshold) || (pinAngle.x >= 360 - standingThreshold);
        bool angleWithinThresholdZ = (pinAngle.z <= standingThreshold) || (pinAngle.z >= 360 - standingThreshold);
        //both x and z rotation needs to be wihtin the threshold for the pin to count as standing
        return angleWithinThresholdX && angleWithinThresholdZ;
    }

    public void DestroyPin()
    {
        Destroy(gameObject);
    }

    public void Raise()
    {
        if (IsStanding() )
        {
			GetComponent<Rigidbody>().useGravity = false;
			GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			transform.rotation = Quaternion.identity;
            transform.Translate(distToRaise * Vector3.up, Space.World);

        }
    }

    //lowering pins == pins are allowed to fall again, prevents instantanious movement of pin which looks bad
    public void Lower()
    {
		//TODO: prevent pins from falling over after reactivating gravity
		GetComponent<Rigidbody>().useGravity = true;
    }
}
