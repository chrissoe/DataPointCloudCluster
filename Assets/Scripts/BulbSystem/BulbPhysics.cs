using UnityEngine;
using System.Collections;

public class BulbPhysics : MonoBehaviour
{
    // Public Variables
    internal float magnetStrength = 2f;

    // Private Variables
    private Transform trans;
    private Rigidbody thisRd;
    private float magnetDistanceStr;

    // This will be the monthly difference between KPIs
    private float difference;

    // Friction Variables
    private Vector3 currentSpeed;
    private Vector3 opposingForce;

    void Awake()
    {
        trans = transform;
        thisRd = trans.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        // If there is no test JSON file you can use random values
        //difference = Random.Range(5f, 30f); // GetComponent<BulbData>().

        // If there is a JSON file you can use the real values to manipulate the cluster behaviour
        difference = (GetComponent<BulbData>().Contentvalue3.Item2 - GetComponent<BulbData>().Contentvalue3.Item1) / 10000f;

        Debug.Log("Difference " + difference.ToString());
        trans.localScale *= difference / 4f;
    }

    void Update()
    {
        // Magnet push
        ApplyMagnetPhysics();

        // Friction
        if (thisRd.velocity.magnitude > 0f)
        {
            ApplyFriction();
        }

        // Prevent the bulbs to move below y-axis
        if (trans.position.y < GameManager.instance.forceFromYAxis)
            thisRd.AddForce(new Vector3(0f ,GameManager.instance.forceFromYAxis / trans.position.y));
    }

    void ApplyMagnetPhysics()
    {
        // Move when magnet is in radius
        Vector3 directionToMagnet = GameManager.instance.magnetTrans.position - trans.position;
        float distance = Vector3.Distance(GameManager.instance.magnetTrans.position, trans.position);
        
        if (difference < GameManager.instance.treshold)
        {
            GetComponent<Renderer>().material.color = Color.green;

            // Pulling towards the magnet
            magnetDistanceStr = (difference / 2f) / distance;
            Debug.Log("magnetDistanceStr: " + magnetDistanceStr.ToString());
            if (magnetDistanceStr <= 13f)
                return;
            thisRd.AddForce(magnetDistanceStr * (directionToMagnet * -1), ForceMode.Force);
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.red;

            // Pushing away from magnet as it stands out
            magnetDistanceStr = (difference / 2f) / distance;
            Debug.Log("magnetDistanceStr: " + magnetDistanceStr.ToString());
            if (magnetDistanceStr <= 10f)
                return;
            thisRd.AddForce(magnetDistanceStr * (directionToMagnet * -1), ForceMode.Force);
        }
    }

    void ApplyFriction()
    {
        currentSpeed = thisRd.velocity;
        opposingForce = -currentSpeed;
        thisRd.AddForce(opposingForce * GameManager.instance.decelleration);
    }
}