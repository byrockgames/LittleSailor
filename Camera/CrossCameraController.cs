using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossCameraController : MonoBehaviour
{
  private Touch TouchInit = new Touch();

  [Header("Cross Camera")]
  public Camera CrossCamera;

  [Header("Rotation veriables")]
  [SerializeField] private float RotSpeed;
  [SerializeField] private float Direction = -1f;
  [SerializeField] private float RotX = 0f;
  [SerializeField] private float RotY = 0f;
  public Vector3 RotOrigin;

  [Header("PlayerRotationSpine")]
  [SerializeField] private Transform PlayerSpine;
  Vector3 Rotation;
  private void Start() 
  {
    RotOrigin = CrossCamera.transform.eulerAngles;
    RotX = RotOrigin.x;
    RotY = RotOrigin.y;
  }
  private void FixedUpdate() 
  {
    foreach(Touch touch in Input.touches)
    {
       if(touch.phase == TouchPhase.Began)
       {
          TouchInit = touch;
       }
       else if(touch.phase == TouchPhase.Moved)
       {
          float DeltaX = TouchInit.position.x - touch.position.x;
          float DeltaY = TouchInit.position.y - touch.position.y;
          RotX -= DeltaY * Time.deltaTime * RotSpeed * Direction;
          RotY += DeltaX * Time.deltaTime * RotSpeed * Direction;
          RotX = Mathf.Clamp(RotX, -10f, 10f); 
          CrossCamera.transform.eulerAngles = new Vector3(RotX, RotY, 0f);
       }
       else if(touch.phase == TouchPhase.Ended)
       {
          TouchInit = new Touch();
       }
    }
    
     Vector3 RotEmpty = CrossCamera.transform.localEulerAngles;
     RotEmpty.z = 0;
     RotEmpty.y = 0;
     RotEmpty.x = CrossCamera.transform.localEulerAngles.x + 10f;

     Rotation = RotEmpty;
     PlayerSpine.transform.localEulerAngles = Rotation;
  }

}
