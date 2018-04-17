using UnityEngine;

public class RoughCamera : MonoBehaviour
{

    public Transform target;

    public Vector3 offset;

    private void Start()
    {
        transform.position = target.position + offset;
    }


    void LateUpdate()
    {
        Vector3 vect;
        vect = target.position + offset;
        vect.y = transform.position.y;
        transform.position = vect; 
        
    }
}
