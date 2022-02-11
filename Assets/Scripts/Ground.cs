using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] MovingObject _movingObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Ground")))
            {
                //Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);

                if (hit.normal == Vector3.up)
                {
                    //Debug.Log("Its upper face" + hit.point);
                    _movingObject.AddWayPoint(hit.point);
                }
            }
        }
    }
}
