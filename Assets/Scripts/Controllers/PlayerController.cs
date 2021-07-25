using System;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        //private InputSystem playerInput;
        private Rigidbody2D rb;
        public Animator animator;
        SpriteRenderer spriteRenderer;
        private MenuController menuController;
        public PlayerController player;
        public Interactable interactable;
        [SerializeField] public float speed = 5f;
        private Vector2 moving;
        public NPCCollision collison;
        public GameOverCollision gmCollision;
        private SceneController sceneController;
        public GameObject text;

        void Awake()
        {
            //playerInput = new InputSystem();
            rb = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            player = GetComponent<PlayerController>();
            menuController = GameObject.Find("MenuController").GetComponent<MenuController>();
            sceneController = GameObject.Find("SceneController").GetComponent<SceneController>();
            text.SetActive(false);
        }

        void FixedUpdate()
        {
            if (GameController.Instance.state == eState.GAME)
            {
                //Vector2 moveInput = playerInput.Player.Move.ReadValue<Vector2>();
                //rb.velocity = moveInput * speed;

                rb.velocity = speed * moving;

                animator.SetFloat("Speed", rb.velocity.magnitude);

                if (rb.velocity.x > 0) spriteRenderer.flipX = false;
                if (rb.velocity.x < 0) spriteRenderer.flipX = true;
            }

        }

        private void Update()
        {
            if (GameController.Instance.state == eState.GAME)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    moving = new Vector2(1, 0);
                }

                if (Input.GetKeyDown(KeyCode.A))
                {
                    moving = new Vector2(-1, 0);
                }

                if(Input.GetKeyUp(KeyCode.D))
                {
                    moving = new Vector2(0, 0);
                }

                if (Input.GetKeyUp(KeyCode.A))
                {
                    moving = new Vector2(0, 0);
                }

                if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
                {
                    moving = new Vector2(0, 0);
                    menuController.Pause();
                }
            }
            else
            {
                moving = new Vector2(0, 0);
            }

            if(collison.interaction == true && Input.GetKeyDown(KeyCode.G))
            {
                Debug.Log("Open interaction");
                interactable.interactionVal = 1;
                menuController.Interaction();
                interactable.npcInteract();
            }
        }
    }
}
