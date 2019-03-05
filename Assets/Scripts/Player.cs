using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public float speed = 10.0f;
    public float gravity = 15.0f;
    public float jumpSpeed = 8.0f;
    public float rotationY;
    public float rotationX;

    public bool enter = true;


    private Vector3 rotateValue;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    //
    // public Text collectedText;
    // public int collected = 0;
    //
    // public bool OpenDoor1 = false;
    // public bool OpenDoor2 = false;
    //
    // private Animator m_Animator;
    // private Animator m_PlayerAnim;
    //
    // public ParticleSystem keyFX;


    void Start()
    {
       controller = GetComponent<CharacterController>();
      // m_PlayerAnim = gameObject.GetComponent<Animator>();


      gameObject.transform.position = new Vector3(0, 5, 0);
    }

    void Update()
    {
        if (controller.isGrounded) // Only allows player to jump when touching the ground
        {
          moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
          moveDirection = transform.TransformDirection(moveDirection);
          moveDirection = moveDirection * speed;
          // m_PlayerAnim.SetBool("Jumping", false);
          if (Input.GetButton("Jump"))
            {
              // m_PlayerAnim.SetBool("Jumping", true);
              moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);



        // Plays running animation when character is moving in x or z axis
        // if(moveDirection.x > 0.0f || moveDirection.z > 0.0f)
        // {
        //   // m_PlayerAnim.SetBool("Running", true);
        // } else { m_PlayerAnim.SetBool("Running", false); }

        // Rotate the view
        rotationY = Input.GetAxis("Mouse X");
        rotationX = Input.GetAxis("Mouse Y");
        rotateValue = new Vector3(rotationX, rotationY * -1, 0);
        transform.eulerAngles = transform.eulerAngles - rotateValue;

        // collectedText.text = "Keys collected: " + collected.ToString ();


    }

    private void OnTriggerEnter(Collider other)
    {
      // if(other.gameObject.CompareTag("Collectable")) // adds to collected number and destroys key
      // {
      //   if(enter)
      //   {
      //     collected += 1;
      //     Instantiate(keyFX, other.transform.position, Quaternion.identity);
      //     Destroy(other.transform.root.gameObject);
      //   }
      // }
      //
      // if(other.gameObject.CompareTag("Door1")) // Opens the door if 3 or more keys are collected
      //   {
      //     m_Animator = other.transform.root.gameObject.GetComponent<Animator>();
      //     if(collected >= 3)    {  m_Animator.SetBool("OpenDoor1", true);}
      //
      //
      //
      //   }
      // if(other.gameObject.CompareTag("Door2")) // Opens the door if 5 or more keys are collected
      //     {
      //       m_Animator = other.transform.root.gameObject.GetComponent<Animator>();
      //       if(collected >= 4)    {  m_Animator.SetBool("OpenDoor2", true);}
      //
      //
      //
      //     }
      if(other.gameObject.CompareTag("Monster"))
      {
        SceneManager.LoadScene("Battle");
      }
    }

    private void OnCollisionEnter(Collision other)
    {

    }

}
