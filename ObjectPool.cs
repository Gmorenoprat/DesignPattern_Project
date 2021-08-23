using System.Collections.Generic;
using System;

public class ObjectPool<T>
{
    public delegate T FactoryMethod(); 
    FactoryMethod _factoryMethod; 

    List<T> _currentStock; 
    bool _isDynamic;
    Action<T> _turnOnCallback;
    Action<T> _turnOffCallback; 

    public ObjectPool(FactoryMethod factoryMethod, Action<T> turnOnCallback, Action<T> turnOffCallback, int initialStock = 0, bool isDynamic = true)
    {
        _factoryMethod = factoryMethod;
        _turnOnCallback = turnOnCallback;
        _turnOffCallback = turnOffCallback;

        _isDynamic = isDynamic;

        _currentStock = new List<T>(); 

        for (int i = 0; i < initialStock; i++)
        {
            var obj = _factoryMethod(); 
            _turnOffCallback(obj);
            _currentStock.Add(obj);
        }

    }

    public T GetObject()
    {
        var result = default(T); 

        if (_currentStock.Count > 0) 
        {
            result = _currentStock[0]; 
            _currentStock.RemoveAt(0); 
        }
        else if (_isDynamic) 
        {
            result = _factoryMethod(); 
        }

        _turnOnCallback(result); 

        return result;
    }

    public void ReturnObject(T obj)
    {
        _turnOffCallback(obj); 
        _currentStock.Add(obj); 
    }

}


