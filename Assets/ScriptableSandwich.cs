using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "sandwich_", menuName = "Database")]
    public class ScriptableSandwich: ScriptableObject
    {
        [SerializeField] private string grubName;
        public string SandwichName => grubName;
        
        
        [SerializeField] 
        private Ingredient[] ingredients = new Ingredient[0];
        public IReadOnlyList<Ingredient> Ingredients => ingredients;


        [SerializeField] private Sprite icon;
        public Sprite Icon => icon;

    }
}