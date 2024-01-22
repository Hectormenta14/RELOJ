using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, transform.position.y, -5f), 5f * Time.deltaTime);// la camara seguira al personaje y si la camara no esta centrada con el personaje, se centrara al inicio de la partida a una velocidad de 5
    }
}
