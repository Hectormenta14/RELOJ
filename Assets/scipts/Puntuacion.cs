using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Puntuacion : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text puntos;
    public int monedas;
  
  
    void Update()
    {
        puntos.text = monedas.ToString();
    }
    public void agarrar()
    {
        monedas += 10;
    }
}
