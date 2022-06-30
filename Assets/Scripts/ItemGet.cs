using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGet : MonoBehaviour {
    [SerializeField] private bool itemRepair;
    [SerializeField] private bool itemCoin;
    [SerializeField] private bool itemSpeed;
    [SerializeField] private bool itemStar;
    [SerializeField] private ItemSpawner itemSpawner;

    private PlayerController playerController;
    private bool itemOn;


    private void Init() {
        playerController = GetComponent<PlayerController>();
    }

    private void Awake() {
        Init();
    }
    
    private void Update() {
        // DEBUG //
        if (itemCoin) {
            itemCoin = false;
            CoinItem();
        }
        if (itemRepair) {
            itemRepair = false;
            RepairItem();
        }
        if (itemSpeed) {
            itemSpeed = false;
            SpeedItem();
        }
        if (itemStar) {
            itemStar = false;
            StarItem();
        }
        // -- //
    }

    private void OnTriggerEnter(Collider other) {
        switch (other.gameObject.name) {
            case "Item_Repair(Clone)" :
                RepairItem();
                Destroy(other.gameObject);
                break;
            case "Item_Star(Clone)" :
                StarItem();
                Destroy(other.gameObject);
                break;
            case "Item_Speed(Clone)" :
                SpeedItem();
                Destroy(other.gameObject);
                break;
            case "Item_Coin(Clone)" :
                CoinItem();
                Destroy(other.gameObject);
                break;
                
            case "SpawnPoint (1)" :
                itemSpawner.PointCheckers[0] = false;
                break;
            case "SpawnPoint (2)" :
                itemSpawner.PointCheckers[1] = false;
                break;
            case "SpawnPoint (3)" :
                itemSpawner.PointCheckers[2] = false;
                break;
            case "SpawnPoint (4)" :
                itemSpawner.PointCheckers[3] = false;
                break;
            case "SpawnPoint (5)" :
                itemSpawner.PointCheckers[4] = false;
                break;
            case "SpawnPoint (6)" :
                itemSpawner.PointCheckers[5] = false;
                break;    
            case "SpawnPoint (7)" :
                itemSpawner.PointCheckers[6] = false;
                break;
            case "SpawnPoint (8)" :
                itemSpawner.PointCheckers[7] = false;
                break;
            case "SpawnPoint (9)" :
                itemSpawner.PointCheckers[8] = false;
                break;
            case "SpawnPoint (10)" :
                itemSpawner.PointCheckers[9] = false;
                break;
            case "SpawnPoint (11)" :
                itemSpawner.PointCheckers[10] = false;
                break;
            case "SpawnPoint (12)" :
                itemSpawner.PointCheckers[11] = false;
                break;
            case "SpawnPoint (13)" :
                itemSpawner.PointCheckers[12] = false;
                break;
            case "SpawnPoint (14)" :
                itemSpawner.PointCheckers[13] = false;
                break;
            case "SpawnPoint (15)" :
                itemSpawner.PointCheckers[14] = false;
                break;
            case "SpawnPoint (16)" :
                itemSpawner.PointCheckers[15] = false;
                break;
            case "SpawnPoint (17)" :
                itemSpawner.PointCheckers[16] = false;
                break;
        }

    }

    private void RepairItem() {
        // playerController.life +5;
        playerController.Life += 5;
    }

    private void StarItem() {
        // playerController.arrestGauge = 10; -> 10s
        if (!this.itemOn) {
            StartCoroutine(__StarItem());
        }
    }

    IEnumerator __StarItem() {
        int i = 0;
        this.itemOn = true;
        playerController.ArrestGauge = 100;
        playerController.ArrestGaugeStep = 0;
        while (i < 10) {    
            yield return new WaitForSeconds(1);
            i++;
        }
        playerController.ArrestGaugeStep = 0;
        this.itemOn = false;
    }

    private void SpeedItem() {
        // playerController.horsePower *2;
        // playerController.rotateSpeed *2;
        if (!this.itemOn) {
            StartCoroutine(__SpeedItem());
        }
    }

    IEnumerator __SpeedItem() {
        int i = 0;
        this.itemOn = true;
        float __horsePower = playerController.HorsePower;
        float __rotateSpeed = playerController.RotateSpeed;

        playerController.HorsePower *= 2;
        playerController.RotateSpeed *= 2;  
        
        while (i < 10) { 
            yield return new WaitForSeconds(1);
            i++;
        }

        playerController.HorsePower = __horsePower;
        playerController.RotateSpeed = __rotateSpeed;
        this.itemOn = false;
    }

    private void CoinItem() {
        // playerController.score +10;
        playerController.Score += 10;
    }

}
