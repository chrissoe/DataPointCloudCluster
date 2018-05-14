using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.SpatialMapping;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    // Values to tweak the magnetic functionality    
    //[SerializeField] internal int amountOfObjectsToSpawn = 10;
    [SerializeField] internal float spawnDistanceToParent = 0.2f;
    [SerializeField] internal float decelleration = 1.5f;
    [SerializeField] internal float forceFromYAxis = 1.5f;
    [SerializeField] internal float[] magnetStrengthRange = new float[2] { 0.3f, 1.5f };

    [SerializeField] internal Transform magnetTrans;
    [SerializeField] internal TapToPlace Placer;

    [SerializeField] internal float treshold = 25f;

    internal GameObject SphereSystem;

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Placer != null)
        {
            // When the hololens user tapped, isBeingPlaced will be false
            if (!Placer.IsBeingPlaced)
            {
                Transform placerObject = Placer.gameObject.transform;
                Destroy(Placer.gameObject);
                SphereSystem = Instantiate(Resources.Load("SphereSystem", typeof(GameObject)), new Vector3(placerObject.position.x, placerObject.position.y + 2f, placerObject.position.z), placerObject.rotation) as GameObject;
            }
        }
    }
}