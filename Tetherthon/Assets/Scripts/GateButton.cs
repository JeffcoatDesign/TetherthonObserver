using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateButton : MonoBehaviour
{
    public delegate void PlayerPress();
    public static event PlayerPress OnPlayerPress;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (OnPlayerPress != null)
                OnPlayerPress();
        }
    }
}
