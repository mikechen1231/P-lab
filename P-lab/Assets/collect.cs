using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect : MonoBehaviour
{
    public string nameOfCollectable;
    public int scoress;
    public int gainHealth;

    // Start is called before the first frame update
    public collect(string name,int gainpoint,int addhealth )
    {
        this.nameOfCollectable=name;
        this.scoress=gainpoint;
        this.gainHealth=addhealth;
    }
    public void UPDATE_SCORE()
    {
        score.manager.UpdateScore(scoress);
    }
    public void UPDATE_ADDHEALTH()
    {
        PlayerManager.playermanager.player.GetComponent<characterstatus>().restoreHealth(this.gainHealth);

    }
}
