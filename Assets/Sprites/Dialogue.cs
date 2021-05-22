using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{

    public Sprite[] profiles;
    public string[] speechText;
    public string actorName;

    public float radius;
    public LayerMask playerPlayer;

    private bool onRadios;
    private bool interacting;
    public DialogueControl dialogueControl;

    private void FixedUpdate()
    {
        Interact();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && !dialogueControl.gameObject.activeSelf && onRadios)
        {
            dialogueControl.Speech(profiles, speechText, actorName);
        }
    }


    public void Interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, playerPlayer);

        if(hit != null)
        {
            onRadios = true;
 
        }
        else
        {
            onRadios = false;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
