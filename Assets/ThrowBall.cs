using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 initialPosition; // record the initial position of the sphere

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // if (rb == null)
        // {
        //     Debug.LogError("Rigidbody is missing on " + gameObject.name);
        // }

        initialPosition = transform.position;
    }

    void Update()
    {
        // add force (F key)
        if (Input.GetKeyDown(KeyCode.F))
        {
            rb.AddForce(new Vector3(0, 300f, 0));
        }

        // back to initial position (R key)
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetPosition();
        }
    }

    void ResetPosition()
    {
        rb.linearVelocity = Vector3.zero; 
        rb.angularVelocity = Vector3.zero; 
        transform.position = initialPosition; 
    }
}