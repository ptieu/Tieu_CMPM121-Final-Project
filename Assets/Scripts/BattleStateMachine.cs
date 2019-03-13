using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BattleStateMachine : MonoBehaviour
{
  public bool enemyTurn = false;
  public int PlayerActions = 0;
  public int TurnCount = 0;
  public EnemyState enemy1State;
  public PlayerState hero1State;
  public PlayerState hero2State;

  public enum PerformAction
  {
    WAITING,
    ACTION,
    PERFORMING
  }

  public List<TurnManager> ActionList = new List<TurnManager>();
  public List<GameObject> Allies = new List<GameObject>();
  //public List<GameObject> Enemies = new List<GameObject>();


  public PerformAction battleState;
    void Start()
    {
      battleState = PerformAction.WAITING;
      //Enemies.AddRange (GameObject.FindGameObjectsWithTag("Monster"));
      Allies.AddRange (GameObject.FindGameObjectsWithTag("Ally"));

    }

    // Update is called once per frame
    void Update()
    {
      if(enemy1State.enemy.currentHealth <= 0){ SceneManager.LoadScene("WinScreen"); } // Player wins if boss's health reaches 0
      if(hero1State.ally.isDead == true && hero2State.ally.isDead == true) { SceneManager.LoadScene("GameOver"); } // Player loses when both heroes are dead

      switch (battleState)
      {
        case (PerformAction.WAITING):
          // if(ActionList.Count > 0) // if there are any chosen actions for that turn
          // {
          //   battleState = PerformAction.ACTION;
          // }
          if(PlayerActions == 2)
          {
            PlayerActions = 0;
            TurnCount += 1;
            enemyAttack();

          }

          break;
        // case (PerformAction.ACTION):
        //     battleState = PerformAction.PERFORMING;
        //   break;
        // case (PerformAction.PERFORMING):
        //   battleState = PerformAction.WAITING;
        //   break;

      }
        enemy1State.healthBar.fillAmount = enemy1State.enemy.currentHealth/enemy1State.enemy.maxHealth;
    }

    public void ProcessActions(TurnManager action)
    {
      ActionList.Add(action);
    }

    public void ProtoAttack()
    {
      PlayerActions += 1;
      if(PlayerActions == 1 && hero1State.ally.isDead == false) { enemy1State.enemy.currentHealth -= Random.Range(80, 100); }
       else if(PlayerActions == 2 && hero2State.ally.isDead == false) {enemy1State.enemy.currentHealth -= Random.Range(80, 100); }
        if (PlayerActions == 0 && hero1State.ally.isDead == true) { PlayerActions += 1; }
        if (PlayerActions == 1 && hero2State.ally.isDead == true) { PlayerActions += 1; }

    }

    public void ProtoMagic()
    {
      PlayerActions += 1;
      if(PlayerActions == 1 && hero1State.ally.isDead == false && hero1State.ally.hasMana == true) {enemy1State.enemy.currentHealth -= Random.Range(150, 200); hero1State.ally.currentMP -= 50;  }
       else if (PlayerActions == 2 && hero2State.ally.isDead == false && hero2State.ally.hasMana == true) { enemy1State.enemy.currentHealth -= Random.Range(150, 200); hero2State.ally.currentMP -= 50; }
        if (PlayerActions == 0 && hero1State.ally.isDead == true) { PlayerActions += 1; }
        if (PlayerActions == 1 && hero2State.ally.isDead == true) { PlayerActions += 1; }

    }

    public void ProtoItem()
    {
      PlayerActions += 1;
        if (PlayerActions == 1 && hero1State.ally.isDead == false) { hero1State.ally.currentHealth += 150; }
            else if (PlayerActions == 2 && hero2State.ally.isDead == false) { hero2State.ally.currentHealth += 100; }

        if (PlayerActions == 0 && hero1State.ally.isDead == true) { PlayerActions += 1; }
        if (PlayerActions == 1 && hero2State.ally.isDead == true) { PlayerActions += 1; }

    }

    public void enemyAttack()
        {
        int x = Random.Range(0, 2);
        if(x == 0 && hero1State.ally.isDead == false) { hero1State.ally.currentHealth -= Random.Range(60, 90); }
            else if (hero2State.ally.isDead == false) { hero2State.ally.currentHealth -= Random.Range(90, 125); }
        if (x == 1 && hero2State.ally.isDead == false) { hero2State.ally.currentHealth -= Random.Range(90, 125); }
        else if (hero1State.ally.isDead == false) { hero1State.ally.currentHealth -= Random.Range(60, 90); }

    }
}
