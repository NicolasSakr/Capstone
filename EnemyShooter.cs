using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using enemy;

public class EnemyShooter : MonoBehaviour
{

    [Header("General")]

    public Transform shootPoint; //raycast startpoint
    public Transform gunPoint;   //visualTrails dtartPoint
    public LayerMask layerMask;  

    [Header("Gun")]

    public AudioSource audio;
    public Vector3 spread = new Vector3(0.01f, 0.01f, 0.01f);
    public TrailRenderer bulletTrail;
    private EnemyReferences enemyReferences;
    public HealthScript health;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shoot()
    {
        Vector3 direction = GetDirection();
        if ( Physics.Raycast(shootPoint.position, direction, out RaycastHit hit, float.MaxValue, layerMask))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                Debug.Log("player HIT");
                health.TakeDamage(5);
            }
            Debug.DrawLine(shootPoint.position, shootPoint.position + direction * 10f, Color.red, 1f);

            TrailRenderer trail = Instantiate(bulletTrail, gunPoint.position, Quaternion.identity);
            StartCoroutine(SpawnTrail(trail, hit));
        }
    }

    private Vector3 GetDirection()
    {
        Vector3 direction = transform.forward;
        direction += new Vector3(
            Random.Range(-spread.x, spread.x),
            Random.Range(-spread.y, spread.y),
            Random.Range(-spread.z, spread.z)
        );
        direction.Normalize();
        return direction;
    }

    private IEnumerator SpawnTrail (TrailRenderer trail, RaycastHit hit)
    {
        float time = 0f;
        audio.Play();
        Vector3 startPosition = trail.transform.position;

        while ( time < 1)
        {
            trail.transform.position = Vector3.Lerp(startPosition, hit.point, time);
            time += Time.deltaTime / trail.time;

            yield return null;
        }
        trail.transform.position = hit.point;
        Destroy(trail.gameObject, trail.time);
    }
}
