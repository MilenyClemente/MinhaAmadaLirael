using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    public float speed;
    // public float groundDist;

    // public LayerMask terrainLayer;
    public Rigidbody rb;
    public SpriteRenderer rbSprite;
    public GameObject targetLanterna;
    Scene scene;
    void Start()
    {
        
        rb = gameObject.GetComponent<Rigidbody>();
        animator = rbSprite.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.buildIndex == 2)
        {
            //código utiliazado para fazer com que a personagem "suba" em elevações do terreno, sem a necessidade de um cálculo extenso feito por nós!
            // RaycastHit hit;
            // Vector3 castPos = transform.position;
            // castPos.y += 1;

            // if (Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity, terrainLayer))
            // {
                // if (hit.collider != null)
                // {
                    // Vector3 movePos = transform.position;
                    // movePos.y = hit.point.y + groundDist;
                    // transform.position = movePos;
                // }

                float x = Input.GetAxis("Horizontal");
                float y = Input.GetAxis("Vertical");

                Debug.Log(x + " - " + y);
                Vector3 moveDir = new Vector3(x, 0, y);
                rb.velocity = moveDir * speed;

                if (x != 0 && x < 0)
                {
                    rbSprite.flipX = true;
                    targetLanterna.transform.localPosition = new Vector3(-targetLanterna.transform.position.x, targetLanterna.transform.position.y, targetLanterna.transform.position.z);
                }
                else
                {
                    rbSprite.flipX = false;
                }
                if (x != 0)
                    animator.SetBool("isMoving", true);
                else
                    animator.SetBool("isMoving", false);
            // }
        }
    }
}