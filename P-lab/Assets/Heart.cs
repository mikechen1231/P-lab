using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    // Start is called before the first frame update
    private collect heart;
    private void Start()
    {
        heart = new collect("heart",0,5);

    }
    private void OnCollisionEnter(Collision other )
    {
        if(other.collider.tag=="Player")
        {
            Debug.Log("health+1");
            Destroy(gameObject);
        }
    }
}
