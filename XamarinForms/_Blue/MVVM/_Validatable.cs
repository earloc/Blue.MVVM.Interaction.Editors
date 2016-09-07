using Blue.Boot;
using Blue.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

#if Blue_Boot
using Blue.Boot;
#endif

namespace Blue.MVVM {
    public partial interface IValidatable {
        event EventHandler IsValidChanged;
        bool IsValid { get; }

        void SetError(string propertyName, string errorText = null);
        void RemoveError(string propertyName);
    }
}

namespace Blue.MVVM.Interaction.Editors {

    public static class IValidatableExtensions {
        public static void ValidatesWhen(this IValidatable source, bool condition, [CallerMemberName]string propertyName = "", string errorText = "") {
            if (condition) {
                source.RemoveError(propertyName);
                return;
            }
            source.SetError(propertyName, errorText);
        }
    }

    public partial class NotifyPropertyChanged : IValidatable {

        private Dictionary<string, List<string>> _Errors = new Dictionary<string, List<string>>();


        private bool _IsValid = true;
        public bool IsValid {
            get {
                return _IsValid;
            }
            protected set {
                if (Set(ref _IsValid, value))
                    IsValidChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler IsValidChanged;

        public void RemoveError(string propertyName) {
            _Errors.Remove(propertyName);
            IsValid = _Errors.Count <= 0;
        }

        public void SetError(string propertyName, string errorText = null) {
            if (!_Errors.ContainsKey(propertyName))
                _Errors[propertyName] = new List<string>();

            _Errors[propertyName].Add(errorText);

            IsValid = _Errors.Count <= 0;
        }
    }
}
