using UnityEngine;

public class PlayerController3D : MonoBehaviour
{
    public float moveSpeed = 400f;    // Velocidad de movimiento del jugador
    public float jumpForce = 100f;   // Fuerza de salto del jugador
    private Rigidbody rb;
    private bool isGrounded;
    private Vector3 originalGravity;
    private bool JustJump = false;
    private float origianlMoveSpeed;
    private int gravityMultiplayer = 1;
    public bool isStomping = false;
    public GameObject startPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalGravity = Physics.gravity;
        origianlMoveSpeed = moveSpeed;
        Physics.gravity = originalGravity * 2f; // Duplicar la gravedad
        Respawn();

    }
    void FixedUpdate()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;
        //   rb.MovePosition(transform.position + movement);

        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
    }
    void Update()
    {
        // Movimiento horizontal

        if (isGrounded)
        {
            gravityMultiplayer = 1;
            isStomping = false;
        }
        // Saltar
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {

            if (!isGrounded && rb.velocity.y < 0)
            {
                gravityMultiplayer = 3;
                isStomping = true;
            }

        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            JustJump = true;
        }

        else if (Input.GetKeyDown(KeyCode.Space) && !isGrounded && JustJump)
        {  // Doble salto

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            JustJump = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        { //correr
            moveSpeed *= 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        { //retornar a velocidad normal

            moveSpeed = origianlMoveSpeed;
        }

        if (!isGrounded && rb.velocity.y < 0)
        {

            Physics.gravity = originalGravity * 4f * gravityMultiplayer; // Aumentar la gravedad
        }


        if (this.transform.position.y < -6)
        {

            Respawn(); //volver a posicion original
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si el jugador está en el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void Respawn()
    {
        this.transform.position = startPos.GetComponent<Transform>().position;
    }
}
