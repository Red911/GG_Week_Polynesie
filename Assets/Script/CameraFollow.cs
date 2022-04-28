using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]private Transform player;
    [SerializeField]private Transform playerTwo;
    private Camera mainCam;

    private void Awake()
    {
        mainCam = GetComponent<Camera>();
        // if (player && playerTwo == null)
        // {
        //     player = GameObject.Find("Player1(Clone)").GetComponent<GameObject>(); 
        //     playerTwo = GameObject.Find("Player2(Clone)").GetComponent<GameObject>();
        // }
        
    }
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        StartCoroutine(OnPlayerJoinedCoroutine(playerInput));
    }

    private IEnumerator OnPlayerJoinedCoroutine(PlayerInput playerInput)
    {
        print("Player ID : " + playerInput.playerIndex);
        PlayerInputHandler playerInputHandler = playerInput.GetComponent<PlayerInputHandler>();
        yield return new WaitUntil(() => playerInputHandler.Players != null);
        if (playerInput.playerIndex == 0)
        {
            player = playerInputHandler.Players.transform;
            print("J1 ON : " + player.name);
        }
        else if (playerInput.playerIndex == 1)
        {
            playerTwo = playerInputHandler.Players.transform;
            print("J2 ON : " + playerTwo.name);
        }
    }

    void Update()
    {
        if(player&& playerTwo != null)
        {
            FixedCameraFollowSmooth(mainCam,player,playerTwo);
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
