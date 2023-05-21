using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using enemy;


public class NEWEnemyScript : MonoBehaviour
{
    public StateMachine stateMachine;
    public EnemyReferences enemyReferences;
        

        // Start is called before the first frame update
    void Start()
    {
        enemyReferences = GetComponent<EnemyReferences>();

        stateMachine = new StateMachine();

        CoverArea coverArea = FindObjectOfType<CoverArea>();

        var runToCover = new EnemyState_RunToCover(enemyReferences, coverArea);

        stateMachine.SetState(runToCover);

        void At(IState from, IState to, Func<bool> condition) => stateMachine.AddTransition(from, to, condition);
        void Any(IState to, Func<bool> condition) => stateMachine.AddAnyTransition(to,condition);
    }

        // Update is called once per frame
       void Update()
        {
            stateMachine.Tick();
        }

    private void onDrawGizmos()
    {
        if (stateMachine != null)
        {
            Gizmos.color = stateMachine.GetGizmoColor();
            Gizmos.DrawSphere(transform.position + Vector3.up * 3, 0.4f);
        }
    }

}


