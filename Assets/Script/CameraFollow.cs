using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    }
    
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        StartCoroutine(OnPlayerJoinedCoroutine(playerInput));
    }

    private IEnumerator OnPlayerJoinedCoroutine(PlayerInput playerInput)
    {
       
        PlayerInputHandler playerInputHandler = playerInput.GetComponent<PlayerInputHandler>();
        yield return new WaitUntil(() => playerInputHandler.Players != null);
        if (playerInput.playerIndex == 0)
        {
            player = playerInputHandler.Players.gameObject;
            
            
        }
        else if (playerInput.playerIndex == 1)
        {
            playerTwo = playerInputHandler.Players.gameObject;
           
            
        }
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

        if (cam.orthographicSize >= 30f)
        {
            cam.orthographicSize = 30f;
        }
    }

    
    
    
}
