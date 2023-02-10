using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform bulletSpawnpos;
    [SerializeField]
    private float minwait = 1f, maxwait = 4f;
    private float waitTime;
    public float bulletspeed = 55f;

    void Shoot()
    {
        GameObject newbullet= Instantiate(bullet, this.transform.position + new Vector3(1, 0, 0), this.transform.rotation) as GameObject;
        Rigidbody bulletRB = newbullet.GetComponent<Rigidbody>();
        bulletRB.velocity = this.transform.forward * bulletspeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        waitTime = Time.time + Random.Range(minwait, maxwait);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > waitTime)
        {
            waitTime = Time.time + Random.Range(minwait, maxwait);
            Shoot();
        }
    }
}
