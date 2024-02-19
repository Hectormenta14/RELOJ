using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fade : MonoBehaviour
{

    private SpriteRenderer _rend;
    // Start is called before the first frame update
    void Start()
    {
        _rend = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeOut());

    }

    IEnumerator FadeOut()//para que el alpha se vaya reduciendo poco a poco 
    {
        Color color = _rend.color; // para guardar los parametros del color actual del objeto 
        for (float alpha = 1.0f; alpha >= 0; alpha -= 0.01f)
        {
            color.a = alpha;
            _rend.color = color;
            yield return new WaitForSeconds(0.02f); //devuelve el control a unity durante 0.02 seg o el tiempo establecido 
        }
        StartCoroutine(FadeIn());
    }
    IEnumerator FadeIn() //para que el alpha se vaya aumentando poco a poco 
    {
        Color color = _rend.color; // para guardar los parametros del color actual del objeto 
        for (float alpha = 0f; alpha <= 1; alpha += 0.01f)
        {
            color.a = alpha;
            _rend.color = color;
            yield return new WaitForSeconds(0.02f); //devuelve el control a unity durante 0.02 seg o el tiempo establecido 
        }
        StartCoroutine(FadeOut());
    }
}
