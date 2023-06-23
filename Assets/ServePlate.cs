using UnityEngine;

public class ServePlate : MonoBehaviour
{
    public void ServeButton()
    {
        if (DraggableIngredient.plateIngredients.Count != 5)
        {
            Debug.Log("Wrong Order");
            GameManager.score--;
        }
        else
        {
            switch (GameManager.SandwichOrder)
            {
                case 0:
                    if (GameManager.Sandwiches[0].Ingredients[0] == DraggableIngredient.plateIngredients[0] &&
                        GameManager.Sandwiches[0].Ingredients[1] == DraggableIngredient.plateIngredients[1] &&
                        GameManager.Sandwiches[0].Ingredients[2] == DraggableIngredient.plateIngredients[2] &&
                        GameManager.Sandwiches[0].Ingredients[3] == DraggableIngredient.plateIngredients[3] &&
                        GameManager.Sandwiches[0].Ingredients[4] == DraggableIngredient.plateIngredients[4])
                    {
                        Debug.Log("Correct Order Cheese Abomination");
                        GameManager.score++;
                    }
                    break;
                case 1:
                    if (GameManager.Sandwiches[1].Ingredients[0] == DraggableIngredient.plateIngredients[0] &&
                        GameManager.Sandwiches[1].Ingredients[1] == DraggableIngredient.plateIngredients[1] &&
                        GameManager.Sandwiches[1].Ingredients[2] == DraggableIngredient.plateIngredients[2] &&
                        GameManager.Sandwiches[1].Ingredients[3] == DraggableIngredient.plateIngredients[3] &&
                        GameManager.Sandwiches[1].Ingredients[4] == DraggableIngredient.plateIngredients[4])
                    {
                        Debug.Log("Correct Order Count Salami");
                        GameManager.score++;
                    }
                    break;
                case 2:
                    if (GameManager.Sandwiches[2].Ingredients[0] == DraggableIngredient.plateIngredients[0] &&
                        GameManager.Sandwiches[2].Ingredients[1] == DraggableIngredient.plateIngredients[1] &&
                        GameManager.Sandwiches[2].Ingredients[2] == DraggableIngredient.plateIngredients[2] &&
                        GameManager.Sandwiches[2].Ingredients[3] == DraggableIngredient.plateIngredients[3] &&
                        GameManager.Sandwiches[2].Ingredients[4] == DraggableIngredient.plateIngredients[4])
                    {
                        Debug.Log("Correct Order Meat Monster");
                        GameManager.score++;
                    }
                    break;
                case 3:
                    if (GameManager.Sandwiches[3].Ingredients[0] == DraggableIngredient.plateIngredients[0] &&
                        GameManager.Sandwiches[3].Ingredients[1] == DraggableIngredient.plateIngredients[1] &&
                        GameManager.Sandwiches[3].Ingredients[2] == DraggableIngredient.plateIngredients[2] &&
                        GameManager.Sandwiches[3].Ingredients[3] == DraggableIngredient.plateIngredients[3] &&
                        GameManager.Sandwiches[3].Ingredients[4] == DraggableIngredient.plateIngredients[4])
                    {
                        Debug.Log("Correct Order Swamp Thing");
                        GameManager.score++;
                    }
                    break;
                case 4:
                    if (GameManager.Sandwiches[4].Ingredients[0] == DraggableIngredient.plateIngredients[0] &&
                        GameManager.Sandwiches[4].Ingredients[1] == DraggableIngredient.plateIngredients[1] &&
                        GameManager.Sandwiches[4].Ingredients[2] == DraggableIngredient.plateIngredients[2] &&
                        GameManager.Sandwiches[4].Ingredients[3] == DraggableIngredient.plateIngredients[3] &&
                        GameManager.Sandwiches[4].Ingredients[4] == DraggableIngredient.plateIngredients[4])
                    {
                        Debug.Log("Correct Order Vegetarian Ghost");
                        GameManager.score++;
                    }
                    break;
                default:
                    Debug.Log("Wrong Order");
                    GameManager.score--;
                    break;
            }
            DraggableIngredient.plateIngredients.Clear();
        }
        
        
    }
}
