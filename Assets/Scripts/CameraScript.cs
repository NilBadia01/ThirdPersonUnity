using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private GameObject target;
    //[SerializeField] private float speed = 4f;
    [SerializeField] private float maxDistance = 3f;  
    [SerializeField] private float minDistance = 1f;  
    [SerializeField] private float sphereCastRadius = .5f;
    [SerializeField] private float sphereCastMaxLength = 1f;

    //Vector2 mouseInput = Mouse.current.delta.ReadValue();
    private void LateUpdate()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        bool hasCollided = Physics.SphereCast(ray ,sphereCastRadius, out hit, sphereCastMaxLength);

        transform.LookAt(target.transform);
        
        if (hasCollided && !hit.collider.CompareTag("Player") && !hit.collider.CompareTag("Gun"))
        {
            Vector3 newPosition = transform.position + new Vector3(1f, 0, 0);
            transform.position = newPosition;
            Debug.Log("Collision happening");
            Debug.Log(hit.collider.name);
        }

        if (Math.Abs(Vector3.Distance(transform.position, target.transform.position)) > maxDistance)
        {
            Vector3 newPosition = target.transform.position - transform.position;
            transform.position = Vector3.Lerp(transform.position, newPosition + new Vector3(2f, 4f, 0), Time.deltaTime);

        }

        else if (Math.Abs(Vector3.Distance(transform.position, target.transform.position)) < minDistance) // This might have to go
        {
            Vector3 newPosition = target.transform.position - transform.position;
            transform.position = Vector3.Lerp(transform.position, newPosition + new Vector3(2f, 4f, 0), Time.deltaTime);
            Debug.Log("Player is too close to the camera");
        }


    }

}