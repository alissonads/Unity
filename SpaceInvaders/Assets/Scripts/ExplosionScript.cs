using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    //private ParticleSystem particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        //particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    /*void FixedUpdate()
    {
        if (particleSystem.isStopped)
        {
            Destroy(gameObject);
        }
    }*/

    private void EndAnim()
    {
        Destroy(gameObject);
    }
}
