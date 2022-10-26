using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    [SerializeField] private Transform Target;
    [SerializeField] private Transform LookTarget;
    [SerializeField] private Vector3 Offset;
    private float Speed;

    private void LateUpdate() 
    {
        Vector3 DPos = Target.position + Offset;
        Vector3 SPos = Vector3.Lerp(transform.position, DPos, Speed * Time.deltaTime);
        transform.position = SPos;
        transform.LookAt(LookTarget.position);
    }
}
