using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableIngredient : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    // Collider2D, SpriteRenderer
    
    [SerializeField] 
    private Ingredient ingredient;
    public Ingredient Ingredient => ingredient;
    
    [SerializeField]
    private Rigidbody2D ingredientRigidbody;
    
    [SerializeField]
    private SpriteRenderer ingredientSpriteRenderer;

    [SerializeField]
    private Collider2D ingredientCollider;

    public static List<Ingredient> plateIngredients = new List<Ingredient>();    
    
    [SerializeField] 
    private Collider2D triggerCollider;

    private bool _isDragging;
    private Vector2 _offset;
    private Camera _gameCamera;
    
    private void FollowMouse()
    {
        Vector3 mouseWorldPosition = GetMouseWorldPosition();
        transform.position = mouseWorldPosition + (Vector3)_offset;
    }
    
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = _gameCamera.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.z = 0;
        return mouseWorldPosition;
    }
    
    public void SetCamera(Camera gameCamera) { _gameCamera = gameCamera; }
    
    public void OnDrag(PointerEventData eventData) { if(_isDragging) FollowMouse(); }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left || gameObject.CompareTag("isInPlate")) return;

        ingredientRigidbody.simulated = false;
        ingredientCollider.enabled = true;
        ingredientSpriteRenderer.enabled = true;
        gameObject.tag = "notInPlate";
        Vector3 mouseWorldPosition = GetMouseWorldPosition();
        _offset = transform.position - mouseWorldPosition;
        _isDragging = true;
        FollowMouse();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left) return;
        _isDragging = false;
        ingredientRigidbody.simulated = true; 
        ingredientRigidbody.bodyType = RigidbodyType2D.Dynamic;
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (_isDragging)
            return;

        if (other.contacts[0].point.y < transform.position.y)
        {
            if (other.gameObject.CompareTag("isInPlate"))
            {
                gameObject.tag = "isInPlate";
                ingredientRigidbody.bodyType = RigidbodyType2D.Static;
                triggerCollider.enabled = false;
                plateIngredients.Add(ingredient);
                other.gameObject.tag = "Glue";
                Debug.Log(plateIngredients.Count);
            } 
            else if (other.gameObject.CompareTag("destroyer"))
            {
                Destroy(gameObject);
            }
        }
        else
        {
            ingredientRigidbody.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (_isDragging)
            return;
    }
}