using System;
using System.Collections.Generic;
using System.Text;
using Blue.MVVM.Validation;

namespace Blue.MVVM.Interaction.Editors.ViewModels {
    public class UriEditorPageViewModel : ScalarEditorViewModel<Uri> {

        protected override bool IsValidCore(Uri value) {
            return value != null;
        }

        public string UriValue {
            get {
                return _UriValue;
            }
            set {
                this.Set(ref _UriValue, value, nameof(UriValue));
                Uri uri = null;
                this.ValidatesWhen(Uri.TryCreate(value, UriKind.Absolute, out uri));
                Value = uri;
            }
        }
        private string _UriValue = default(string);


        

    }
}
