using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Interactable", menuName = "Data Objects/Interactable", order = 5)]
public class InteractableData : ScriptableObject
{
    public bool requiresTool;
    public ToolData requiredTool;
}
