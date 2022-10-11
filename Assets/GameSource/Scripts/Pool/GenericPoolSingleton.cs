using UnityEngine;

public class GenericPoolSingleton : GenericPool
{
    private static GenericPoolSingleton instance;


    public static GenericPoolSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GenericPoolSingleton>();
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    instance = go.AddComponent<GenericPoolSingleton>();
                    go.name = typeof(GenericPoolSingleton).Name;
                }
            }


            return instance;
        }
        set => instance = value;
    }

    public bool dontDestroyOnLoad;

    public void Awake()
    {
        if (dontDestroyOnLoad)
        {
            DontDestroyOnLoad(Instance);
        }
    }
}