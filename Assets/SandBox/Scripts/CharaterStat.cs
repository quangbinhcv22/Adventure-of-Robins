using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine.Events;

namespace SandBox.Scripts
{
    [Serializable]
    public class CharacterStat
    {
        private float current;
        public float BaseValue;

        protected bool _isDirty = true;
        protected float _value;
        protected float lastBaseValue = float.MinValue;
        protected readonly List<StatModifier> statModifiers;
        protected readonly ReadOnlyCollection<StatModifier> StatModifiers;

        public virtual float Value
        {
            get
            {
                if (_isDirty || BaseValue != lastBaseValue)
                {
                    lastBaseValue = BaseValue;
                    _value = CalculateFinalValue();
                    _isDirty = false;
                }

                return _value;
            }
        }

        public virtual float Current
        {
            get => current;

            set
            {
                current = value;
                OnValueChanged?.Invoke();
            }
        }
        public float Percent => Value is (float) default ? default : current / Value;

        public UnityAction OnValueChanged;
        public CharacterStat()
        {
            statModifiers = new List<StatModifier>();
            StatModifiers = statModifiers.AsReadOnly();
        }

        public CharacterStat(float baseValue) : this()
        {
            BaseValue = baseValue;
        }

        public void ResetCurrentByValue() => current = Value;

        public virtual void AddModifier(StatModifier mod)
        {
            _isDirty = true;
            
            statModifiers.Add(mod);
            statModifiers.Sort(CompareModifierOrder);
            
            OnValueChanged?.Invoke();
        }

        public virtual bool RemoveModifier(StatModifier mod)
        {
            if (statModifiers.Remove(mod))
            {
                _isDirty = true;
                OnValueChanged?.Invoke();
            }
            
            return false;
        }

        public virtual bool RemoveAllModifiersFromSource(object source)
        {
            bool didRemove = false;
            for (int i = statModifiers.Count - 1; i >= 0; i--)
            {
                if (statModifiers[i].Source == source)
                {
                    _isDirty = true;
                    didRemove = true;
                    statModifiers.RemoveAt(i);
                    
                    OnValueChanged?.Invoke();
                }
            }

            return didRemove;
        }

        protected virtual int CompareModifierOrder(StatModifier a, StatModifier b)
        {
            if (a.Order < b.Order)
                return -1;
            else if (a.Order > b.Order)
                return 1;
            return 0;
        }

        protected virtual float CalculateFinalValue()
        {
            float finalValue = BaseValue;
            float sumPercentAdd = 0;

            for (int i = 0; i < statModifiers.Count; i++)
            {
                StatModifier mod = statModifiers[i];

                if (mod.Type == StatModType.Flat)
                {
                    finalValue += mod.Value;
                }
                else if (mod.Type == StatModType.PercentAdd)
                {
                    sumPercentAdd += mod.Value;
                    if (i + 1 >= statModifiers.Count || statModifiers[i + 1].Type != StatModType.PercentAdd)
                    {
                        finalValue *= 1 + sumPercentAdd;
                        sumPercentAdd = 0;
                    }
                }
                else if (mod.Type == StatModType.PercentMult)
                {
                    finalValue += mod.Value;
                }
            }

            return (float) Math.Round(finalValue, 4);
        }
    }
}