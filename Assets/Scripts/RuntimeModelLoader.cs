using UnityEngine;
using GLTFast; // Ensure GLTFast is imported

public class RuntimeModelLoader : MonoBehaviour
{
    [SerializeField] private string[] modelUrls; // Assign URLs in Inspector
    private GltfAsset gltfAsset; // GLTFast component

    async void Start()
    {
        foreach (var url in modelUrls)
        {
            await LoadModel(url);
        }
    }

    async System.Threading.Tasks.Task LoadModel(string url)
    {
        var gltf = new GltfImport();
        bool success = await gltf.Load(url);

        if (success)
        {
            // Instantiate the model in the scene
            await gltf.InstantiateMainSceneAsync(transform);
            Debug.Log($"Loaded model from: {url}");
        }
        else
        {
            Debug.LogError($"Failed to load model from: {url}");
        }
    }
}