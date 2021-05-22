using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueControl : MonoBehaviour
{

    [Header("Components")]
    public GameObject dialogueObj;
    public Image profile;
    private Sprite[] profiles;
    public TMP_Text speechText;
    public TMP_Text actorNameText;

    [Header("Settings")]
    public float typingSpeed;
    private string[] sentences;
    private int index;

    public void Speech(Sprite[] sprites, string[] txt, string actorName)
    {
        dialogueObj.SetActive(true);
        sentences = txt;
        actorNameText.text = actorName;
        profiles = sprites;
        StartCoroutine(TypeSentences());

    }

    IEnumerator TypeSentences()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            profile.sprite = profiles[index];
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
          if(speechText.text == sentences[index])
        {
            if(index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentences());
            } else
            {
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
            }
        }

    }



}
