/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadingAnimScript : MonoBehaviour
{
    public bool relo = false;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if(relo == true)
        {
            
            StartCoroutine(isReloading(3));
        }

    }

    public void setReloading()
    {
        relo = true;
    }

    IEnumerator isReloading(int wait)
    {
        animator.SetBool("Jump", false);
        animator.SetBool("isReloading", true);

        yield return new WaitForSeconds(wait);

        animator.SetBool("isReloading", false);
        relo = false;
    }
}
*/