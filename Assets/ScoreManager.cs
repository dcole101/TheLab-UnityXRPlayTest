using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0; // Initialize score variable
    public Collider ballCollider; // Assign the ball collider in the Inspector
    public Collider basketCollider; // Assign the basket collider in the Inspector
    public TextMeshProUGUI scoreText; // Assign the TextMeshPro text object in the Inspector

    // This function is called when a GameObject collides with another GameObject
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided GameObject's collider matches the assigned ball collider
        if (collision.collider == ballCollider)
        {
            // Check if the other collider involved in the collision matches the assigned basket collider
            if (collision.gameObject == basketCollider.gameObject)
            {
                // Increment the score by 1
                score++;

                // Update the score text
                UpdateScoreText();

                // Print the updated score to the console (optional)
                Debug.Log("Score: " + score);
            }
        }
    }

    // Update the score text with the current score value
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
