using System;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float speed = 4f;
    [SerializeField] private float maxDistance = 3f;  
    [SerializeField] private float minDistance = 1f;
    [SerializeField] private float offset = 2f;  
    [SerializeField] private float sphereCastRadius = .5f;
    [SerializeField] private float sphereCastMaxLength = 1f;

    //Vector2 mouseInput = Mouse.current.delta.ReadValue();
    private void LateUpdate()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        bool hasCollided = Physics.SphereCast(ray ,sphereCastRadius, out hit, sphereCastMaxLength);

        transform.LookAt(target.transform.position);
        transform.rotation *= Quaternion.Euler(0f, offset, 0f);
        
        if (hasCollided && !hit.collider.CompareTag("Player") && !hit.collider.CompareTag("Gun"))
        {
            Vector3 newPosition = transform.position;
            transform.position = newPosition;
            Debug.Log("Collision happening");
            Debug.Log(hit.collider.name);
        }

        if (Vector3.Distance(transform.position, target.transform.position) > maxDistance)
        {
            Vector3 direction = (transform.position - target.transform.position).normalized;
            Vector3 newPosition = target.transform.position + (direction * maxDistance);

            transform.position = Vector3.Lerp(transform.position, newPosition, speed * Time.deltaTime);

        }


    }

}