using UnityEngine;

public class CreateTrail : MonoBehaviour
{
    public GameObject trailPrefab = null;
    public GameObject origin = null;
    private float width = 0.01f;
    private Color color = Color.red;
    private GameObject currentTrail = null;
    [SerializeField] private ColorPanel panel;

    public void StartTrail()
    {
        if (!currentTrail)
        {
            currentTrail = Instantiate(trailPrefab, origin.transform.position, Quaternion.identity, transform);
            ApplySettings(currentTrail);
        }
    }

    private void ApplySettings(GameObject trailObject)
    {
        TrailRenderer trailRenderer = trailObject.GetComponent<TrailRenderer>();
        trailRenderer.widthMultiplier = width;
        trailRenderer.startColor = panel.GetColor();
        trailRenderer.endColor = panel.GetColor();
    }

    public void EndTrail()
    {
        if (currentTrail)
        {
            currentTrail.transform.parent = null;
            currentTrail = null;
        }
    }

    public void SetWidth(float value)
    {
        width = value;
    }

    public void SetColor(Color value)
    {
        color = value;
    }

    public void ClearAll()
    {
        GameObject[] trails = GameObject.FindGameObjectsWithTag("Trail");
        foreach (var i in trails)
        {
            Destroy(i);
        }
    }
}
