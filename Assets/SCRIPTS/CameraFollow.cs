using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public Vector3 offset1;
    public Vector3 offset2;
    


    void Update()
    {


        if (TurnManager.GetInstance().IsItPlayerTurn(1))
        {
            transform.position = player1.position + offset1;
        }
        else if (TurnManager.GetInstance().IsItPlayerTurn(2)) 
        {
            transform.position = player2.position + offset1; 
        }
    }

    public void RotateCamera()
    {
        Vector3 angle = new Vector3(0, 180, 0);
        transform.Rotate(angle);
    }


}
