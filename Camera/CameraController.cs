using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   
    [Header("TouchObject")]
    [SerializeField] private GameObject TouchController;    

    [Header("Cameras")]
    public Camera MainCamera;
    public Camera CrossCamera;

    [Header("UI-Panels")]
    public GameObject ThirdPersonPanel;
    public GameObject FirsPersonPanel;


    void Start()
    {
        ThirdPersonPanel.SetActive(true);
        FirsPersonPanel.SetActive(false);

        TouchController.SetActive(false);

        MainCamera.enabled = true;
        CrossCamera.enabled = false;              
    }
    public void FirstPersonCameraControl()
    {
       MainCamera.enabled = false;
       CrossCamera.enabled = true;
       ThirdPersonPanel.SetActive(false);
       FirsPersonPanel.SetActive(true);

       TouchController.SetActive(true);
    }
    public void ThirdPersonCameraControl()
    { 
        CrossCamera.enabled = false;
        MainCamera.enabled = true;
        FirsPersonPanel.SetActive(false);
        ThirdPersonPanel.SetActive(true);

        TouchController.SetActive(false);
       
    }
 
    
}
