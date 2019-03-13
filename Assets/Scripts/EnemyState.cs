using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyState : MonoBehaviour
{

    public EnemyBase enemy;
    private BattleStateMachine Battle;
    public Image healthBar;



    public enum TurnState
    {
      PROCESSING,
      INSERTACTION,
      WAITING,
      SELECTING,
      ACTION,
      KOED,
    }

    public TurnState currentState;

    void Start ()
    {
      currentState = TurnState.PROCESSING;
      Battle = GameObject.Find("BattleManager").GetComponent<BattleStateMachine>();
    }
    void Update ()
    {
      switch(currentState)
      {
        case (TurnState.PROCESSING) :
            BeginPhase();
        break;

        case (TurnState.INSERTACTION) :
          InsertAction();
          currentState = TurnState.WAITING;
        break;

        // case (TurnState.WAITING) :
        //
        // break;
        //
        // case (TurnState.ACTION) :
        //
        // break;

        case (TurnState.KOED) :

        break;
      }
    }

    void BeginPhase()
    {
      if(Battle.enemyTurn == true)
      {
        Debug.Log("Enemy's Turn");
        currentState = TurnState.INSERTACTION;
      }
    }

    void InsertAction()
    {
      TurnManager myAction = new TurnManager();
      myAction.ActiveCharacter = enemy.name;
      myAction.AttackingGameObject = this.gameObject;
      myAction.Target = Battle.Allies[Random.Range(0, Battle.Allies.Count)];
      Battle.ProcessActions(myAction);
    }
}
