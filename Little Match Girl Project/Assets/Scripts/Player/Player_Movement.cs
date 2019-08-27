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
    public float walkSpeed = 6f;
    public float sprintSpeed = 8f;
    public Animator anim;

    public float maxStam = 100;
    public float curStam;
    public bool gainStam = true;
    public float regenStam = 5.0f;
    public float drainStam = 0.1f;

    bool sprinting;
    float moveSpeed;
    Vector3 movement;
    Vector3 forward, right;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 100f;
    RaycastHit hit;
    LayerMask mask;
    void Awake()
    {
        floorMask = LayerMask.GetMask("worldFloor");;
        playerRigidbody = GetComponent<Rigidbody>();

        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    private void Start()
    {
        moveSpeed = walkSpeed;
        curStam = maxStam;
    }

    private void OnDrawGizmos()
    {
        if (Physics.Raycast(transform.position * 1.0f, transform.TransformDirection(Vector3.forward), out hit, 3))
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position * 1.0f, transform.TransformDirection(Vector3.forward));
            //it works but wrong
        }
    }

    private void Update()
    {
        if (Physics.Raycast(transform.position * 1.0f, transform.TransformDirection(Vector3.forward),out hit, 3))
        {
            if (hit.collider.tag == "Interactable")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    print("interact");
                   TriggerEventScript tEvent = hit.collider.GetComponent<TriggerEventScript>();
                    tEvent.CallEvent();
                }
            }
        }

        //gain Stam
        if (gainStam == true && curStam <= maxStam)
        {
            curStam = curStam += regenStam * Time.deltaTime;

            if (curStam > maxStam)
            {
                curStam = maxStam;
            }
        }

        //drain Stam
        if (curStam >= 0 && Input.GetKey(KeyCode.LeftShift))
        {
            curStam = curStam -= drainStam * Time.deltaTime;
        }
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

        if (Input.GetKey("left shift") && !sprinting)
        {
            //print("Sptrinting");
            sprinting = true;
           if(curStam >= 0)
            {
                gainStam = false;
                moveSpeed = sprintSpeed;

            } 
        }
        else if (sprinting && Input.GetKeyUp("left shift"))
        {
           // print("Not Sprinting");
            sprinting = false;
            gainStam = true;
            moveSpeed = walkSpeed;
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

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 20, 100, 20), "Stamina/" + curStam.ToString());
    }

}//End
