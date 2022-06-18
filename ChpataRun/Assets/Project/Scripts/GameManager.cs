using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject deadPlayerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnDeadPlayer(GameObject killedPlayer)
    {
        if(killedPlayer == null) {
            return;
        }
        Vector3 pos = killedPlayer.transform.position;
        Destroy(killedPlayer);
        Instantiate(deadPlayerPrefab, pos, Quaternion.identity);
        Instantiate(playerPrefab, new Vector3(-10, -4, 0), Quaternion.identity);
    }
}
