using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeapon : MonoBehaviour
{
    [SerializeField] private PlayerTurn playerTurn;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootingStartPosition;

    private void Update()
    {
        bool IsPlayerTurn = playerTurn.IsPlayerTurn();
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.L))  
        {
            if (IsPlayerTurn)
            {
                TurnManager.TriggerChangeTurn();
                GameObject newProjectile = Instantiate(projectilePrefab,shootingStartPosition.position,shootingStartPosition.rotation);
                //newProjectile.transform.rotation = shootingStartPosition.rotation;
                //newProjectile.transform.position = shootingStartPosition.position;sd
                newProjectile.GetComponent<Projectile>().Initialize();
            }
        }
      
    }
}
