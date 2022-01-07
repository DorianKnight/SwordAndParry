using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform = null;
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidbodyComponent;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check to see if the space key is pressed down
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
    }

    //Called once ever physics update
    private void FixedUpdate()
    {
        rigidbodyComponent.velocity = new Vector3(2*horizontalInput, rigidbodyComponent.velocity.y, rigidbodyComponent.velocity.z);
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f).Length == 1)
        {
            return;
        }
        if (jumpKeyWasPressed)
        {
            rigidbodyComponent.AddForce(5 * Vector3.up, ForceMode.Impulse);
            jumpKeyWasPressed = false;
        }

        
    }

    
}
