using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.PXR;
using TMPro;
using UnityEngine.SceneManagement;

public class returnScript : MonoBehaviour
{
    bool triggerValue;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Use controller button
        GetControllerInfo();
    }

    void GetControllerInfo()
    {
        var rightHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices);

        var leftHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHandDevices);

        // Right hand device button presses
        if (rightHandDevices.Count == 1)
        {
            UnityEngine.XR.InputDevice device = rightHandDevices[0];

            // Check if the primary button on the right controller is pressed
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
            {
                // Load a different scene if primary button is pressed
                if (SceneManager.GetActiveScene().name != "Intro")
                {
                    SceneManager.LoadScene("Intro");
                    Debug.Log("Primary button on the right controller is pressed.");
                }
            }

            // Check if the secondary button on the right controller is pressed
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
            {
                // Load a different scene if secondary button is pressed
                if (SceneManager.GetActiveScene().name != "Intro")
                {
                    SceneManager.LoadScene("Intro");
                    Debug.Log("Secondary button on the right controller is pressed.");
                }
            }
        }

        // Left hand device button presses
        if (leftHandDevices.Count == 1)
        {
            UnityEngine.XR.InputDevice device = leftHandDevices[0];

            // Check if the primary button on the left controller is pressed
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
            {
                // Load a different scene if primary button is pressed
                if (SceneManager.GetActiveScene().name != "Intro")
                {
                    SceneManager.LoadScene("Intro");
                    Debug.Log("Primary button on the left controller is pressed.");
                }
            }

            // Check if the secondary button on the left controller is pressed
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
            {
                // Load a different scene if secondary button is pressed
                if (SceneManager.GetActiveScene().name != "Intro")
                {
                    SceneManager.LoadScene("Intro");
                    Debug.Log("Secondary button on the left controller is pressed.");
                }
            }
        }
    }
}