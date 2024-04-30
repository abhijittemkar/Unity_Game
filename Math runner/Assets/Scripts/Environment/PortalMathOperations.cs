using UnityEngine;
using TMPro;

public class PortalController : MonoBehaviour
{
    public TextMeshPro equationText; // Reference to the TextMeshPro component.
    public ScoringManager scoringManager; // Reference to the scoring manager.

    public int minOperand = 1; // Minimum value for the operand.
    public int maxOperand = 9; // Maximum value for the operand.
    public int minOperandMultiplication = 1; // Minimum value for the operand in multiplication.
    public int maxOperandMultiplication = 2; // Maximum value for the operand in multiplication.
    public string[] operators = { "+", "-", "*", "/" }; // Array of operators.

    private string generatedEquation; // Variable to store the generated equation.

    private void Start()
    {
        // Call a method to generate and display a random equation.
        GenerateRandomEquation();
    }

    private void GenerateRandomEquation()
    {
        // Check if the player's z position is less than 100.
        if (transform.position.z < 100f)
        {
            // If the condition is met, generate only "+" operators.
            generatedEquation = $"+ {Random.Range(minOperand, maxOperand + 1)}";
        }
        else
        {
            // If the condition is not met, select a random operator.
            string selectedOperator = operators[Random.Range(0, operators.Length)];

            // Generate a random operand within the specified range.
            int operand;

            if (selectedOperator == "*")
            {
                // Use a different operand range for multiplication.
                operand = Random.Range(minOperandMultiplication, maxOperandMultiplication + 1);
            }
            else
            {
                // Use the default operand range for other operators.
                operand = Random.Range(minOperand, maxOperand + 1);
            }

            // Set the equation text on the TextMeshPro component.
            generatedEquation = $"{selectedOperator} {operand}";
        }

        // Set the equation text on the TextMeshPro component.
        equationText.text = generatedEquation;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the portal has a Player tag.
        if (other.CompareTag("Player"))
        {
            // Parse the generated equation to get the operator and operand.
            string[] equationParts = generatedEquation.Split(' ');
            string selectedOperator = equationParts[0];
            int operand = int.Parse(equationParts[1]);

            // Log the operator and operand separately.
            Debug.Log($"Player passed through portal with operator: {selectedOperator}, operand: {operand}");

            // Call the scoring manager to update the total score.
            scoringManager.UpdateScore(selectedOperator, operand);
        }
    }
}