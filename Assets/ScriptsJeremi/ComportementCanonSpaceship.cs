using UnityEngine;

public class ComportementCanonSpaceship : MonoBehaviour
{
   [SerializeField]
   KeyCode Key;

   [SerializeField]
   GameObject Bullet;

   [SerializeField]
   float Speed = 10f;

   [SerializeField]
   float ReloadTime = 0.2f;

   [SerializeField]
   Transform CanonMouth;

    bool IsReloading { get; set; }
    float TimeBetweenReload { get; set; }


    void Start() //Start puisque ne je load pas d'objet, seulement des variables
    {
        IsReloading = false;
        TimeBetweenReload = ReloadTime;
    }

    void Update()
    { 
        TimeBetweenReload += Time.deltaTime;
        IsReloading = TimeBetweenReload < ReloadTime;

        if (!IsReloading)
        {
            if (Input.GetKey(Key))
            {
                var player = Instantiate(Bullet, CanonMouth.position, CanonMouth.rotation);
                player.GetComponent<Rigidbody>().AddForce(player.transform.forward * Speed);
                TimeBetweenReload = 0;
            }
        }
        
    }

}
