using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    [HideInInspector]
    public static int points;
    public static bool canShoot = true;

    [Header("Enemy Spawner Time Interval")]
    public float EnemyInterval;

    public GameObject enemy;
    public GameObject bullet;
    public Transform bulletSpawnerPos;
    public Transform bulletSpawnerRot;
    public Text textPoints;
    public Text textFrames;
    public Text txtBtnPlay;


    private Vector3 enemyStartPos;
    private int frameCounter;
    private bool play = true;

    private void Awake() {
        
    }

    // Start is called before the first frame update
    void Start() {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update() {
        frameCounter += 1;
        textFrames.text = "Frames: " + (frameCounter);
        textPoints.text = "Points: " + points;
    }

    public void Shoot() {
        if(canShoot)
            Instantiate(bullet, bulletSpawnerPos.transform.position, bulletSpawnerRot.transform.rotation);
    }


    public void PlayPause() {
       if (play) {
            txtBtnPlay.text = "Pause";
            Time.timeScale = 1;
            StartCoroutine("SpawnEnemy");
        } else {
            txtBtnPlay.text = "Play";
            Time.timeScale = 0;
            StopAllCoroutines();
        }
        play = !play;
    }

    public void Restart() {
        StopAllCoroutines();
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies) {
            Destroy(enemy);
        }
        StartCoroutine("SpawnEnemy");
    }

    IEnumerator SpawnEnemy() {
        while (true) {
            yield return new WaitForSeconds(EnemyInterval);
            enemyStartPos = new Vector3(Random.Range(-6, 6), 3, 4.5f);
            Instantiate(enemy, enemyStartPos, new Quaternion(0, 180, 0, 0));
        }
    }
}
