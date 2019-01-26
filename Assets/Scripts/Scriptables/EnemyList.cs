using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyList : ScriptableObject
{
    public int TotalePesciolini;
    public int TotalePesciPalla;
    public int TotaleMeduse;
    public int TotaleSquali;
    
    public int TotalAllFishes { get { return TotaleMeduse + TotalePesciolini + TotalePesciPalla + TotaleSquali; } }
}
