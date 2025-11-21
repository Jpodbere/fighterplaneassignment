using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public GameObject explosionPrefab;
    private GameManager gameManager;
    public AudioClip Explosion;
    // Update is called once per frame
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * 3f);
        if (transform.position.x > 9.5f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if (whatDidIHit.tag == "Player")
        {
            whatDidIHit.GetComponent<Player>().LoseALife();
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if (whatDidIHit.tag == "Weapons")
        {
            Destroy(whatDidIHit.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            if (Explosion != null)
            {
                AudioSource.PlayClipAtPoint(Explosion, transform.position);
            }
            gameManager.addScore(5);
            Destroy(this.gameObject);
        }
    }
}