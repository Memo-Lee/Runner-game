using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class move : MonoBehaviour
{
    private Vector3 movement;
    [SerializeField] private float hiz = 10f;
    [SerializeField] private float ileri = 2f; //Test için hýz
    public float solLimit = -5;
    public float sagLimit = 5;
    public float savurma = 3f;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tumsek"))
        {
            transform.Translate(Vector3.back * savurma);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float x = Input.GetAxis("Horizontal") * hiz  * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * hiz * ileri * Time.deltaTime;
        movement = new Vector3(x, 0f , z);
        transform.position += movement;
        float xPos = Mathf.Clamp(transform.position.x, solLimit, sagLimit);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
       

    }
}