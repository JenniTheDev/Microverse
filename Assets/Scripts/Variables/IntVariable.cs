// Jenni
// Modification of RoboRyanTron's Unite 2017's
// game architecture with scriptable objects
using UnityEngine;

namespace Variables {
    [CreateAssetMenu(fileName = "New Game Variable (Int)", menuName = "Game Variable/New Game Variable (Int)")]
    public class IntVariable : ScriptableObject {
        public int Value;

        public void SetValue(int value) {
            Value = value;
        }

        public void SetValue(IntVariable value) {
            Value = value.Value;
        }

        public int GetValue() {
            return Value;
        }

        //public IntVariable GetValue() {
        //    return Value;
        //}

        public void ApplyChange(int amount) {
            Value += amount;
        }

        public void ApplyChange(IntVariable amount) {
            Value += amount.Value;
        }
    }
}