using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MovementSystemScript : MonoBehaviour
{
    public float speed = 1.0f;
    public Transform cameraTransform;

    void Update()
    {
        var leftDevices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Left, leftDevices);

        if (leftDevices.Count > 0)
        {
            InputDevice leftDevice = leftDevices[0];
            if (leftDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 leftThumbstickPosition) && leftThumbstickPosition != Vector2.zero)
            {
                Vector3 forward = cameraTransform.forward;
                forward.y = 0; 
                forward.Normalize();
                Vector3 right = cameraTransform.right;
                right.y = 0; 
                right.Normalize(); 
                Vector3 movement = (forward * leftThumbstickPosition.y + right * leftThumbstickPosition.x) * speed * Time.deltaTime;
                transform.position += movement;
            }
        }
    }
}
