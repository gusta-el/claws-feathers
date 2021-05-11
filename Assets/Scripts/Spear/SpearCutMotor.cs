using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearCutMotor : MonoBehaviour
{

    public GameObject cutHitObj;

    public void CutEnemy2(Vector3 cutPos)
    {   
        var cutHit = Instantiate(cutHitObj, cutPos, Quaternion.identity);
    }


}
