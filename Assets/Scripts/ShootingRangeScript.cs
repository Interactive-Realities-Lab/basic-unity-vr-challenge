using TMPro;
using UnityEngine;

public class ShootingRangeScript : MonoBehaviour
{
    private int _targetCount = 0;
    [SerializeField]
    private TMP_Text _text;

    public void ResetShootingRange()
    {
        _targetCount = 0;
        _text.text = _targetCount.ToString();
    }

    public void HitTargerts()
    {
        _targetCount ++;
        _text.text = _targetCount.ToString();
    }
    
}
