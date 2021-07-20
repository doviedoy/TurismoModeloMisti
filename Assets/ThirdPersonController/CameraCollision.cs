using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    Camera cam;
    GameObject target;
    RaycastHit hit;
    float hitDistance;
    Vector3 newPosition;

    void Start()
    {
        cam = this.GetComponent<Camera>();
    }

    void Update()
    {
        target = GameObject.Find("Pivot");

        hitDistance = 4;
       
            if (Physics.Linecast(target.transform.position, this.transform.position, out hit))
            {
                Debug.DrawLine(target.transform.position, this.transform.position, Color.red);
                Debug.DrawRay(hit.point, Vector3.up);
                hitDistance = Mathf.Min(hitDistance, hit.distance);
            }
            else
            {
                Debug.DrawLine(target.transform.position, this.transform.position, Color.green);
            }
        
        if (hitDistance > 3)
        {
            hitDistance = 0;
        }
    }
    private void LateUpdate()
    {
                         //Sumo para que gire en su cara    //resto un 0.1 de diferencia    0 = igual al muro  y 1 igual al player  
        newPosition = (hit.point + new Vector3(0,0.5f,0)) - (hit.point - target.transform.position) * 0.1f;
        if (hitDistance > 0)
        {
            transform.position = newPosition;
        }
      
    }
}
