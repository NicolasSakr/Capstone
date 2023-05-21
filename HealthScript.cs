using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


    public class HealthScript : MonoBehaviour
    {
        public int maxHealth = 100;
        public int currentHealth;
        RaycastHit hitInfo;
        public Camera camera;
        public float maxDistance = 7f;

        public HealthBar healthBar;

        // Start is called before the first frame update
        void Start()
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }

        // Update is called once per frame
        void Update()
        {
            if (currentHealth <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                TakeDamage(20);
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                // Get the center point of the camera viewport
                Vector3 viewportCenter = new Vector3(0.5f, 0.5f, 0f);

                // Cast a ray from the center of the camera
                Ray ray = camera.ViewportPointToRay(viewportCenter);

                // Perform the raycast
                if (Physics.Raycast(ray, out hitInfo, maxDistance))
                {
                    // Check if the hit object has the "Med_Box" tag
                    if (hitInfo.collider.gameObject.tag == "Med_Box")
                    {
                        Destroy(hitInfo.collider.gameObject);
                        currentHealth = maxHealth;
                        healthBar.SetHealth(currentHealth);
                    }
                }
            }
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;

            healthBar.SetHealth(currentHealth);
        }
    }


