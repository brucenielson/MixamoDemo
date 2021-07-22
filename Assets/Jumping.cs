using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    private Rigidbody rb;
    private float randomInterval;
    private float timer = 0.0f;
    private float min = 0.5f;
    private float max = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        randomInterval = Random.Range(min, max);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        RaycastHit hitInfo;
        bool grounded = Physics.Raycast(transform.position, Vector3.down, out hitInfo, 1.0f);
        if (grounded)
        {
            if (timer > randomInterval)
            {
                Vector3 force = new Vector3(Random.Range(-100.0f, 100.0f), Random.Range(25.0f, 100.0f), Random.Range(-100.0f, 100.0f));
                rb.AddForce(force, ForceMode.Impulse);
                rb.AddTorque(force / 5.0f, ForceMode.Impulse);
                randomInterval = Random.Range(min, max);
                timer = 0.0f;
            }
        }
    }
}
