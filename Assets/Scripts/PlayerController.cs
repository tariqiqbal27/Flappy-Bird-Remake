using UnityEngine;


public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb2d;
    [Header("Movement")]
    [SerializeField] private float upwardForce = 1f;
    [Header("Rotation")]
    [SerializeField] private float upRotation = 60f;
    [SerializeField] private float downRotation = -60f;
    [SerializeField] private float rSpeed = 6f;
    
    private Animator _animController;
    private readonly int _flapAnimation = Animator.StringToHash("Flap"); 

    private bool flip = false;
    private bool _startGame = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        _animController = GetComponent<Animator>();
    }

    private void Start() {
        rb2d.gravityScale = 0;
        
    }

    void StartGame() {
        _startGame = true;
        GameManager.instance.StartGame();
    }
    
    void OnAttack() {
        flip = true;
        if (!_startGame) {
            rb2d.gravityScale = 1;
            StartGame();
        }
        
        
    }

    private void FixedUpdate() {
        if (flip) {
            _animController.SetTrigger(_flapAnimation);
            rb2d.AddForce(Vector2.up * upwardForce, ForceMode2D.Impulse);
            flip = false;
        }
        RotateBird();
    }

    void RotateBird()
    {
        float velocityY = rb2d.linearVelocity.y;

        float targetAngle = Mathf.Lerp(
            downRotation,
            upRotation,
            Mathf.InverseLerp(-5f, 5f, velocityY)
        );

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.Euler(0, 0, targetAngle),
            rSpeed * Time.fixedDeltaTime
        );
    }
}
