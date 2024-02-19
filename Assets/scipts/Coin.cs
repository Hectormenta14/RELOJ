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
            other.gameObject.GetComponent<Puntuacion>().agarrar(); // la moneda sumara puntos y se destruir al entrar en contacto con Puntuacion
            Destroy(gameObject);
            audiomanager.instance.PlayAudio(coinClip, "coinSound"); //la moneda sonara
        }

    }



}
