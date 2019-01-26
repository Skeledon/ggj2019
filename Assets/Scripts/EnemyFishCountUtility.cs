using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFishCountUtility : MonoBehaviour
{
    public EnemyList ScriptableList;

    public enum FishNames { PESCIOLINO, PESCE_PALLA, MEDUSA, SQUALO}
    public FishNames MyType;

    private void OnDestroy()
    {
        switch(MyType)
        {
            case FishNames.PESCIOLINO:
                ScriptableList.TotalePesciolini--;
                break;
            case FishNames.PESCE_PALLA:
                ScriptableList.TotalePesciPalla--;
                break;
            case FishNames.MEDUSA:
                ScriptableList.TotaleMeduse--;
                break;
            case FishNames.SQUALO:
                ScriptableList.TotaleSquali--;
                break;
        }
    }

    private void Start()
    {

        switch (MyType)
        {
            case FishNames.PESCIOLINO:
                ScriptableList.TotalePesciolini++;
                break;
            case FishNames.PESCE_PALLA:
                ScriptableList.TotalePesciPalla++;
                break;
            case FishNames.MEDUSA:
                ScriptableList.TotaleMeduse++;
                break;
            case FishNames.SQUALO:
                ScriptableList.TotaleSquali++;
                break;
        }

    }
}
