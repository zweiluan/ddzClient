//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using SimpleJSON;


namespace cfg
{ 
   
public sealed partial class Tables
{
    public item.TbItem TbItem {get; }
    public item.TbMyItem TbMyItem {get; }
    public item.TbUIForm TbUIForm {get; }

    public Tables(System.Func<string, JSONNode> loader)
    {
        var tables = new System.Collections.Generic.Dictionary<string, object>();
        TbItem = new item.TbItem(loader("item_tbitem")); 
        tables.Add("item.TbItem", TbItem);
        TbMyItem = new item.TbMyItem(loader("item_tbmyitem")); 
        tables.Add("item.TbMyItem", TbMyItem);
        TbUIForm = new item.TbUIForm(loader("item_tbuiform")); 
        tables.Add("item.TbUIForm", TbUIForm);
        PostInit();

        TbItem.Resolve(tables); 
        TbMyItem.Resolve(tables); 
        TbUIForm.Resolve(tables); 
        PostResolve();
    }

    public void TranslateText(System.Func<string, string, string> translator)
    {
        TbItem.TranslateText(translator); 
        TbMyItem.TranslateText(translator); 
        TbUIForm.TranslateText(translator); 
    }
    
    partial void PostInit();
    partial void PostResolve();
}

}