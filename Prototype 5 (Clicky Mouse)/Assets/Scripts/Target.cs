using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;

    [SerializeField] private float minSpeed = 12;
    [SerializeField] private float maxSpeed = 14;
    [SerializeField] private float maxTorque = 10;
    [SerializeField] private float xRange = 4;
    [SerializeField] private float ySpawnPos = -2;
    [SerializeField] private int pointValue;
    [SerializeField] private ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        targetRb.AddForce(RandomForse(), ForceMode.Impulse);
        targetRb.AddTorque(new Vector3(RandomTorque(), RandomTorque(), RandomTorque()), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }


    private Vector3 RandomForse() {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }


    private float RandomTorque() {
        return Random.Range(-maxTorque, maxTorque);
    }


    private Vector3 RandomSpawnPos() {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }


    private void OnMouseDown() {
        if (gameManager.isGameActive && !gameManager.isPaused) {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }
    }


    private void OnMouseOver() {
        Debug.Log("OnMouseOver");
    }


    private void OnTriggerEnter(Collider other) {
        if (!gameObject.CompareTag("Bad") && gameManager.isGameActive) {
            gameManager.UpdateLives(1);
        }
        Destroy(gameObject);
    }
}
