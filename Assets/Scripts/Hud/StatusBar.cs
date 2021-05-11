using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBar : MonoBehaviour
{

    public PlayerMotor player;
    private GameObject humanIcon;
    private GameObject ravenIcon;

    // Start is called before the first frame update
    void Start()
    {

        GameObject IconCharacter = transform.Find("IconCharacter").gameObject;
        humanIcon = IconCharacter.transform.Find("human_icon").gameObject;
        ravenIcon = IconCharacter.transform.Find("raven_icon").gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        UpdateCharacterStatus();
    }


    private void UpdateCharacterStatus()
    {
        humanIcon.SetActive(player.prince.IsHuman);
        ravenIcon.SetActive(player.prince.IsRaven);

    }

}
