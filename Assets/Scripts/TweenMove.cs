using UnityEngine;
using System.Collections;

public class TweenMove : MonoBehaviour
{
    public Transform targetTransform;
    public float moveTime = 0.3f;
    //public float rotateTime = 0.7f;
    private Vector3 currentMoveSpeed = Vector3.zero;
    //private Vector3 currentRotateSpeed = Vector3.zero;

    public void SetTarget(Transform t)
    {
        //currentMoveSpeed = Vector3.zero;
        //currentRotateSpeed = Vector3.zero;
        targetTransform = t;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetTransform == null) return;
        //if (moveTime == 0)
        //    transform.position = targetTransform.position;
        //else
        //{
        Vector3 position = Vector3.SmoothDamp(transform.position, targetTransform.position, ref currentMoveSpeed, moveTime);

        //Vector3 targetRotation = targetTransform.eulerAngles;
        //float x = targetRotation.x;
        //float y = targetRotation.y;
        //float z = targetRotation.z;

        //if (x - transform.eulerAngles.x > 180) x -= 360f;
        //if (y - transform.eulerAngles.y > 180) y -= 360f;
        //if (z - transform.eulerAngles.z > 180) z -= 360f;

        //if (transform.eulerAngles.x - x > 180) x += 360f;
        //if (transform.eulerAngles.y - y > 180) y += 360f;
        //if (transform.eulerAngles.z - z > 180) z += 360f;

        //targetRotation = new Vector3(x, y, z);
        //Vector3 rotation = Vector3.SmoothDamp(transform.eulerAngles, targetRotation, ref currentRotateSpeed, rotateTime);

        transform.position = position;
        //transform.eulerAngles = rotation;
        //}
    }
}