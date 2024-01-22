using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cabeza : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MarioScript>())
        {
            Destroy(transform.parent.gameObject); 
        }
    }
}
