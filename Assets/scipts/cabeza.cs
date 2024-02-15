using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cabeza : MonoBehaviour
{
    public AudioClip cabezaClip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<MarioScript>())
        {
            collision.gameObject.GetComponent<Puntuacion>().agarrar();
            Destroy(transform.parent.gameObject);
            audiomanager.instance.PlayAudio(cabezaClip, "deathSound");
        }
    }
}
