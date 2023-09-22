using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public delegate void OnPickUp();
    public static event OnPickUp OnPickUpEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && OnPickUpEvent != null)
        {
            OnPickUpEvent();
            gameObject.SetActive(false);
        }
    }
}
