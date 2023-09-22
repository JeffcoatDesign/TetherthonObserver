using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VCamFOV : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    private void OnEnable()
    {
        SpeedBoost.OnPickUpEvent += ChangeFOV;
    }
    private void OnDisable()
    {
        SpeedBoost.OnPickUpEvent -= ChangeFOV;
    }
    void ChangeFOV ()
    {
        vcam.m_Lens.FieldOfView = 100;
    }
}
