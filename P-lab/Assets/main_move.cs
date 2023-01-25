using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_move : MonoBehaviour
{




    // How fast we want the player to move and spin
    public float moveSpeed = 10; //f at the end because float
    public float rotationSpeed = 75f;
    public float jumpVelocity = 10f;
    public float distanceToGround = 0.1f;
    public LayerMask groundLayer;

    private float vInput;
    private float hInput;
    //Contains the objects rigidbody
    private Rigidbody _rb;

    private CapsuleCollider _col;



    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        // Will detect when the up/down arrow or w/s keys are pressed, unity method
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        // Will detect when the left/right arrow or a/d keys are pressed, unity method
        hInput = Input.GetAxis("Horizontal") * rotationSpeed;

        // "this" refers to the GameObject the script is attached to
        this.transform.Translate(Vector3.forward * vInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);


    }

    void FixedUpdate()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }


        Vector3 rotation = Vector3.up * hInput;
        Quaternion angleRotation = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        _rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRotation);





    }

    //utility function
    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);

        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);

        return grounded;
    }
}
