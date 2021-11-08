using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectTowardsPlayer : MonoBehaviour
{
    [Header("Components")]
    private Transform transform;
    public SpeedController speedController;

    [Header("Movement Variables")]
    private Vector3 target;
    public float objectMovementSpeedMultiplicator;
    public float objectSpeed = 0;
    public float maxObjectSpeed = 20;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateSpeed();
        target = transform.position;
        target.z -= objectSpeed * Time.deltaTime;
        transform.position = target;
    }

    private void CalculateSpeed()
    {
        if (speedController.speed * objectMovementSpeedMultiplicator <= maxObjectSpeed)
        {
            //We put 2 at the start so it has some interesting speed even if speed = 1
            objectSpeed = 2 + speedController.speed * objectMovementSpeedMultiplicator;
        }
        else
        {
            objectSpeed = 2 + maxObjectSpeed;
        }
    }

}
