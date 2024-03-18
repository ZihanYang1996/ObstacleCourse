using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    Color originalColor;
    Color hitColor = Color.red;
    Color initialColor;
    Color targetColor;

    bool isTransitioning = false;
    float transitionDuration = 0.25f;
    float timeElapsed = 0;
    MeshRenderer wallMeshRenderer;

    void Awake()
    {
        wallMeshRenderer = GetComponent<MeshRenderer>();
        originalColor = wallMeshRenderer.material.color;
    }
    void Update()
    {
        if (isTransitioning)
        {
            ColorTransition();
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" && gameObject.tag != "Hit")
        {
            if (gameObject.tag == "Obstacle") gameObject.tag = "Hit";
            timeElapsed = 0;
            initialColor = wallMeshRenderer.material.color;
            targetColor = hitColor;
            isTransitioning = true;
        }

    }

    void OnCollisionExit(Collision other)
    {
        if (gameObject.tag != "Hit")
        {
            timeElapsed = 0;
            initialColor = wallMeshRenderer.material.color;
            targetColor = originalColor;
            isTransitioning = true;
        }

    }

    void ColorTransition()
    {
        if (timeElapsed < transitionDuration)
        {
            float r, g, b, a;
            r = Mathf.Lerp(initialColor.r, targetColor.r, timeElapsed / transitionDuration);
            g = Mathf.Lerp(initialColor.g, targetColor.g, timeElapsed / transitionDuration);
            b = Mathf.Lerp(initialColor.b, targetColor.b, timeElapsed / transitionDuration);
            a = Mathf.Lerp(initialColor.a, targetColor.a, timeElapsed / transitionDuration);
            wallMeshRenderer.material.color = new Color(r, g, b, a);
            timeElapsed += Time.deltaTime;
        }
        else
        {
            isTransitioning = false;
            timeElapsed = 0;
        }
    }
}
