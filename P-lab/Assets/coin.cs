using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    collect Coin;

    private void Awake()
    {
        Coin = new collect("coin",1,0);

    }
    private void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.tag=="Player")
        {
            Destroy(gameObject);
            
        }
    }



}
