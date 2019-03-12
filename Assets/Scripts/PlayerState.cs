using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerState : MonoBehaviour
{
    public AllyBase ally;
    private BattleStateMachine Battle;
    public TextMeshProUGUI currentHPText;
    public TextMeshProUGUI maxHPText;



    public enum TurnState
    {
      PROCESSING,
      ADDTOLIST,
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
          break;

        case (TurnState.ADDTOLIST) :

          break;


        case (TurnState.WAITING) :

          break;

        case (TurnState.SELECTING) :

          break;
        case (TurnState.ACTION) :

          break;

        case (TurnState.KOED) :

          break;
      }
    }

    void InsertAction()
    {
      TurnManager myAction = new TurnManager();
      myAction.ActiveCharacter = ally.name;
      myAction.AttackingGameObject = this.gameObject;
      myAction.Target = Battle.Enemies[Random.Range(0, Battle.Enemies.Count)];
      Battle.ProcessActions(myAction);
    }
}
