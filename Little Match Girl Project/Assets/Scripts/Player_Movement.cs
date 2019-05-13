/*Player Character Movement/Jump Script
 * Ricardo III Ticlao
 * 04/06/2019
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public bool mouseTurning;
    public bool canMove = true;
    public float moveSpeed = 6f;
    public Animator anim;

    Vector3 movement;
    Vector3 forward, right;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 100f;

    void Awake()
    {
        floorMask = LayerMask.GetMask("worldFloor");;
        playerRigidbody = GetComponent<Rigidbody>();

        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (canMove)
        {
            Move(h, v);

            // anim.Play("Run");
            //       Vector3 movement = new Vector3(h, 0f, v);

            Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
            Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
            Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");
            Vector3 movement = Vector3.Normalize(rightMovement + upMovement);

            movement = Vector3.ClampMagnitude(movement, 1.0f);

            transform.Translate(movement * moveSpeed * Time.fixedDeltaTime, Space.World);

            if (mouseTurning)
            {
                MouseTurning();
            }
            else
            {
                MoveTurn();
            }
        }
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);

        movement = movement.normalized * Time.deltaTime * moveSpeed;
    }

    void MoveTurn()
    {
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(movement),
                Time.fixedDeltaTime * moveSpeed);
        }
    }

    void MouseTurning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion wantedRotation = Quaternion.LookRotation(playerToMouse);

            playerRigidbody.MoveRotation(wantedRotation);
        }
    }

    public void Knockback(bool ableToMove)
    {
        canMove = ableToMove;
    }

}//End
