using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarSample : MonoBehaviour
{
    private OutsideLibraryImpl _impl;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("JarSample Start() ");

        CreateImpl();

        _impl.Print();
        _impl.PrintParams(new string[] {"H", "E", "L", "L", "O"});
        _impl.NonStatic();
        _impl.Sum(5, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateImpl()
    {
        #if !UNITY_EDITOR && UNITY_IOS
            Debug.Log("CreateImpl() [iOS Device]");
            _impl = new OutsideLibraryIOS();
        #elif !UNITY_EDITOR && UNITY_ANDROID
            Debug.Log("CreateImpl() [Android Device]");
            _impl = new OutsideLibraryAndroid();
        #else
            Debug.Log("CreateImpl() [Other Device]");
            _impl = new OutsideLibraryImpl();
        #endif
    }
}

public class OutsideLibraryImpl
{
    public virtual void PrintParams(params string[] args) {
        Debug.Log("PrintParams() : Untiy3d editor can not do anything.");
    }

    public virtual void Print()
    {
        Debug.Log("Print() : Untiy3d editor can not do anything.");
    }

    public virtual void NonStatic() {
        Debug.Log("NonStatic() : Untiy3d editor can not do anything.");
    }

    public virtual void Sum(int x, int y) {
        Debug.Log("Sum() : Untiy3d editor can not do anything.");
    }
}

public class OutsideLibraryAndroid : OutsideLibraryImpl
{
    public override void PrintParams(params string[] args) {
        using (AndroidJavaClass ajc = new AndroidJavaClass("Hello"))
        {
            ajc.CallStatic( "main", args );
        }
    }

    public override void Print()
    {
        using (AndroidJavaClass ajc = new AndroidJavaClass("Hello"))
        {
            ajc.CallStatic("mainT");
        }
    }

    public override void NonStatic() {
        using (AndroidJavaClass ajc = new AndroidJavaClass("Hello"))
        {
            using (AndroidJavaObject ajo = ajc.CallStatic<AndroidJavaObject>("newInstance")) {
                ajo.Call("nonStaticMain");
            }
        }
    }

    public override void Sum(int x, int y) {
        using (AndroidJavaClass ajc = new AndroidJavaClass("Hello"))
        {
            int sum = ajc.CallStatic<int>("Sum", x, y);
            Debug.Log("Sum() : " + x + " + " + y + " = " + sum);
        }
    }
}


public class OutsideLibraryIOS : OutsideLibraryImpl
{

}