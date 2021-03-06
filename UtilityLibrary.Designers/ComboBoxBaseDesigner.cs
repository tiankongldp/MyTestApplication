using System;
using System.Windows.Forms.Design;

namespace UtilityLibrary.Designers
{
  public class ComboBoxBaseDesigner : ParentControlDesigner
  {
    public override System.Windows.Forms.Design.SelectionRules SelectionRules
    {
      get
      {
        SelectionRules sel = SelectionRules.LeftSizeable | 
          SelectionRules.RightSizeable | 
          SelectionRules.Moveable | 
          SelectionRules.Visible;
        
        return sel;
      }
    }
  }
}
