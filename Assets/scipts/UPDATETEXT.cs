using System.Collections;
using System.Collections.Generic;
using TMPro; // avisar al codigo de que vas a usar un  codigo que esta en otro lugar 
using Unity.VisualScripting;
using UnityEngine;


public class UPDATETEXT : MonoBehaviour
{
    public gamemanager.GameManagerVariables varieble;
    private TMP_Text textComponent;
    // Start is called before the first frame update
    private void Start()
    {
        textComponent = GetComponent<TMP_Text>();
    }
    //Update is called once per frame
    void Update()
    {
        switch (varieble)
        {
            case gamemanager.GameManagerVariables.TIME:
                textComponent.text = "Time: " + gamemanager.instance.GetTime().ToString("0.00"); //el tostring para que devuelva solo 2 decimales en cadena
                break;
            case gamemanager.GameManagerVariables.POINTS:
                textComponent.text = "Points: " + gamemanager.instance.GetPoint();
                break;
            default:
                break;
        }
    }
    // EVENSYSTEM SE CREA AUTOMATICAMENTE CON EL CANVAS Y HABILITA QUE SE DETECTE LOS EVENTOS DEL USUARIOS SOBRE LOS EVENTOS DEL INTERFAZ, NO FOKING TOCAR
    //TODO LO QUE EMPIECE EN ON ES UN EVENTO 
    //callback (despues) 
}

