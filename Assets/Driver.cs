using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 200.0f;
    [SerializeField] float driveSpeed = 15.0f;

    [SerializeField] float slowSpeed = 7.0f;
    [SerializeField] float fastSpeed = 25.0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float driveAmount = Input.GetAxis("Vertical") * driveSpeed * Time.deltaTime;


        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, driveAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        driveSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Booster")
        {
            driveSpeed = fastSpeed;
        }
    }
}