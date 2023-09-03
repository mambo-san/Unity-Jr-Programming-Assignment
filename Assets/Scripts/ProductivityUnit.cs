using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit
{
    private ResourcePile current_pile;
    private int productivityMultiplier = 2;
    protected override void BuildingInRange()
    {
        Debug.Log("Building in range");
        if (current_pile == null)
        {
            Debug.Log("Setting current pile");
            current_pile = m_Target as ResourcePile;

            if (current_pile != null)
            {
                Debug.Log("Found resouce Pile ");
                current_pile.ProductionSpeed *= productivityMultiplier;
            }
        }
    }

    private void ResetProductivity()
    {
        if (current_pile != null)
        {
            current_pile.ProductionSpeed /= productivityMultiplier;
            current_pile = null;
        }
    }

    public override void GoTo(Building target)
    {
        ResetProductivity();
        base.GoTo(target);
    }

    public override void GoTo(Vector3 position)
    {
        ResetProductivity();
        base.GoTo(position);
    }



}
