using Spin.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Spin.Data
{
    [CreateAssetMenu(menuName = "Spin/Data/Trap Data")]
    public class TrapData : ScriptableObject
    {
        [SerializeField] private WheelData.ItemData _bomb;
        public WheelData.ItemData Bomb { get { return _bomb; } }
    }
}
