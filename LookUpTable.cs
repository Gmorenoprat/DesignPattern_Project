using System.Collections.Generic;
public class LookUpTable<T1, T2>
{
    public delegate T2 FactoryMethod(T1 keyToReturn);
    Dictionary<T1, T2> _table = new Dictionary<T1, T2>();

    FactoryMethod factoryMethod;

    public LookUpTable(FactoryMethod newFactory)
    {
        factoryMethod = newFactory;
    }

    public T2 ReturnValue(T1 myKey)
    {
        if (_table.ContainsKey(myKey))
        {
            return _table[myKey];
        }
        else
        {
            var value = factoryMethod(myKey);
            _table[myKey] = value;
            return value;
        }

    }
}
