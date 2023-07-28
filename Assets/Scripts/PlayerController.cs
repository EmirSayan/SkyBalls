using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public float Speed = 5.0f;
    public bool hasPowerup = false;
    private float powerupStrength = 15;
    public bool gameOver;
    public GameObject PowerupIndicator;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        gameOver = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * Speed);
        PowerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        if(transform.position.y < -10)
        {
            gameOver = true;   
            Time.timeScale = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            PowerupIndicator.gameObject.SetActive(true); // Güç halkasının görünürlüğünü aktif eder
        }   
    }
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        PowerupIndicator.gameObject.SetActive(false); // Güç halkasının görünürlüğünü kapatır
    }
    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbidy = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            Debug.Log("oyuncu " + collision.gameObject.name + " ile çarpıştı" + "Güç : " + hasPowerup);
            enemyRigidbidy.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }    
    }
}
