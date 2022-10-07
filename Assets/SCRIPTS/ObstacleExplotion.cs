using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleExplotion : MonoBehaviour
{

    public GameObject explosion;




    public void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
        }





       
    }


}





