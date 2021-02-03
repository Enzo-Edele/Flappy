using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float thrust = 5.0f;
    [SerializeField]
    bool menu = true;
    public AudioClip explosion;
    public AudioClip sadEnd;
    public AudioClip squalala;

    Rigidbody2D rb2d;
    Animator animator;
    AudioSource AS;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        AS = GetComponent<AudioSource>();

        Vector3 position = Camera.main.WorldToScreenPoint(transform.position);
        position.x = Screen.width * 0.1f;
        position.y = Screen.height * 0.5f;
        transform.position = Camera.main.ScreenToWorldPoint(position);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GameManager.Instance.alive)
        {
            rb2d.velocity = Vector2.up * thrust;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (UIManager.Instance.startMenuUI != null)
            {
                UIManager.Instance.startMenuUI.SetActive(false);
            }
            if (menu)
            {
                GameManager.Instance.StateChange(GameManager.GameState.InGame);
                menu = false;
                AS.PlayOneShot(squalala);
            }
        }

        if (Input.GetKeyDown(KeyCode.A) && GameManager.Instance.alive == false)
        {
            GameManager.Instance.StateChange(GameManager.GameState.InGame);
            UIManager.Instance.pauseMenuUI.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.A) && GameManager.Instance.alive == true)
        {
            GameManager.Instance.StateChange(GameManager.GameState.Pause);
            UIManager.Instance.pauseMenuUI.SetActive(true);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        GameManager.Instance.StateChange(GameManager.GameState.Death);
        animator.SetTrigger("Dead");
        //AS.PlayOneShot(explosion);
        //AS.PlayOneShot(sadEnd);
    }
}
