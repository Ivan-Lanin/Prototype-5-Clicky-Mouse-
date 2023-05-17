using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    private TrailRenderer trail;
    void Start()
    {
        trail = GetComponent<TrailRenderer>();
        trail.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(GetMouseWorldPosition().x, GetMouseWorldPosition().y, 0);

        if (Input.GetMouseButton(0)) {
            if (!trail.enabled) {
                trail.enabled = true;
            }
        }

        if (Input.GetMouseButtonUp(0)) {
            if (trail.enabled) {
                trail.enabled = false;
            }
        }
    }


    private Vector3 GetMouseWorldPosition() {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
