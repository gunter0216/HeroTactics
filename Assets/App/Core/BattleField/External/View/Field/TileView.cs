using UnityEngine;

namespace App.Core.Field.External.View
{
    public class TileView : MonoBehaviour
    {
        public Vector2 GetPosition()
        {
            return transform.position;
        }
    }
}