using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGet : MonoBehaviour {
    [SerializeField] private AudioSource itemGetSFX;
    private PlayerController playerController;
    private bool itemOn;


    private void Init() {
        playerController = GetComponent<PlayerController>();
    }

    private void Awake() {
        Init();
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
                ItemSpawner.instance.PointCheckers[0] = false;
                break;
            case "SpawnPoint (2)" :
                ItemSpawner.instance.PointCheckers[1] = false;
                break;
            case "SpawnPoint (3)" :
                ItemSpawner.instance.PointCheckers[2] = false;
                break;
            case "SpawnPoint (4)" :
                ItemSpawner.instance.PointCheckers[3] = false;
                break;
            case "SpawnPoint (5)" :
                ItemSpawner.instance.PointCheckers[4] = false;
                break;
            case "SpawnPoint (6)" :
                ItemSpawner.instance.PointCheckers[5] = false;
                break;    
            case "SpawnPoint (7)" :
                ItemSpawner.instance.PointCheckers[6] = false;
                break;
            case "SpawnPoint (8)" :
                ItemSpawner.instance.PointCheckers[7] = false;
                break;
            case "SpawnPoint (9)" :
                ItemSpawner.instance.PointCheckers[8] = false;
                break;
            case "SpawnPoint (10)" :
                ItemSpawner.instance.PointCheckers[9] = false;
                break;
            case "SpawnPoint (11)" :
                ItemSpawner.instance.PointCheckers[10] = false;
                break;
            case "SpawnPoint (12)" :
                ItemSpawner.instance.PointCheckers[11] = false;
                break;
            case "SpawnPoint (13)" :
                ItemSpawner.instance.PointCheckers[12] = false;
                break;
            case "SpawnPoint (14)" :
                ItemSpawner.instance.PointCheckers[13] = false;
                break;
            case "SpawnPoint (15)" :
                ItemSpawner.instance.PointCheckers[14] = false;
                break;
            case "SpawnPoint (16)" :
                ItemSpawner.instance.PointCheckers[15] = false;
                break;
            case "SpawnPoint (17)" :
                ItemSpawner.instance.PointCheckers[16] = false;
                break;
        }

    }

    private void ItemGetSFX() {
        this.itemGetSFX.Play();
    }

    private void RepairItem() {
        ItemGetSFX();

        // playerController.life +5;
        if (playerController.Life < 10) {
            playerController.Life += 1;
        }
        
        playerController.CoolDownTimer += 5;
        GameController.instance.ItemGetpoint(5);
        ItemSpawner.instance.ItemSpawn();
    }

    private void StarItem() {
        ItemGetSFX();

        // playerController.arrestGauge = 10; -> 10s
        if (!this.itemOn) {
            StartCoroutine(__StarItem());
            playerController.CoolDownTimer += 5;
        }

        GameController.instance.ItemGetpoint(5);
        ItemSpawner.instance.ItemSpawn();
    }

    IEnumerator __StarItem() {
        int i = 0;
        int scoreStep = 5;
        
        this.itemOn = true;

        while (i < 10) {    
            playerController.Score += scoreStep;
            yield return new WaitForSeconds(1);
            i++;
        }
        
        this.itemOn = false;
    }

    private void SpeedItem() {
        ItemGetSFX();

        // playerController.horsePower *2;
        // playerController.rotateSpeed *2;
        if (!this.itemOn) {
            StartCoroutine(__SpeedItem());
            playerController.CoolDownTimer += 5;
        }

        GameController.instance.ItemGetpoint(5);
        ItemSpawner.instance.ItemSpawn();
    }

    IEnumerator __SpeedItem() {
        int i = 0;
        this.itemOn = true;
        float __horsePower = playerController.HorsePower;
        float __rotateSpeed = playerController.RotateSpeed;

        playerController.HorsePower *= 1.5f;
        playerController.RotateSpeed *= 1.2f;  
        
        while (i < 10) { 
            yield return new WaitForSeconds(1);
            i++;
        }

        playerController.HorsePower = __horsePower;
        playerController.RotateSpeed = __rotateSpeed;
        this.itemOn = false;
    }

    private void CoinItem() {
        ItemGetSFX();
        
        // playerController.score +10;
        playerController.Score += 10;
        playerController.CoolDownTimer += 5;
        
        GameController.instance.ItemGetpoint(10);
        ItemSpawner.instance.ItemSpawn();
    }
}
