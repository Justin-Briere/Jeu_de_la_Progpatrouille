
using UnityEngine;

public class ComportementProjectile : MonoBehaviour  // Script de la dernière session servant au projectile du Galaga.
{
    [SerializeField]
    float lifetime = 0.2f;

    [SerializeField]
    GameObject Explosion;

    float explosionTime = 2f;

    void Update()
    {
        float timeSpent = 0; 
        
        timeSpent += Time.deltaTime;
        if (timeSpent > lifetime)
            Destroy(gameObject); 
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(Explosion) 
        {
            GameObject spawn = Instantiate(Explosion, transform.position, Explosion.transform.rotation);
            Destroy(spawn, explosionTime); 
        }
        
        Destroy(gameObject);
    }
}