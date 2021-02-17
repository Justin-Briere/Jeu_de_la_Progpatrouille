using UnityEngine;

public class TestJump101 : MonoBehaviour
{
    public int forceConst = 1;
    private Rigidbody selfRigidbody;
    private Rigidbody Floor;
    float dist;
    DistanceComponents test; 
    void Start()
    {
        selfRigidbody = GetComponent<Rigidbody>();
    }

    public void Jump()   
    {
        selfRigidbody.transform.Translate(0, forceConst, 0);

        
        var allo =  (test.CalculatueDistance(selfRigidbody.gameObject, Floor.gameObject));
           Debug.Log("Distance to other: " +allo );
           
            
            
         Debug.Log ("Distance to other: " + dist);
    }
}