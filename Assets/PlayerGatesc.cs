using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class PlayerGatesc : MonoBehaviour
{
    public Transform player;
    private int OyuncuSay;
    [SerializeField] private TextMeshPro Countertxt;
    [SerializeField] private GameObject Oyuncu;
    [Range(0f, 1f)][SerializeField] private float DistanceFactor, Radius;
    
    void Start()
    {
        player = transform;
        OyuncuSay = transform.childCount - 1;
        Countertxt.text = OyuncuSay.ToString();

    }


    void Update()
    {

    }

    private void FormatOyuncu()
    {
        for (int i=0; 1 < player.childCount; i++) 
        {
            var x = DistanceFactor * Mathf.Sqrt(i) * Mathf.Cos(i * Radius);
            var z = DistanceFactor * Mathf.Sqrt(i) * Mathf.Sin(i * Radius);
            var NewPos = new Vector3(x,y:-0.55f,z);
            player.GetChild(i).DOLocalMove(NewPos,1f).SetEase(Ease.OutBack);
            
            
        }
    }
    private void MakeOyuncu(int number)
    {
        for (int i = 0; i < number; i++)

        {
            Instantiate(Oyuncu, transform.position, Quaternion.identity, transform);
        }
        Countertxt.text = OyuncuSay.ToString();

        FormatOyuncu();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("kapi"))
        {
            other.transform.parent.GetChild(0).GetComponent<Collider>().enabled = false; //kapý 1
            other.transform.parent.GetChild(0).GetComponent<Collider>().enabled = false; //kapý 2

            var gateManager = other.GetComponent<GateManager>();
            if (gateManager.multiply)
            {
                MakeOyuncu(OyuncuSay * gateManager.randomNumber);
            }
            else
            {
                MakeOyuncu(OyuncuSay + gateManager.randomNumber);
        
            }
            
                void OnCollisionEnter(Collision collision)
                {
                    if (collision.gameObject.CompareTag("Tuzak"))

                    {
                    transform.parent.GetChild(-20).GetComponent<Collider>().enabled = true;
                    }
                }
        }
    }
}


