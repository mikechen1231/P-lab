using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect : MonoBehaviour
{
    public int scores;
    // Start is called before the first frame update
 public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            score.manager.UpdateScore(scores);
            Destroy(gameObject);
        }
    }
}
