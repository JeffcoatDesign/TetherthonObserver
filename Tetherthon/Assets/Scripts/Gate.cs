using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private void OnEnable()
    {
        GateButton.OnPlayerPress += HideGate;
    }
    private void OnDisable()
    {
        GateButton.OnPlayerPress -= HideGate;
    }
    private void HideGate ()
    {
        gameObject.SetActive(false);
    }
}
