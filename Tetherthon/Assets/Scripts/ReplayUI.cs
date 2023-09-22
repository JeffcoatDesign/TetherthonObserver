using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayUI : MonoBehaviour
{
    [SerializeField] private GameObject ui;
    private void OnEnable()
    {
        Invoker.onReplay += ShowUI;
    }
    private void OnDisable()
    {
        Invoker.onReplay -= ShowUI;
    }
    private void ShowUI()
    {
        ui.SetActive(true);
    }
}
