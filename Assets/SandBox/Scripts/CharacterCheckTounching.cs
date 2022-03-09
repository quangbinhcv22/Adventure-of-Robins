using UnityEngine;

namespace SandBox.Scripts
{
    public static class CharacterCheckTounching
    {
        public static bool IsTouchingLayer(Transform checkPosition, LayerMask layerMask)
            => Physics2D.OverlapCircle(checkPosition.position, 0.1f, layerMask) != null;
    }
}