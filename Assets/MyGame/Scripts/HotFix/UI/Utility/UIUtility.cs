using UnityGameFramework.Runtime;

namespace MyGame
{
    public static class UIUtility
    {
        public static int OpenCommandUI(this UIComponent ui,CommandParams userData)
        {
            var uiForm=GameEntry.Luban.Tables.TbUIForm.Get((int)UIFormId.Command);
            if (ui.HasUIForm(AssetUtility.GetUIFormAssetPath(uiForm.Path)))
            {
                return ui.GetUIForm(AssetUtility.GetUIFormAssetPath(uiForm.Path)).SerialId;
            }
            else
            {
                return ui.OpenUIForm(AssetUtility.GetUIFormAssetPath(uiForm.Path), uiForm.Group, userData);
            }
        }
        public static void CloseCommandUI(this UIComponent ui)
        {
            var uiForm=GameEntry.Luban.Tables.TbUIForm.Get((int)UIFormId.Command);
            ui.CloseUIForm(ui.GetUIForm(AssetUtility.GetUIFormAssetPath(uiForm.Path)));
        }
        public static int OpenDialogUIMsg(this UIComponent ui,string msg)
        {
            DialogParams userData = new DialogParams() { Msg = msg };
            return OpenDialogUI(ui, userData);
        }
        public static int OpenDialogUIInvalid(this UIComponent ui)
        {
            DialogParams userData = new DialogParams() { Msg = "无效操作" };
            return OpenDialogUI(ui, userData);
        }
        public static int OpenDialogUI(this UIComponent ui, DialogParams userData)
        {
            var uiForm=GameEntry.Luban.Tables.TbUIForm.Get((int)UIFormId.Dialog);
            if (ui.HasUIForm(AssetUtility.GetUIFormAssetPath(uiForm.Path)))
            {
                return ui.GetUIForm(AssetUtility.GetUIFormAssetPath(uiForm.Path)).SerialId;
            }
            else
            {
                return ui.OpenUIForm(AssetUtility.GetUIFormAssetPath(uiForm.Path), uiForm.Group, userData);
            }
        }
        public static void CloseDialogUI(this UIComponent ui)
        {
            var uiForm=GameEntry.Luban.Tables.TbUIForm.Get((int)UIFormId.Dialog);
            ui.CloseUIForm(ui.GetUIForm(AssetUtility.GetUIFormAssetPath(uiForm.Path)));
        }
    }
}