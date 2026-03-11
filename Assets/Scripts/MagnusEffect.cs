using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MagnusSoccerKick : MonoBehaviour
{
    [SerializeField] public float KickForce = 0f;
    [SerializeField] public float SpinAmount = 0f;
    [SerializeField] public float MagnusStrength = 0.5f;
    private Rigidbody rb;

    private bool isShot = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isShot == false)
        {
            isShot = true;
            rb.AddForce(Vector3.right * KickForce, ForceMode.Impulse);
            rb.AddTorque(Vector3.up * SpinAmount);
        }

    }

    void FixedUpdate()
    {
        if (!isShot)
        {
            return;
        }

        Vector3 velocity = rb.linearVelocity;
        Vector3 spin = rb.angularVelocity;

        Vector3 magnusForce = MagnusStrength * Vector3.Cross(spin, velocity);

        rb.AddForce(magnusForce);
    }
}