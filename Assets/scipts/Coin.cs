using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
     [SerializeField] private GameObject Efecto;
    [SerializeField] private float CantidadPuntos;
    [SerializeField] private Puntuacion Puntaje;
    public AudioClip coinClip;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<MarioScript>())
        {
            other.gameObject.GetComponent<Puntuacion>().agarrar();
            Destroy(gameObject);
            audiomanager.instance.PlayAudio(coinClip, "coinSound");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
