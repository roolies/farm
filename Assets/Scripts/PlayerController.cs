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
    public GameObject Minigame2;
    public GameObject KillTrigger;

    public GameObject FarmArea;
    private CollectionGame currentGame = null;

    [SerializeField]
    private PlayerInput playerInput;
    private InputAction InteractAction;
    private InputAction ExitAction;

    public bool TriggerToutched = false;
    public bool MiniGame2Toutched = false;

    public bool TomatoToutched = false;
    public bool AppleToutched = false;



    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
       //if(Minigame1 != null)
       //{
       //    Minigame1.SetActive(false);
       //}
       //
       //if(FarmArea != null)
       //{
       //    FarmArea.SetActive(true);
       //}

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

        if (MiniGame2Toutched == true)
        {
            Debug.Log("Game 2 interacted");
            Minigame2.SetActive(true);
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
        KillTrigger.SetActive(true);
        FarmArea.SetActive(true);
        Minigame1.SetActive(false);
        Minigame2.SetActive(false);
        currentGame.EndMiniGame();
        currentGame = null;
        KillTrigger.SetActive(true);
    }
    public void MiniGameExitStop()
    {
        KillTrigger.SetActive(false);
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
            Debug.Log("MiniGame 1 toutched");
            currentGame = collision.gameObject.GetComponent<CollectionGame>();
        }

        if (collision.tag == "MiniGame2")
        {
            MiniGame2Toutched = true;
            Debug.Log("MiniGame 2 toutched");
            currentGame = collision.gameObject.GetComponent<CollectionGame>();
        }


    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "MiniGame1")
        {
            TriggerToutched = false;
            Debug.Log("trigger Exit");
        }

        if (collision.tag == "MiniGame2")
        {
            MiniGame2Toutched = false;
            Debug.Log("MiniGame 2 toutched");
        }


    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Tomato"))
        {
            Debug.Log("Tomato Interacted");
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag.Equals("Apple"))
        {
            Debug.Log("Apple Interacted");
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag.Equals("Pumpkin"))
        {
            Debug.Log("Pumpkin Interacted");
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag.Equals("BadFruit"))
        {
            Debug.Log("Apple Interacted");
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag.Equals("Egg"))
        {
            Debug.Log("Tomato Interacted");
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag.Equals("BadEgg"))
        {
            Debug.Log("Tomato Interacted");
            Destroy(other.gameObject);
        }


    }




}
