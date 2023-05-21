
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealthScript : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Animator anim;
    public EnemyHealth healthBar;
    public AudioSource audioSource;
    public AudioClip deathSound;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            TakeDamage(20);
        }

        if (currentHealth <= 0)
        {
            StartCoroutine(Die(3));
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    IEnumerator Die(float sec)
    {
        anim.SetBool("shooting", false);
        anim.SetTrigger("isDead");

        // Play the death sound
        //audioSource.PlayOneShot(deathSound);

        // Wait for the specified delay of 3 seconds
        yield return new WaitForSeconds(sec);

        // Destroy the enemy GameObject
        Destroy(gameObject);
    }
}


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


    public class EnemyHealthScript : MonoBehaviour
    {
        public int maxHealth = 100;
        public int currentHealth;
       
        public Animator anim;
        public EnemyHealth healthBar;

    public int damageCounter = 0;

        // Start is called before the first frame update
        void Start()
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }

        // Update is called once per frame
        void Update()
        {
            
            if (Input.GetKeyDown(KeyCode.C))
            {
                TakeDamage(20);
            }
            Debug.Log(currentHealth);
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;

            healthBar.SetHealth(currentHealth);

            damageCounter += damage;

            if (damageCounter >= 100)
            {
                // Trigger the "isDead" animation
                //anim.SetBool("shooting", false);
                //anim.SetTrigger("isDead");

                // Start the coroutine to destroy the enemy after 1 second
                StartCoroutine(Die());
            }
        }

        IEnumerator Die()
        {
            anim.SetBool("shooting", false);
            anim.SetTrigger("isDead");
            // Wait for the specified delay of 3 seconds
            yield return new WaitForSeconds(3f);

            // Destroy the enemy GameObject
            Destroy(gameObject);
    }
    }
*/
