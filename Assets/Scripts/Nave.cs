using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Nave : MonoBehaviour
{

    [SerializeField]
    float maxRelativeVelocity = 2f;
    [SerializeField]
    float maxRotation = 10f;

    [SerializeField]
    float thrustForce = 150f;
    [SerializeField]
    float torqueForce = 25f;




    [SerializeField]
    float gasoleo = 500f;
    [SerializeField]
    float forçagasoleo = 10f;
    [SerializeField]
    float gasoleoTorque = 5f;

    [SerializeField]
    TMP_Text txtfuelValue;
  


     void Start()
    {
       
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (gasoleo > 0)
            {
                GetComponent<Rigidbody2D>().AddForce(thrustForce * transform.up * Time.deltaTime);

            }
            
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (gasoleo > 0 )
            {
                GetComponent<Rigidbody2D>().AddTorque(-torqueForce * Time.deltaTime);
                gasoleo -= forçagasoleo * Time.deltaTime;

            }

        } else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (gasoleo > 0 )
            {
                GetComponent<Rigidbody2D>().AddTorque(torqueForce * Time.deltaTime);
                gasoleo -= forçagasoleo * Time.deltaTime;
            }
            
        }

        txtfuelValue.text = Mathf.RoundToInt(gasoleo).ToString();
     }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
       
        if (collision.gameObject.tag == "Plattaform") 
        {
            // bati na plataforma 
            Debug.Log("Aterrei na plataforma");
            if ( collision.relativeVelocity.magnitude > maxRelativeVelocity || Mathf.Abs (transform.localEulerAngles.z) < maxRotation)
            {
                Debug.Log("Mas rebentei!");

            }


        } else
        {
            Debug.Log(" Bati na Lua...explodi!");

        }

    }
}
