 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{
    public static score manager;
 
    int CurrentScore = 0;

    // Start is called before the first frame update
    private void Awake()
    {
        if (manager == null)
        {
            manager = this; 
        }
    }

    // Update is called once per frame
    public void UpdateScore(int scores)
    {
        CurrentScore += scores;
        Debug.Log(CurrentScore);
    }
}
