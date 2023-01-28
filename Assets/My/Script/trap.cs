using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    public float movementspeed = 1f;
    public Vector3 MovementDirection = Vector3.down;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += MovementDirection * movementspeed * Time.deltaTime;
    }
}
