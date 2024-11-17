using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;

public class ObjectInstantiateScript : MonoBehaviour
{
    private int _counter = 0;
    private List<GameObject> _instantiateObjects;
    [SerializeField]
    private TMP_Text _text;
    [SerializeField]
    private Transform _spawnPoint;
    [SerializeField]
    private GameObject[] _objects;
    private void Start()
    {
        _instantiateObjects = new List<GameObject>();
    }
    public void InstantiateClickButton()
    {
        int i = Random.Range(0, _objects.Length);
        GameObject x = Instantiate(_objects[i], _spawnPoint.position, Quaternion.identity);
        _instantiateObjects.Add(x);
        _counter++;
        _text.text = _counter.ToString();
    }
    public void RemoveAllButton()
    {
        for (int i = 0; i < _instantiateObjects.Count; i++)
        {
            Destroy(_instantiateObjects[i]);
        }
        _instantiateObjects.Clear();
        _counter = 0;
        _text.text = _counter.ToString();
    }
}
