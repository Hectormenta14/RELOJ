using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dethzone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.GetComponent<MarioScript>())
        {
            gamemanager.instance.LoadScene(SceneManager.GetActiveScene().name); // reinicia y limpia la escena de objetos y audios para que no suene nuevamente cada vez que mueras
         
        }
    }
}
