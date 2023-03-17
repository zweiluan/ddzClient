using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShapeImage : Image
{
    public Vector2 offset1;
    public Vector2 offset2;
    public Vector2 offset3;
    public Vector2 offset4;
    protected override void OnPopulateMesh(VertexHelper toFill)
    {
        base.OnPopulateMesh(toFill);
        UIVertex vertex = new UIVertex();
        toFill.PopulateUIVertex(ref vertex, 1);
        vertex.position += Vector3.right * offset1.x+Vector3.up*offset1.y;
        toFill.SetUIVertex(vertex, 1);

        vertex = new UIVertex();
        toFill.PopulateUIVertex(ref vertex, 2);
        vertex.position +=Vector3.right * offset2.x+Vector3.up*offset2.y;
        toFill.SetUIVertex(vertex, 2);
 
        vertex = new UIVertex();
        toFill.PopulateUIVertex(ref vertex, 3);
        vertex.position += Vector3.right * offset3.x+Vector3.up*offset3.y;
        toFill.SetUIVertex(vertex, 3);
        
        vertex = new UIVertex();
        toFill.PopulateUIVertex(ref vertex, 0);
        vertex.position += Vector3.right * offset4.x+Vector3.up*offset4.y;
        toFill.SetUIVertex(vertex, 0);

    }
}
