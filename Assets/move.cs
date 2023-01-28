using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move23 : MonoBehaviour
{
    private Vector3 movement;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float yukarý = 2f;
    public float SolLimit = -5;
    public float SagLimit = 5;

    //public float moveBackAmount = 3f;
    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Tumsek"))
    //    {
    //        transform.Translate(Vector3.left * moveBackAmount);
    //    }
    //}

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 10), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
        float x = Input.GetAxis("Horizontal") * speed  * Time.deltaTime;
        //float z = Input.GetAxis("Vertical") * speed * yukarý * Time.deltaTime;
        movement = new Vector3(x, 0f);
        transform.position += movement;
        float xPos = Mathf.Clamp(transform.position.x, SolLimit, SagLimit);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
       

    }
    private void OnTriggerEnter(Collider collision)
    {
        // fiziksel obje collision, temas etme
        if (collision.gameObject.tag == "Tiken")
        {
            // temas edildiðinde oyunu durdur
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }   
    }
}