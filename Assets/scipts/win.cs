using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win : MonoBehaviour
{
    public AudioClip winClip;
    private List<GameObject> audioList;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        
            audiomanager.instance.PlayAudio(winClip, "winSound");
        
    }

    public void ClearAudios()
    {
        foreach (GameObject audioObject in audioList) // por todos los audios de la lista hay que ir destruyemdolos uno por uno
        {
            Destroy(audioObject);
        }
        audioList.Clear(); // borra todo el contenido de la lista (por que se queda memoria y hay que borrarla tmb)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
