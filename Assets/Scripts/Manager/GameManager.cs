using System.Collections.Generic;
using UnityEngine;

namespace Spin.Manager
{
    public class GameManager : MonoBehaviour, IGameManager
    {
        [SerializeField] private int _spinCount;
        [SerializeField] private int _silverWheelIndex;
        [SerializeField] private int _goldWheelIndex;

        List<int> _bombIndexes;

        public void CompleteSpin()
        {
            AddSpinCount();

        }
        void AddSpinCount()
        {
            _spinCount++;
        }
        public void ResetSpinCount()
        {
            _spinCount = 0;
        }
        public WheelDataType DecideReward()
        {
            if (_spinCount == 0)
            {
                return WheelDataType.bronze;
            }
            else if (_spinCount % _goldWheelIndex == 0)
            {
                return WheelDataType.gold;
            }
            else if (_spinCount % _silverWheelIndex == 0)
            {
                return WheelDataType.silver;
            }
            else
            {
                return WheelDataType.bronze;
            }
        }
        public void SetBombIndexes(List<int> array)
        {
            _bombIndexes = array;
        }
        public List<int> GetBombIndexes() => _bombIndexes;

    }

    public class GameManager2 : AbstractScriptableManager<GameManager2>, IGameManager
    {
        [SerializeField] private int _spinCount;
        [SerializeField] private int _silverWheelIndex;
        [SerializeField] private int _goldWheelIndex;
        //singleton example

        List<int> _bombIndexes;
        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Destroy()
        {
            base.Destroy();
        }
        public void CompleteSpin()
        {
            AddSpinCount();
        }
        void AddSpinCount()
        {
            _spinCount++;
        }
        public void ResetSpinCount()
        {
            _spinCount = 0;
        }
        public WheelDataType DecideReward()
        {
            if (_spinCount == 0)
            {
                return WheelDataType.bronze;
            }
            else if (_spinCount % _goldWheelIndex == 0)
            {
                return WheelDataType.gold;
            }
            else if (_spinCount % _silverWheelIndex == 0)
            {
                return WheelDataType.silver;
            }
            else
            {
                return WheelDataType.bronze;
            }
        }
        public void SetBombIndexes(List<int> array)
        {
            _bombIndexes = array;
        }
        public List<int> GetBombIndexes() => _bombIndexes;
    }

    public interface IGameManager
    {
        void CompleteSpin();
        void ResetSpinCount();
        WheelDataType DecideReward();

        void SetBombIndexes(List<int> array);
        List<int> GetBombIndexes();
    }
}