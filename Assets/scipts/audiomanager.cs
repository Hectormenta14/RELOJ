using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiomanager : MonoBehaviour
{
    // Start is called before the first frame update
    public static audiomanager instance;
    private List<GameObject> audioList;// todod los objector nos lo vamos a guardar
    void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        audioList = new List<GameObject>();

    }
    public AudioSource PlayAudio(AudioClip audioClip, string gameObjectName, bool isLoop = false, float volume = 1.0f)/*isloop y float volume--->  parametros por defecto, tienen que ir al final y no pueden ir intercalados*/
    {
        GameObject audioObject = new GameObject(gameObjectName); //para darle nombre e identificarlo en la escena 
       AudioSource srcComponent = audioObject.AddComponent<AudioSource>(); //le añado el componente de audiosorce. src = AudioSource
       audioObject.transform.SetParent(transform); //todos los objetos de audio que see va creando sean hujos del audiomanager 
       srcComponent.clip = audioClip; // asignamos el clip al componente y el clip que asignamos a nuestro metodo
       srcComponent.loop = isLoop;  // ""
       srcComponent.volume = volume; //""
       srcComponent.Play(); //para que empiece
       audioList.Add(audioObject); //almanecar los objectos de la escena y llevarlos en seguimiento 
        if(!isLoop) //si el audio no esta en loop espera a que acabe para destruirlo
        {
            StartCoroutine(WaitAudioEnd(srcComponent));
        }

       return srcComponent; //porsiaca desde otros componentes queremos utilizar otros parametros del AudioSource 
       
    }
    IEnumerator WaitAudioEnd (AudioSource src) // coorutina IEnumerator que no pausa la ejecucion del programa, crea hilos y procesos sin que el propio programa tenga hilos y procesos por lo tanto los simula 
    {
        while(src && src.isPlaying) // esperar a que src deje de sonar para destruirlo 
        {
            yield return null; // yield corta la ejecucion del metodo y le devuelve el control a unity
        }
        Destroy(src.gameObject);
    }
    public void ClearAudios()
    {
        foreach(GameObject audioObject in audioList) // por todos los audios de la lista hay que ir destruyemdolos uno por uno
        {
            Destroy(audioObject);
        }
        audioList.Clear(); // borra todo el contenido de la lista (por que se queda memoria y hay que borrarla tmb)
    }
    
}
