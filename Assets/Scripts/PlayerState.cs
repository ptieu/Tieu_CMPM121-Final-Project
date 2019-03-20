using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerState : MonoBehaviour
{
    public AllyBase ally;
    private BattleStateMachine Battle;
    public TextMeshProUGUI HPText;
    public TextMeshProUGUI MPText;
    public TextMeshProUGUI NameText;
    public Image healthBar;
    public Animator m_Animator;
    public bool attacking;

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

      HPText.text = "HP: " + ally.currentHealth.ToString() + " / " + ally.maxHealth.ToString();
      MPText.text = "MP: " + ally.currentMP.ToString() + " / " + ally.maxMP.ToString();
      NameText.text = ally.name;

      m_Animator= gameObject.GetComponent<Animator>();
      attacking = false;
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
        if(ally.currentHealth > ally.maxHealth) { ally.currentHealth = ally.maxHealth; }
        if(ally.currentHealth < 0) { ally.currentHealth = 0; }
        HPText.text = "HP: " + ally.currentHealth.ToString() + " / " + ally.maxHealth.ToString();
        MPText.text = "MP: " + ally.currentMP.ToString() + " / " + ally.maxMP.ToString();
        if(ally.currentHealth <= 0) { ally.isDead = true; }
        if(ally.currentMP <= 0) { ally.hasMana = false; }
        healthBar.fillAmount = ally.currentHealth / ally.maxHealth;


    }

    void InsertAction()
    {
      TurnManager myAction = new TurnManager();
      myAction.ActiveCharacter = ally.name;
      myAction.AttackingGameObject = this.gameObject;
      //myAction.Target = Battle.Enemies[Random.Range(0, Battle.Enemies.Count)];
      Battle.ProcessActions(myAction);
    }
}
