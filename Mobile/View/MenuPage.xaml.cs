using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.XamarinForms.Input;
using Xamarin.Forms;

namespace Mobile.View
{
    public partial class MenuPage : BasePage
    {
        public MenuPage()
        {
            InitializeComponent();
			this.dataForm.ValidationMode = ValidationMode.OnLostFocus;
			this.dataForm.CommitMode = CommitMode.Manual;
			this.dataForm.RegisterEditor("Name", EditorType.TextEditor);
			this.dataForm.RegisterEditor("Genre", EditorType.PickerEditor);
        }
    }
}
