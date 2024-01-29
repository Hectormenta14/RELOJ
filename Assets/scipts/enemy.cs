using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
  
{
    // Start is called before the first frame update
    public Transform player;
    private Vector2 dir;
    private SpriteRenderer _rend;
    void Start()
    {  // private GameObject target;
       // target = FindObjectOfType<MarioScript>(). gameObject; //para q el enemigo siga al protagonista 
       // private void OnCollisionEnter2D(Collision2D collision)
       
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), 1f * Time.deltaTime);// hace que el enemigo persiga al personaje principal 
      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<MarioScript>()) //LO QUE SE CHOCA CON EL ENEMIGO ES EL DESPERTADOR 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //reinicia
        }

    }

} // singleton (solo existe una instancia de esa clase en todo el juegue y si vienen nuevos se destruyen y ademas la instancia es una facilona (accesible a todo e mundo)
