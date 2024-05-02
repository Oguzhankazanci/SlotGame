using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spin.Data
{
    [CreateAssetMenu(menuName = "Spin/Data/Spin Settings")]
    public class SpinSettings : ScriptableObject
    {
        [SerializeField] private GameObject _elementPrefab;
        public GameObject ElementPrefab { get { return _elementPrefab; } }

        [SerializeField] private int _numberOfImages;
        public int NumberOfImages { get { return _numberOfImages; }  }

        [SerializeField] private float _radius;
        public float Radius { get { return _radius; }  }

        [SerializeField] private float _rotationDuration;
        public float RotationDuration { get { return _rotationDuration; } }
    }
}
