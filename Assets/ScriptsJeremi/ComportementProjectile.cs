
using UnityEngine;

public class ComportementProjectile : MonoBehaviour
{
    [SerializeField]
    float DuréeVie = 0.2f;

    [SerializeField]
    GameObject Explosion;

    float explosionTime = 2f;

    void Update()
    {
        float timeSpent = 0; 
        
        timeSpent += Time.deltaTime;
        if (timeSpent > DuréeVie)
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