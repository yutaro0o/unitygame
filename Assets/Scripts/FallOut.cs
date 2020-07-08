using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOut : MonoBehaviour
{
    public GameObject playerPrefab;//playerを格納
    PlayerHPBar playerhp;
    public Transform respawn; //respawnを格納
    public Transform fallout; //falloutを格納

    // Use this for initialization
    void Start()
    {
        playerhp = playerPrefab.GetComponent<PlayerHPBar>();
    }

    // Update is called once per frame
    void Update() 
    { 
    
    }

    void OnTriggerEnter(Collider other)　　//falloutにplayerがあたると
    {
        if (other.transform == fallout)
        {
            transform.position = respawn.position;   //playerがあたると respawnの位置へ移動
            playerhp.Damaged(50); //落下時はHPが50減る
        }

    }
}