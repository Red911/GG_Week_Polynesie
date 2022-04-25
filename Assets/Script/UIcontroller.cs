using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    PlayerBehaviour player;
    private Text distanceText;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerBehaviour>();
        distanceText = GameObject.Find("DistanceText").GetComponent<Text>();;
    }

    // Update is called once per frame
    void Update()
    {
        int distance = Mathf.FloorToInt(player.distance);
        distanceText.text = distance + " m";
    }
}
