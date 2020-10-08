using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Invector;

public class setSpawn : MonoBehaviour
{
    [Tooltip("Required gameController on any object that contain spawnpoint transfrom")]
    public vGameController gameController;

    [SerializeField]
    private Transform spawnPoint;

    GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        //gameController = GameObject.Find("GameController").GetComponent<vGameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        
        if (other.tag =="Player") 
        {
        gameController.spawnPoint = spawnPoint;
        _player.GetComponent<TouchingKillZone>().TeleportTo = spawnPoint;
        gameObject.SetActive(false);
        }
    }
}
