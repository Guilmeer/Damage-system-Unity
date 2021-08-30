using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] float speed;
    [SerializeField] float lookSpeed;
    [SerializeField] float jumpSpeed;
    Vector3 mousePos;
    Vector3 directionToMove;
    Vector3 ySpeed;
    Quaternion actualRotation;
    [SerializeField] float dashSpeed;
    float dashingTime;
    bool canDash = true;
    Rigidbody rb;
    delegate void MovementDelegate ();

    void Start () {
        rb = transform.GetComponent<Rigidbody> ();
    }
    private void FixedUpdate () {
        LookToMouse ();
        transform.rotation = actualRotation;

        rb.velocity = directionToMove * speed + ySpeed;
    }
    void Update () {
        MovementDelegate movementDelegate = null;
        movementDelegate += MovePlayer;
        if (Input.GetKeyDown (KeyCode.LeftShift) && canDash)
            movementDelegate += Dash;
        movementDelegate ();
    }
    private void LookToMouse () {
        Ray mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast (mouseRay, out hit);

        mousePos = -(transform.position - hit.point).normalized;

        Quaternion targetRotation = Quaternion.LookRotation (new Vector3 (mousePos.x, 0, mousePos.z));
        actualRotation = Quaternion.Lerp (transform.rotation, targetRotation, lookSpeed);
    }
    private void MovePlayer () {
        float horizontal = Input.GetAxisRaw ("Horizontal");
        float vertical = Input.GetAxisRaw ("Vertical");

        directionToMove = new Vector3 (horizontal, 0, vertical).normalized;
        ySpeed = new Vector3 (0, rb.velocity.y, 0);

        // Vai ter?? 
        if (Input.GetButtonDown ("Jump")) {
            rb.AddForce (Vector3.up * jumpSpeed);
        }
    }
    private void Dash () {
        canDash = false;
        StartCoroutine (DashCoroutine ());
    }
    IEnumerator DashCoroutine () {

        float basicspeed = speed;
        speed *= 3;
        yield return new WaitForSeconds (0.2f);
        speed = basicspeed;
        canDash = true;
    }
}