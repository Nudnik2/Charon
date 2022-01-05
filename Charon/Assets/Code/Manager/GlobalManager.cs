using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    public static PlayerInventoryManager playerInventoryManager { get; private set; }
    public static TimeManager timeManager { get; private set; }

    private void Awake()
    {
        playerInventoryManager = GetComponent<PlayerInventoryManager>();
        timeManager = GetComponent<TimeManager>();
    }
}
