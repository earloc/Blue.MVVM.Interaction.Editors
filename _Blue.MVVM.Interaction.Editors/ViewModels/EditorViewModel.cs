using Blue.MVVM.Commands;
using Blue.MVVM.Interaction.Editors.ViewModels;
using Blue.MVVM.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Blue.MVVM.Interaction.Editors.ViewModels {
    public abstract class EditorViewModel<T> : NotifyPropertyChangedBase, IEditorViewModel<T>, IValidatable {

        public EditorViewModel() {
            PrimaryCommand = new Command(PrimaryCommand_Execute, PrimaryCommand_CanExecute);
            SecondaryCommand = new Command(SecondaryCommand_Execute);
        }

        public object Content {
            get {
                return Value;
            }
        }

        public Type ContentType {
            get {
                return typeof(T);
            }
        }
        private INotifyPropertyChanged _Notifiable;
        private INotifyPropertyChanged Notifiable {
            get {
                return _Notifiable;
            }
            set {
                Detach(_Notifiable);
                _Notifiable = value;
                Attach(_Notifiable);
            }
        }
        public T Value {
            get {
                return _Value;
            }
            set {
                _Value = value;
                Validatable = value as IValidatable;
                Notifiable = value as INotifyPropertyChanged;
                this.ValidatesWhen(IsValidCore(value));
                PrimaryCommand.NotifyCanExecuteChanged();
            }
        }

        protected virtual bool IsValidCore(T value) {
            return true;
        }

        private T _Value;

        private IValidatable Validatable {
            get {
                return _Validatable;
            }
            set {
                Detach(_Validatable);
                _Validatable = value;
                Attach(_Validatable);
            }
        }
        private IValidatable _Validatable;

        private void Attach(IValidatable validatable) {
            if (validatable == null)
                return;
            validatable.IsValidChanged += Validatable_IsValidChanged;
        }

        private void Detach(IValidatable validatable) {
            if (validatable == null)
                return;
            validatable.IsValidChanged -= Validatable_IsValidChanged;
        }

        private void Validatable_IsValidChanged(object sender, EventArgs e) {
            PrimaryCommand.NotifyCanExecuteChanged();
        }

        private void Attach(INotifyPropertyChanged notifiable) {
            if (notifiable == null)
                return;
            notifiable.PropertyChanged += Notifiable_PropertyChanged;
        }

        private void Detach(INotifyPropertyChanged notifiable) {
            if (notifiable == null)
                return;
            notifiable.PropertyChanged -= Notifiable_PropertyChanged;
        }

        private void Notifiable_PropertyChanged(object sender, EventArgs e) {
            this.ValidatesWhen(IsValidCore(Value), nameof(Value));
            PrimaryCommand.NotifyCanExecuteChanged();
        }


        private readonly TaskCompletionSource<T> _Result = new TaskCompletionSource<T>();

        public event EventHandler IsValidChanged;

        public async Task<T> GetResultAsync() {
            var result = await _Result.Task;
            Detach(_Validatable);
            Detach(_Notifiable);
            return result;
        }

        public string PrimaryCommandText {
            get {
                return _PrimaryCommandText;
            }
            set {
                this.Set(ref _PrimaryCommandText, value, nameof(PrimaryCommandText));
            }
        }
        private string _PrimaryCommandText = Settings.Default.PrimaryCommandText;

        public INotificationCommand PrimaryCommand { get; }
        private void PrimaryCommand_Execute() {
            _Result.SetResult(Value);
        }

        private bool PrimaryCommand_CanExecute() {
            return IsValid && (Validatable?.IsValid ?? true);
        }

        public string SecondaryCommandText {
            get {
                return _SecondaryCommandText;
            }
            set {
                this.Set(ref _SecondaryCommandText, value, nameof(SecondaryCommandText));
            }
        }
        private string _SecondaryCommandText = Settings.Default.SecondaryCommandText;

        public INotificationCommand SecondaryCommand { get; }
        private void SecondaryCommand_Execute() {
            _Result.TrySetResult(default(T));
        }

        private Dictionary<string, List<string>> _Errors = new Dictionary<string, List<string>>();

        private bool _IsValid = true;
        public bool IsValid {
            get {
                return _IsValid;
            }
            protected set {
                _IsValid = value;
                IsValidChanged?.Invoke(this, EventArgs.Empty);
                PrimaryCommand.NotifyCanExecuteChanged();
            }
        }

        public void SetError(string propertyName, string errorText = null) {
            if (!_Errors.ContainsKey(propertyName))
                _Errors[propertyName] = new List<string>();

            _Errors[propertyName].Add(errorText);

            IsValid = _Errors.Count <= 0;
        }

        public void RemoveError(string propertyName) {
            _Errors.Remove(propertyName);
            IsValid = _Errors.Count <= 0;
        }
    }
}
