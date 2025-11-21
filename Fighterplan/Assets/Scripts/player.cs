using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isShieldActive = false;
    public float shieldDuration = 5f;
    private float shieldTimer;
    public int lives;
    private float playerSpeed;
    private float horizontalInput;
    private GameManager gameManager;

    //private float verticalInput;

    private float horizontalScreenLimit = 9.5f;
    private float verticalScreenLimit = 6.5f;

    public GameObject shieldVisual;
    public GameObject bulletPrefab;
    public GameObject explosionPrefab;

    //Sounds
    public AudioSource sfxSource;
    public AudioClip shieldOnClip;
    public AudioClip shieldOffClip;
    public AudioClip Explosion;
    public AudioClip CoinSound;
    public AudioClip Shot;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        lives = 3;
        playerSpeed = 6f;
        gameManager.ChangeLivesText(lives);
        //This function is called at the start of the game

    }
    public void LoseALife()
    {
        if (isShieldActive)
        {
            DeactivateShield(); 
            return;
        }
        if (sfxSource != null && Explosion != null)
        {
            sfxSource.PlayOneShot(Explosion);
        }

        lives--;
        gameManager.ChangeLivesText(lives);

        if (lives == 0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            sfxSource.PlayOneShot(Explosion);
            Destroy(this.gameObject);
        }
        
    }
    public void ActivateShield()
    {
        isShieldActive = true;
        shieldTimer = shieldDuration;

        if (shieldVisual != null)
        {
            shieldVisual.SetActive(true);
        }

        if (sfxSource != null && shieldOnClip != null)
        {
            sfxSource.PlayOneShot(shieldOnClip);  
        }
    }

    public void DeactivateShield()
    {
        isShieldActive = false;

        if (shieldVisual != null)
        {
            shieldVisual.SetActive(false);
        }

        if (sfxSource != null && shieldOffClip != null)
        {
            sfxSource.PlayOneShot(shieldOffClip);
        }
    }
    void Update()
    {
        //This function is called every frame; 60 frames/second
        Movement();
        Shooting();
        if (isShieldActive)
        {
            shieldTimer -= Time.deltaTime;
            if (shieldTimer <= 0f)
            {
                DeactivateShield();
            }
        }
    }

    void Shooting()
    {
        //if the player presses the SPACE key, create a projectile
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            if (sfxSource != null && Shot != null)
            {
                sfxSource.PlayOneShot(Shot);
            }
        }
    }

    void Movement()
    {
        //Read the input from the player
        horizontalInput = Input.GetAxis("Horizontal");
        //verticalInput = Input.GetAxis("Vertical");
        //Move the player
        transform.Translate(new Vector3(horizontalInput, 0) * Time.deltaTime * playerSpeed);
        //Player leaves the screen horizontally
        if (transform.position.x > horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }
        //Player leaves the screen vertically
        if (transform.position.y > verticalScreenLimit || transform.position.y <= -verticalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * -1, 0);
        }
    }

}