﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateMachine : MonoBehaviour
{
  public bool enemyTurn = false;
  public int PlayerActions = 0;
  public enum PerformAction
  {
    WAITING,
    ACTION,
    PERFORMING
  }

  public List<TurnManager> ActionList = new List<TurnManager>();
  public List<GameObject> Allies = new List<GameObject>();
  public List<GameObject> Enemies = new List<GameObject>();


  public PerformAction battleState;
    void Start()
    {
      battleState = PerformAction.WAITING;
      Enemies.AddRange (GameObject.FindGameObjectsWithTag("Monster"));
      Allies.AddRange (GameObject.FindGameObjectsWithTag("Ally"));

    }

    // Update is called once per frame
    void Update()
    {
      switch (battleState)
      {
        case (PerformAction.WAITING):
          // if(ActionList.Count > 0) // if there are any chosen actions for that turn
          // {
          //   battleState = PerformAction.ACTION;
          // }
          if(PlayerActions == 2)
          {
            Debug.Log("Player Phase Ends");
            PlayerActions = 0;
            Debug.Log("Enemy does action");
            Debug.Log("Enemy Phase Ends");
          }
          break;
        // case (PerformAction.ACTION):
        //     battleState = PerformAction.PERFORMING;
        //   break;
        // case (PerformAction.PERFORMING):
        //   battleState = PerformAction.WAITING;
        //   break;

      }
    }

    public void ProcessActions(TurnManager action)
    {
      ActionList.Add(action);
    }

    public void ProtoAttack()
    {
      PlayerActions += 1;
      if(PlayerActions == 1) {Debug.Log("Hero 1 uses Attack"); }
       else { Debug.Log("Hero 2 uses Attack"); }
    }

    public void ProtoMagic()
    {
      PlayerActions += 1;
      if(PlayerActions == 1) {Debug.Log("Hero 1 uses Magic"); }
       else { Debug.Log("Hero 2 uses Magic"); }
    }

    public void ProtoItem()
    {
      PlayerActions += 1;
      if(PlayerActions == 1) {Debug.Log("Hero 1 uses Item"); }
       else { Debug.Log("Hero 2 uses Item"); }

    }
}
