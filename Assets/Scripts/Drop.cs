using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{

    Rigidbody rb;
    MeshRenderer meshRenderer;

    [SerializeField] float timeToWait = 3f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();

        rb.useGravity = false;
        meshRenderer.enabled = false;
    }
    void Update()
    {
        if (Time.time > timeToWait)
        {
            rb.useGravity = true;
            meshRenderer.enabled = true;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            rb.isKinematic = true;
        }
    }
}
