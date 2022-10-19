using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using FarmGame;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Vector2 moveInput = Vector2.zero;
    Rigidbody2D rb;
    public GameObject Minigame1;
    public GameObject FarmArea;
    private CollectionGame currentGame = null;

    [SerializeField]
    private PlayerInput playerInput;
    private InputAction InteractAction;
    private InputAction ExitAction;

    public bool TriggerToutched = false;

    public bool TomatoToutched = false;
    public bool AppleToutched = false;



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
        ExitAction = playerInput.actions["ExitMiniGame"];


    }

 

    private void OnEnable()
    {
        InteractAction.performed += _ => Game1Start();
        InteractAction.canceled += _ => Game1Stop();

        ExitAction.performed += _ => MiniGameExitStart();
        ExitAction.canceled += _ => MiniGameExitStop();
    }
    
    private void OnDisable()
    {
        InteractAction.performed -= _ => Game1Start();
        InteractAction.canceled -= _ => Game1Stop();

        ExitAction.performed -= _ => MiniGameExitStart();
        ExitAction.canceled -= _ => MiniGameExitStop();
    }


    public void Game1Start()
    {
        if (TriggerToutched == true)
        {

            Debug.Log("Interacted");
            Minigame1.SetActive(true);
            FarmArea.SetActive(false);
            currentGame.StartMiniGame();
        }
    }
    
    public void Game1Stop()
    {
        if (TriggerToutched == false)
        {
            Debug.Log("Not Interatced");
        }
        
    }

    public void MiniGameExitStart()
    {
        Debug.Log("Q pressed");
        Minigame1.SetActive(false);
        FarmArea.SetActive(true);
        currentGame.EndMiniGame();
        currentGame = null;
    }
    public void MiniGameExitStop()
    {

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
            currentGame = collision.gameObject.GetComponent<CollectionGame>();
        }

        if (collision.tag == "Tomato")
        {
            Debug.Log("Tomato Interacted");
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Apple")
        {
            Debug.Log("Apple Interacted");
            currentGame.AddIngredient();
            Destroy(collision.gameObject);
        }

        if (collision.tag == "BadFruit")
        {
            Debug.Log("Apple Interacted");
            Destroy(collision.gameObject);
        }


    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "MiniGame1")
        {
            TriggerToutched = false;
            Debug.Log("trigger Exit");
            
        }
        
       
    }




}
