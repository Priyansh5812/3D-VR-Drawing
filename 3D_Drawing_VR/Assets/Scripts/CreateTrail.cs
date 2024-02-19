﻿using UnityEngine;

/// <summary>
/// This script creates a trail at the location of a gameobject with a particular width and color.
/// </summary>

public class CreateTrail : MonoBehaviour
{
    public GameObject trailPrefab = null;
    public GameObject origin = null;
    private float width = 0.01f;
    private Color color = Color.red;
    private GameObject currentTrail = null;

    public void StartTrail()
    {
        if (!currentTrail)
        {
            currentTrail = Instantiate(trailPrefab, origin.transform.position, transform.rotation, transform);
            ApplySettings(currentTrail);
        }
    }

    private void ApplySettings(GameObject trailObject)
    {
        TrailRenderer trailRenderer = trailObject.GetComponent<TrailRenderer>();
        trailRenderer.widthMultiplier = width;
        trailRenderer.startColor = color;
        trailRenderer.endColor = color;
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
        foreach(GameObject i in this.transform)
        {
            Destroy(i);
        }
    }
}