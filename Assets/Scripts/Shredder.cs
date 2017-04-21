using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {

    private void OnTriggerExit(Collider other)
    {
        //only pins should be destroyed
        Pin pin = other.GetComponentInParent<Pin>();
        if (pin)
        {
            Debug.Log("Exit of: " + pin.name);
            pin.DestroyPin();
        }
    }
}
