using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public class IngredientPoolManager : MonoBehaviour
    {

        [SerializeField] private Camera gameCamera;

        [SerializeField] private DraggableIngredient[] ingredientPrefabs;

        [SerializeField]
        private GameObject ingredientPool;

        private Dictionary<Ingredient, HashSet<DraggableIngredient>> _pool = new(32);
        private Dictionary<Ingredient, DraggableIngredient> _mappedPrefabs = new(32);

        private void Start()
        {
            foreach (DraggableIngredient prefab in ingredientPrefabs)
                _mappedPrefabs.Add(prefab.Ingredient, prefab);

            _mappedPrefabs.TrimExcess();

            foreach (Ingredient ingredient in Enum.GetValues(typeof(Ingredient)).Cast<Ingredient>())
                if (_mappedPrefabs.ContainsKey(ingredient) == false)
                    Debug.LogError($"Missing ingredient prefab: {ingredient}");

            foreach (Ingredient key in _mappedPrefabs.Keys)
            {
                _pool.Add(key, new HashSet<DraggableIngredient>());
                for (int i = 0; i < 4; i++)
                    Create(key);
            }

            foreach (DraggableIngredient prefab in ingredientPrefabs)
            {
                for (int i = 0; i < 4; i++)
                {
                    DraggableIngredient draggable = Rent(prefab.Ingredient);
                    draggable.gameObject.SetActive(true);
                }
            }
        }

        public void ResetPool()
        {
            foreach (Transform child in ingredientPool.transform)
            {
                Destroy(child.gameObject);
            }
            _pool.Clear();
            _mappedPrefabs.Clear();
            Start();
        }
        
        private DraggableIngredient Create(Ingredient ingredient)
        {
            DraggableIngredient draggable = Instantiate(_mappedPrefabs[ingredient], transform);
            draggable.SetCamera(gameCamera);
            ReturnToPool(draggable);
            return draggable;
        }

        private void ReturnToPool(DraggableIngredient draggable)
        {
            draggable.gameObject.SetActive(false);
            _pool[draggable.Ingredient].Add(draggable);
        }

        public DraggableIngredient Rent(Ingredient ingredient)
        {
            HashSet<DraggableIngredient> draggableSet = _pool[ingredient];
            if (draggableSet.Count == 0)
                Create(ingredient);

            DraggableIngredient first = draggableSet.First();
            draggableSet.Remove(first);

            Vector3 position = first.transform.position;

            return first;
        }
    }
}