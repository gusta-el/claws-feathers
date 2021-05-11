using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TitleDirector : MonoBehaviour
{

    private TMP_Text m_TextMeshPro;
    private float alphaColor = 0f;
    private const int FADE_IN = 1;
    private const int FADE_OUT = 2;
    private const int FADE_PAUSE = 3;
    private const int FADE_OFF = 4;

    private int fade = FADE_IN;

    public int fadeInTime;
    public int fadeOutTime;
    public int fadePauseTime;
    private float fadePauseTimeAux = 0;

    void Awake()
    {
        m_TextMeshPro = GetComponent<TMP_Text>();
        changeAlphaColor();
    }

    void Update()
    {
        m_TextMeshPro.ForceMeshUpdate();

        switch (fade)
        {
            case FADE_IN:
                StartCoroutine(FadeInCoroutine(fadeInTime));
                break;
            case FADE_OUT:
                StartCoroutine(FadeOutCoroutine(fadeOutTime));
                break;
            case FADE_PAUSE:
                StartCoroutine(FadePauseCoroutine(fadePauseTime));
                break;
            default:
                break;
        }

    }

    IEnumerator FadeInCoroutine(int fadeTime)
    {
        alphaColor += (Time.deltaTime / fadeTime) * 2;
        changeAlphaColor();

        if(alphaColor >= 1)
        {
            fade = FADE_PAUSE;
        }

        yield return m_TextMeshPro;
        
    }


    IEnumerator FadePauseCoroutine(int fadeTime)
    {

        fadePauseTimeAux += Time.deltaTime;
       
        if (fadePauseTimeAux >= fadeTime)
        {
            fadePauseTimeAux = 0;
            fade = FADE_OUT;
        }

        yield return fadeTime;

    }


    IEnumerator FadeOutCoroutine(int fadeTime)
    {
        alphaColor -= (Time.deltaTime / fadeTime) * 2;
        changeAlphaColor();

        if(alphaColor <= 0)
        {
            fade = FADE_OFF;
        }

        yield return m_TextMeshPro;

    }

    private void changeAlphaColor()
    {
        Color color = m_TextMeshPro.color;
        color.a = alphaColor;
        m_TextMeshPro.color = color;
    }

}
