using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [Header("Enemy Health")]
    [SerializeField] private int Health = 100;
    Camera Camera;

    [Header("Player")]
    [SerializeField] private GameObject Player;
    [SerializeField] private Transform[] EnemyObjects;
    void Start()
    {
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            int Strike = Random.Range(10,15);
            Touch Finger = Input.GetTouch(0);
            RaycastHit hit;
            if(Finger.phase == TouchPhase.Began)
            {
              if(Physics.Raycast(Camera.ScreenPointToRay(Finger.position), out hit, float.MaxValue))
              { 
                for(int i = 0; i < EnemyObjects.Length; i++)
                {
                  Player.transform.LookAt(EnemyObjects[i]);
                }
                            
                if(hit.rigidbody.gameObject.CompareTag("Enemy"))
                {
                  Health -= Strike;
                }

                if(Health <= 0)
                {
                  Destroy(hit.rigidbody.gameObject);
                }
              }                 
            }

            if(Finger.phase == TouchPhase.Ended)
            {
              Player.transform.rotation = Quaternion.Euler(0,0,0);
            }                              
        }
       
    }

   
}
