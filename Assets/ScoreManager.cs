using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0; // Initialize score variable
    public Collider ballCollider; // Assign the ball collider in the Inspector
    public Collider basketCollider; // Assign the basket collider in the Inspector
    public TextMeshProUGUI scoreText; // Assign the TextMeshPro text object in the Inspector

    // This function is called when the ball enters the basket's trigger zone
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided GameObject's collider matches the assigned ball collider
        if (other == ballCollider)
        {
            // Increment the score by 1
            score++;

            // Update the score text
            UpdateScoreText();

            // Print the updated score to the console (optional)
            Debug.Log("Score: " + score);
        }
    }

    // Update the score text with the current score value
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }
}
