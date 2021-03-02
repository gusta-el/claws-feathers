using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public float maxLimitVertical;
    public float minLimitVertical;
    public float maxLimit;
    public float minLimit;
    public List<ItemFollow> itensFollow;


    [System.Serializable]
    public class ItemFollow
    {
        public Transform item;
        public float maxLimit;
        public float minLimit;
        public float moveFactor;
    }


    private Vector3 newPosition = new Vector3(0, 0, -10);
    private Vector3 lastPosition;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {

        newPosition.x = target.position.x;
        newPosition.y = target.position.y;


        if (newPosition != lastPosition)
        {

            newPosition.x = Mathf.Clamp(newPosition.x, minLimit, maxLimit);
            newPosition.y = Mathf.Clamp(newPosition.y, minLimitVertical, maxLimitVertical);

            transform.position = newPosition;



            Vector3 newPositionItem;

            foreach (ItemFollow p in itensFollow)
            {

                newPositionItem = p.item.localPosition;

                newPositionItem.x = Mathf.Clamp(newPositionItem.x, p.minLimit, p.maxLimit);

                p.item.localPosition = newPositionItem;

                if (lastPosition.x < newPosition.x)
                {
                    p.item.Translate(Vector3.left * Time.deltaTime * p.moveFactor);
                }
                else if (lastPosition.x > newPosition.x)
                {
                    p.item.Translate(Vector3.right * Time.deltaTime * p.moveFactor);
                }




            }

            lastPosition = newPosition;


        }


    }
}
