using Spin.Data;
using UnityEngine;
namespace Spin.Manager
{
    public class DataManager : MonoBehaviour, IDataManager
    {
        [SerializeField] private SpinSettings _spinSettings;

        [SerializeField] private WheelData _bronzeWheelData;
        [SerializeField] private WheelData _silverWheelData;
        [SerializeField] private WheelData _goldWheelData;

        [SerializeField] private TrapData _trapData;

        public SpinSettings GetSpinSettings()
        {
            return _spinSettings;
        }

        public WheelData GetWheelData(WheelDataType type)
        {
            switch (type)
            {
                case WheelDataType.bronze:
                    return _bronzeWheelData;
                case WheelDataType.silver:
                    return _silverWheelData;
                case WheelDataType.gold:
                    return _goldWheelData;
                default:
                    return null;
            }
        }
        public TrapData GetTrapData()
        {
            return _trapData;
        }
    }
    public enum WheelDataType
    {
        bronze,
        silver,
        gold,
    }
    public interface IDataManager
    {
        SpinSettings GetSpinSettings();
        WheelData GetWheelData(WheelDataType type);
        TrapData GetTrapData();
    }
}
