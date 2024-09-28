using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosives : MonoBehaviour
{
    private ParticleSystem particleSystem;
    private GameObject parent;
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        parent = transform.parent.gameObject;

        StartCoroutine(ExplosionTimer());
    }

    private IEnumerator ExplosionTimer()
    {
        yield return new WaitForSeconds(5); // time took for the explosion to start
        StartCoroutine(Explosion());
    }


    private IEnumerator Explosion()
    {
        transform.parent = null;
        Destroy(parent);// destroys object it's attatched to
        particleSystem.Play();
        yield return new WaitForSeconds(particleSystem.duration);
        Destroy(this.gameObject);
    }
}
