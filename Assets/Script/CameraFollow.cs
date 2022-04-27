using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]private GameObject player;
    [SerializeField]private GameObject playerTwo;
    private Camera mainCam;

    private void Awake()
    {
        mainCam = GetComponent<Camera>();
        if (player && playerTwo == null)
        {
            player = GameObject.Find("Player1(Clone)").GetComponent<GameObject>(); 
            playerTwo = GameObject.Find("Player2(Clone)").GetComponent<GameObject>();
        }
        
    }
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        // print("Player ID : " + playerInput.playerIndex);
        // if (playerInput.playerIndex == 0)
        // {
        //     player = playerInput.GetComponent<Player>();
        // }
        // else if (playerInput.playerIndex == 1)
        // {
        //     playerTwo = playerInput.GetComponent<Player>();
        // }
    }
    void Update()
    {
        if(player&& playerTwo != null)
        {
            FixedCameraFollowSmooth(mainCam,player.transform,playerTwo.transform);
        }
    }
    
    public void FixedCameraFollowSmooth(Camera cam, Transform t1, Transform t2)
    {
        
        float zoomFactor = 1.5f;
        float followTimeDelta = 0.8f;
 
        
        Vector3 direction = (t1.position + t2.position) / 2f;
        
        float distance = (t1.position - t2.position).magnitude;
        
        Vector3 cameraDest = direction - cam.transform.forward * distance * zoomFactor;
        
        if (cam.orthographic)
        {
            cam.orthographicSize = distance;
        }
       
        cam.transform.position = Vector3.Slerp(cam.transform.position, cameraDest, followTimeDelta);

        if ((cameraDest - cam.transform.position).magnitude <= 0.05f)
        {
            cam.transform.position = cameraDest;
        }
            
    }

    
    
    
}
