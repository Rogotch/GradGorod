using UnityEngine;

namespace Assets.Scripts
{
    public interface ISpawn
    {
        void ReloadParams(GameObject _object = null);
    }
}