using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb2D;
    private Vector2 movementInput; 
    private Animator animator;  //Animator controler del player
    private int currentAfinidad; //Afinidad actual
    public int maxAfinidad = 100; //Afinidad máxima
    public int minAfinidad = 0; //Afinidad mínima

    private bool gameIsPaused = false; //Para saber si el juego está pausado

    void Start ()
    {
        currentAfinidad = minAfinidad;
        UIManager.Instance.UpdateAfinidad(currentAfinidad);
    }
    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        movementInput = movementInput.normalized;

        animator.SetFloat("Horizontal", movementInput.x);
        animator.SetFloat("Vertical", movementInput.y);
        animator.SetFloat("Speed", movementInput.magnitude);

        OpenCloseInventario(); //Llama al método

        OpenClosePauseMenu(); //Llama al método
    }

    void FixedUpdate()
    {
        rb2D.linearVelocity = movementInput * speed;
    }

    void OpenCloseInventario()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (UIManager.Instance != null)
            {
                UIManager.Instance.OpenorCloseInventario();
            }
        }
    }
    
    void OpenClosePauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gameIsPaused)
            {
                UIManager.Instance.ResumeGame();
                gameIsPaused = false;
            }
            else
            {
                UIManager.Instance.PauseGame();
                gameIsPaused = true;
            }
        }
    }
    
}