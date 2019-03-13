using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AllyBase
{
  public string name;

  public float maxHealth;
  public float currentHealth;

  public float maxMP;
  public float currentMP;

  public bool isDead = false;
  public bool hasMana = true;

}
