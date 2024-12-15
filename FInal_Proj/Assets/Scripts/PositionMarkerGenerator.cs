using UnityEngine;

[ExecuteInEditMode]
public class PositionMarkerGenerator : MonoBehaviour
{
    public int rows = 5;  // Number of rows
    public int columns = 8;  // Number of columns
    public float columnSpacing = -1.214f;  // Spacing between chairs in the same row
    public float rowSpacingX = 0.0f;  // Horizontal adjustment for rows
    public float rowSpacingY = 0.671f;  // Vertical adjustment for rows
    public float rowSpacingZ = -2.005f; // Depth spacing between rows
    public Vector3 startPosition = new Vector3(-0.062f, 1.102f, -.655f);  // Starting position for the first marker

    void Start()
    {
        if (!Application.isPlaying)
        {
            Debug.Log("Generating markers...");
            GenerateMarkers();
        }
    }

    public void GenerateMarkers()
    {
        // Clear existing markers to prevent duplicates
        foreach (Transform child in transform)
        {
            DestroyImmediate(child.gameObject);
        }

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Vector3 position = startPosition;
                position.x += col * columnSpacing; // Move horizontally for columns
                position.x += row * rowSpacingX; // Adjust for row horizontal shift if needed
                position.y += row * rowSpacingY; // Move upwards for rows
                position.z += row * rowSpacingZ; // Move towards the audience for rows

                GameObject marker = new GameObject($"Marker_Row{row}_Col{col}");
                marker.transform.position = position;
                marker.transform.parent = this.transform;

                // Log the position to the console with three decimal places
                Debug.Log($"Marker {row},{col} Position: ({position.x:F3}, {position.y:F3}, {position.z:F3})");
                // the acutal position set
                Debug.Log($"Marker {row},{col} Position: ({marker.transform.position.x:F3}, {marker.transform.position.y:F3}, {marker.transform.position.z:F3})");
            }
        }
    }
}
