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
    public GameObject SpntCol;
    public GameObject SpntPan;
    public GameObject sitCollider;

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
    float rotation = 180f;
    private LightMatchScript matchSrpt;

    bool sitting;

    void Awake()
    {
        floorMask = LayerMask.GetMask("worldFloor"); 
        playerRigidbody = GetComponent<Rigidbody>();

    }

    private void Start()
    {
        moveSpeed = walkSpeed;
        curStam = maxStam;
        SpntPan.GetComponent<CanvasGroup>().alpha = 0;//***Tianna!!***

        
        GameObject PlayerModel = transform.Find("CharacterModel&Rig").gameObject;
        Animator anim = PlayerModel.GetComponent<Animator>();
       // anim.Play("StartingPosition");
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
       
        //Testing preparation for sit animation
        if (Input.GetKeyDown(KeyCode.T))
        {
            //BeginToSit();
            sitting = true;
        }
        

       /* else if (this.InMyState)
        {
            this.InMyState = false;
            // You have just leaved your state!
        }*/
        if (Physics.Raycast(transform.position * 1.0f, transform.TransformDirection(Vector3.forward), out hit, 3))
        {
            if (hit.collider.tag == "Interactable")
            {
                Animator anim = GameObject.Find("CharacterModel&Rig").GetComponent<Animator>();
                if (anim.GetBool("moving") == false)
                { 
                    if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown("joystick button 2"))//"X" Button
                    {
                        if (hit.collider == sitCollider)
                        {
                            LightMatchScript match = GameObject.Find("Player").GetComponent<LightMatchScript>();

                            if (match.isLit == true)
                            {
                                match.isLit = false;
                                StartCoroutine(DelayCheck());
                            }
                            GameObject GameManager = GameObject.Find("GameManager");
                            GameObject PuzzleChurch = GameManager.transform.Find("Puzzle Church").gameObject;
                            GameObject ChurchLight = PuzzleChurch.transform.Find("ChurchLight").gameObject;

                            if (ChurchLight.activeSelf)
                            {

                                transform.Rotate(0, rotation, 0);
                                anim.Play("Sit");


                            }
                        }

                            if (!this.anim.GetCurrentAnimatorStateInfo(0).IsName("Sit"))
                            {

                                TriggerEventScript tEvent = hit.collider.GetComponent<TriggerEventScript>();
                                tEvent.CallEvent();

                                anim.Play("Idle");
                            }
                    }
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

        if (Input.GetKey("left shift") && SpntPan.GetComponent<CanvasGroup>().alpha == 1
            || Input.GetKey("joystick button 0") && SpntPan.GetComponent<CanvasGroup>().alpha == 1)//***Tianna!!*** "A" Button
        {
            //Sprint TUT
            SpntPan.GetComponent<CanvasGroup>().alpha = 0;//***Tianna!!***

        }
    }

    void FixedUpdate()
    {
        
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        //right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        right = Camera.main.transform.right;
        right.y = 0;
        right = Vector3.Normalize(right);

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        matchSrpt = GetComponent<LightMatchScript>();

        //play anims w/ matchlit
        if (matchSrpt.isLit == true)
        {
            //anim.Play("MatchIdle");
            anim.SetBool("match", true);
        }
        else
        {
            anim.SetBool("match", false);
        }

        if (sitting)//Scripted Movement
        {
            MoveIntoPlace();
        }

        if (canMove)
        {
            Move(h, v);

            
            // anim.Play("Run");
            //       Vector3 movement = new Vector3(h, 0f, v);

            //Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
            // Vector3 rightMovement = right * Input.GetAxis("HorizontalKey");
            // Vector3 upMovement = forward * Input.GetAxis("VerticalKey");
            //Vector3 movement = Vector3.Normalize(rightMovement + upMovement);

            movement = Vector3.ClampMagnitude(movement, 1.0f) * moveSpeed;
            anim.SetFloat("Speed", movement.magnitude);
            transform.Translate(movement * Time.fixedDeltaTime, Space.World);
            
            if (mouseTurning)
            {
                MouseTurning();
            }
            else
            {
                MoveTurn();
            }
        }

        if (Input.GetKey("left shift") && !sprinting || Input.GetKey("joystick button 0") && !sprinting) //"A" Button
        {
            //print("Sptrinting");
            sprinting = true;
            if (curStam >= 0)
            {
                gainStam = false;
                moveSpeed = sprintSpeed;

            }
        }
        else if (sprinting && Input.GetKeyUp("left shift") || sprinting && Input.GetKeyUp("joystick button 0"))
        {
            // print("Not Sprinting");
            sprinting = false;
            gainStam = true;
            moveSpeed = walkSpeed;
        }
    }

    void Move(float h, float v)
    {
        if (canMove)
        {
            movement.Set(h, 0f, v);
            anim.SetBool("moving", true);
            movement = movement.normalized * Time.deltaTime * moveSpeed;

            if (h == 0 && v == 0)
            {
                anim.SetBool("moving", false);
                movement = Vector3.zero;
            }

            if (anim.GetBool("moving") == true)
            {
                AkSoundEngine.PostEvent("Footsteps", gameObject);
            }
        }
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

    private void OnTriggerEnter(Collider col)//***Tianna!!***
    {
        if (col.gameObject == SpntCol)//***Tianna!!***
        {
            SpntPan.GetComponent<CanvasGroup>().alpha = 1;//***Tianna!!***
        }
    }

    public void BeginToSit()
    {
        //StartCoroutine(MoveIntoPlace());
    }

    //Player Character scripted movement for sitting
    //IEnumerator MoveIntoPlace()
    void MoveIntoPlace()
    {
        canMove = false;
        Vector3 curPos = transform.position;
        Transform tarPos = GameObject.FindWithTag("SitPos").transform;
        //move player to target location
        //and copy rotation of target
        //movement = Vector3.ClampMagnitude(movement, 1.0f) * moveSpeed;
        anim.SetFloat("Speed", 8);//Anim play walk
        //transform.Translate(movement * Time.fixedDeltaTime, Space.World);
        if(curPos != tarPos.position && !canMove)
        {
        transform.LookAt(tarPos);
        transform.position = Vector3.MoveTowards(curPos, tarPos.position, 5 * Time.deltaTime);
        }
        else
        {
            
        }
        //transform.rotation = tarPos.rotation.eulerAngles;
       // yield break;
    }

    IEnumerator DelayCheck()
    {
        yield return new WaitForSeconds(0.2f);
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            anim.Play("Sit");
        }
    }


}//End