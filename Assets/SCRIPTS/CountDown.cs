using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using static UnityEditor.Experimental.GraphView.GraphView;

public class CountDown : MonoBehaviour
{

    public float timeStart = 8;
    [SerializeField] public Text textBox;


    void Start()
    {
        textBox.text = timeStart.ToString();
    }

    
    void Update()
    {
        
        textBox.text = Mathf.Round(timeStart).ToString();

        if(timeStart <= 0)
        {
            timeStart = 8;
            TurnManager.TriggerChangeTurn();
        }
        if (TurnManager.GetInstance().IsItPlayerTurn(1))
        {
            textBox.text = Mathf.Round(timeStart).ToString();
        }
        if (TurnManager.GetInstance().IsItPlayerTurn(2))
        {
            textBox.text = Mathf.Round(timeStart).ToString();
        }

        if (!TurnManager.IsWaitingForNextTurn())
        {
            timeStart -= Time.deltaTime;
        }


    }
}
