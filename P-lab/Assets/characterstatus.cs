using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterstatus : MonoBehaviour
{
    public int maxHealth=114;
    private int currentHealth;

    public int CurretnHealth
    {
        get
        {
            return currentHealth;
        }
    }

    public virtual void restoreHealth(int restore)
    {
        currentHealth= Mathf. Clamp(currentHealth + restore,0,maxHealth);
        Debug.Log(currentHealth);
    }




}
