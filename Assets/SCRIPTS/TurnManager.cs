using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private static TurnManager instance;
    [SerializeField] private PlayerTurn playerOne;
    [SerializeField] private PlayerTurn playerTwo;
    [SerializeField] private float timeBetweenTurns;
    [SerializeField] public CountDown countDown;
    public CameraFollow cameraFollow;

    private int currentPlayerIndex;
    private bool waitingForNextTurn;
    private float turnDelay;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            currentPlayerIndex = 1;
            playerOne.SetPlayerTurn(1);
            playerTwo.SetPlayerTurn(2);
        }
    }

    private void Start()
    {
        
    }

    public static bool IsWaitingForNextTurn()
    {
        return GetInstance().waitingForNextTurn;
    }

    private void Update()
    {
        if (waitingForNextTurn)
        {
            turnDelay += Time.deltaTime;
            if (turnDelay >= timeBetweenTurns)
            {
                turnDelay = 0;
                waitingForNextTurn = false;
                ChangeTurn();
            }
        }
    }

    public bool IsItPlayerTurn(int index)
    {
        if (waitingForNextTurn)
        {
            return false;
        }

        return index == currentPlayerIndex;
    }

    public static TurnManager GetInstance()
    {
        return instance;
    }

    public static void TriggerChangeTurn()
    {
        GetInstance().waitingForNextTurn = true;
        GetInstance().countDown.timeStart = 8;
    }

    private void ChangeTurn()
    {
        if (currentPlayerIndex == 1)
        {
            currentPlayerIndex = 2;
            Debug.Log(currentPlayerIndex);
        }
        else if (currentPlayerIndex == 2)
        {
            currentPlayerIndex = 1;
            //cameraFollow.RotateCamera();
            Debug.Log(currentPlayerIndex);
        }
    }
}
