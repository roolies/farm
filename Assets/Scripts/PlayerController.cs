using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Vector2 moveInput = Vector2.zero;
    Rigidbody2D rb;
    public GameObject Minigame1;
    public GameObject FarmArea;

    [SerializeField]
    private PlayerInput playerInput;
    private InputAction InteractAction;

    public bool Game1 = true;

    public bool TriggerToutched = false; 

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
        if(Minigame1 != null)
        {
            Minigame1.SetActive(false);
        }

        if(FarmArea != null)
        {
            FarmArea.SetActive(true);
        }

        playerInput = GetComponent<PlayerInput>();

        InteractAction = playerInput.actions["Interact"];

       //if (InteractAction.triggered && TriggerToutched)
       //{
       //
       //    Debug.Log("Interacted");
       //    //Minigame1.SetActive(true);
       //
       //}
       //else { Debug.Log("Not Interatced"); }
    }

 

    private void OnEnable()
    {
        InteractAction.performed += _ => Game1Start();
        InteractAction.canceled += _ => Game1Stop();
    }
    
    private void OnDisable()
    {
        InteractAction.performed -= _ => Game1Start();
        InteractAction.canceled -= _ => Game1Stop();
    }


    public void Game1Start()
    {
        if (TriggerToutched == true)
        {

            Debug.Log("Interacted");
            Minigame1.SetActive(true);
            FarmArea.SetActive(false);

        }
    }
    
    public void Game1Stop()
    {
        if (TriggerToutched == false)
        {
            Debug.Log("Not Interatced");
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = moveInput * moveSpeed;

        
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

       if (collision.tag == "MiniGame1")
       {
            TriggerToutched = true;
            Debug.Log("Trigger Entered");

            //if (InteractAction.triggered)
            //{
            //    //Game1Start();
            //    Debug.Log("Trigger interacted");
            //}
             
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "MiniGame1")
        {
            TriggerToutched = false;
            Debug.Log("trigger Exit");
        }
        
        //TriggerToutched = false;
        //Debug.Log("trigger not touched");
    }




}
