//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;
using SimpleJSON;



namespace cfg.item
{ 

public sealed partial class TbUIForm
{
    private readonly Dictionary<int, item.UIForm> _dataMap;
    private readonly List<item.UIForm> _dataList;
    
    public TbUIForm(JSONNode _json)
    {
        _dataMap = new Dictionary<int, item.UIForm>();
        _dataList = new List<item.UIForm>();
        
        foreach(JSONNode _row in _json.Children)
        {
            var _v = item.UIForm.DeserializeUIForm(_row);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
        PostInit();
    }

    public Dictionary<int, item.UIForm> DataMap => _dataMap;
    public List<item.UIForm> DataList => _dataList;

    public item.UIForm GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public item.UIForm Get(int key) => _dataMap[key];
    public item.UIForm this[int key] => _dataMap[key];

    public void Resolve(Dictionary<string, object> _tables)
    {
        foreach(var v in _dataList)
        {
            v.Resolve(_tables);
        }
        PostResolve();
    }

    public void TranslateText(System.Func<string, string, string> translator)
    {
        foreach(var v in _dataList)
        {
            v.TranslateText(translator);
        }
    }
    
    
    partial void PostInit();
    partial void PostResolve();
}

}