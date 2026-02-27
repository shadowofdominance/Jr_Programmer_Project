using UnityEngine;

public class ProductivityUnit : Unit
{
    private ResourcePile _currentPile;
    public float productivityMultiplier;
    
    protected override void BuildingInRange()
    {
        if (_currentPile == null)
        {
            ResourcePile pile = m_Target as ResourcePile;
            
            if(pile != null)
            {
                _currentPile = pile;
                _currentPile.ProductionSpeed *= productivityMultiplier;
            }
        }
    }

    void ResetProductivity()
    {
        if (_currentPile != null)
        {
            _currentPile.ProductionSpeed /= productivityMultiplier;
            _currentPile = null;
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
