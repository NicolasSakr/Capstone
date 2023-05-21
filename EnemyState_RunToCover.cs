using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using enemy;


namespace enemy
{
    public class EnemyState_RunToCover : IState
    {
        private EnemyReferences enemyReferences;
        private CoverArea coverArea;

        public EnemyState_RunToCover(EnemyReferences enemyReferences, CoverArea coverArea)
        {
            this.coverArea = coverArea;
            this.enemyReferences = enemyReferences;
        }
        public void OnEnter()
        {
            Cover nextCover = this.coverArea.GetRandomCover(enemyReferences.transform.position);
            enemyReferences.navMeshagent.SetDestination(nextCover.transform.position);
        }
        public void OnExit()
        {
            enemyReferences.animator.SetFloat("speed", 0f);
        }
        public void Tick()
        {
            enemyReferences.animator.SetFloat("speed", enemyReferences.navMeshagent.desiredVelocity.sqrMagnitude);
        }
        public Color GizmoColor()
        {
            return Color.blue;
        }
    }

}
