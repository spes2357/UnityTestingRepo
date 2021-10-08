using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    List<UnityEngine.XR.InputDevice> leftHandedControllers;
    UnityEngine.XR.InputDeviceCharacteristics desiredCharacteristics;
    void Start()
    {
        //controller = GetComponent<UnityEngine.XR.InputDevice>;
        leftHandedControllers = new List<UnityEngine.XR.InputDevice>();
        desiredCharacteristics = UnityEngine.XR.InputDeviceCharacteristics.HeldInHand | UnityEngine.XR.InputDeviceCharacteristics.Left | UnityEngine.XR.InputDeviceCharacteristics.Controller;
        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(desiredCharacteristics, leftHandedControllers);
        Debug.Log("Hi");
        foreach (var device in leftHandedControllers)
        {
            Debug.Log(string.Format("Device name '{0}' has characteristics '{1}'", device.name, device.characteristics.ToString()));
        }
    }

    // Update is called once per frame
    void Update()
    {
        //print("Hello");

        bool triggerValue;
        if (leftHandedControllers[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
            Debug.Log("Trigger button is pressed.");
        }
    }
}
