using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using enemy;


    public class EnemyScript : MonoBehaviour
    {
        public Transform target;
        public EnemyReferences enemyReferences;
        private float pathUpdateDeadline;
        private float shootingDistance;

        private void Awake()
        {
            enemyReferences = GetComponent<EnemyReferences>();
        }

        // Start is called before the first frame update
        void Start()
        {
            shootingDistance = enemyReferences.navMeshagent.stoppingDistance;
        }

        // Update is called once per frame
        void Update()
        {
            if (target != null)
            {
                bool inRange = Vector3.Distance(transform.position, target.position) <= shootingDistance;

                if (inRange)
                {
                    LookAtTarget();
                }
                else
                {
                    UpdatePath();
                }
                enemyReferences.animator.SetBool("shooting", inRange);
            }
            enemyReferences.animator.SetFloat("speed", enemyReferences.navMeshagent.desiredVelocity.sqrMagnitude);
        }

        private void LookAtTarget()
        {
            Vector3 lookPos = target.position - transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
        }
        private void UpdatePath()
        {
            if ( Time.time >= pathUpdateDeadline)
            {
                Debug.Log("Updating Path");
                pathUpdateDeadline = Time.time + enemyReferences.pathUpdateDelay;
                enemyReferences.navMeshagent.SetDestination(target.position);
            }
           
        }
    }


