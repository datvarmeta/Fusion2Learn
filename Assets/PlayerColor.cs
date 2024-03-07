using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : NetworkBehaviour
{
    [Networked, OnChangedRender(nameof(OnColorChanged))]
    public Color NetworkedColor { get; set; }

    public MeshRenderer MeshRenderer;

    public override void Spawned()
    {
        MeshRenderer.material.color = NetworkedColor;
    }

    private void Update()
    {
        if (HasStateAuthority && Input.GetKeyDown(KeyCode.E))
        {
            // Changing the material color here directly does not work since this code is only executed on the client pressing the button and not on every client.
            NetworkedColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        }
    }

    void OnColorChanged()
    {
        MeshRenderer.material.color = NetworkedColor;
    }
}
