using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerToggle : MonoBehaviour
{
    public GameObject VRPointer = null;

    public void EnablePointer()
    {
        VRPointer.SetActive(true);
    }

    public void DisablePointer()
    {
        VRPointer.SetActive(false);
    }
}
