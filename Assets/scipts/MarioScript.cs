using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MarioScript : MonoBehaviour
{
    public KeyCode rightKey, leftKey, jumpKey;
    public float speed, rayDistance, jumpForce;
    public LayerMask groundMask; //mascara de colisiones con la q el rayo se va a colisionar 

    private Rigidbody2D rb;
    private SpriteRenderer _rend;
    private Vector2 dir;
    private bool _isJumping;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _rend = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        print(gamemanager.instance.GetTime()); //accesible desde cualquier parte del codigo 
        dir = Vector2.zero;
        if(Input.GetKey(rightKey))
        {
            _rend.flipX = false;
            dir = Vector2.right;
        }
        else if(Input.GetKey(leftKey))
        {
            _rend.flipX = true;
            dir = new Vector2(-1, 0);
        }
        _isJumping = false;
        if (Input.GetKey(jumpKey))
        {
            _isJumping = true;
        }
        if (dir != Vector2.zero) 
        {
            // estamos andando
            _animator.SetBool("iswalking", true);
        }
        else
        {
            // estamos parados 
            _animator.SetBool("iswalking", false);
        }
    }

    private void FixedUpdate()
    {
        bool grand = IsGrounded();
        //if(dir != Vector2.zero)
        {
           float currentYVel = rb.velocity.y;//para q el bicho bicheee y tambien si esta en movimiento y caes q caiga a la misma velocidad 
            Vector2 nVel = dir * speed;
            nVel.y = currentYVel;
            rb.velocity = nVel;
        }
        if (_isJumping && IsGrounded()) // hace q salte 
        {
            _animator.Play("salto");
            rb.velocity = new Vector2(rb.velocity.x, 0); // hace que el personaje mantenga siempre la misma potencia de salto 
            rb.AddForce(Vector2.up * jumpForce * rb.gravityScale * rb.drag, ForceMode2D.Impulse); // el rb.drag hace que el peronaje no deslice
            
        }
        _animator.SetBool("iswalking", grand);
    }
    private bool IsGrounded() // se lanza un rato desde el personaje hace abajo y va a detectar la mascara de colisiones q hemos establecido (detectar suelo)
    {
        RaycastHit2D collisions = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundMask);
        if (collisions)
        {
            return true;
        }
        return false;
       
    }
    private void OnDrawGizmos() // indentificar al rayo 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);
    }
}
