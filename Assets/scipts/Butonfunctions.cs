using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butonfunctions : MonoBehaviour
{
   
    // Start is called before the first frame update
     public void ExitGame()
    {
        gamemanager.instance.ExitGame(); 
    }
    public void LoadScene(string SeneName)
    {
        gamemanager.instance.LoadScene(SeneName);
        
    }
  
}
