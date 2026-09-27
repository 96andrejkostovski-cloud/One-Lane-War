using UnityEngine;
using UnityEngine.SceneManagement;

namespace OneLaneWar.Presentation
{
    public sealed class Bootstrap : MonoBehaviour
    {
        void Start() { SceneManager.LoadScene("Battle"); }
    }
}
