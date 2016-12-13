using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Blue.MVVM.Commands;

namespace Blue.MVVM.Interaction.Editors.ViewModels {
    public class PickerViewModel<T> : NotifyPropertyChangedBase, IPickerViewModel<T> {

        public PickerViewModel(IEnumerable<T> context, IEnumerable<T> selected, string title, string prompt, string primaryText, string secondaryText, bool freezeSelected) {
            PrimaryCommand = new Command(PrimaryCommand_Execute, PrimaryCommand_CanExecute);
            SecondaryCommand = new Command(SecondaryCommand_Execute);

            Context = ( from x in context
                        let isSelected = selected.Contains(x)
                        select new SelectableViewModel<T>() {
                            Item = x,
                            IsSelected = isSelected,
                            IsSelectable = !(isSelected && freezeSelected)
                        }).ToArray();

            PrimaryCommandText = primaryText;
            SecondaryCommandText = secondaryText;
            Title = title;
            Prompt = prompt;
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
            _Result.SetResult(_Context.Where(x => x.IsSelected).Select(x => x.Item));
        }

        private bool PrimaryCommand_CanExecute() {
            return IsValid;
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
            _Result.TrySetResult(null);
        }

        public string Prompt {
            get; set;
        }

        public string Title {
            get; set;
        }

        public bool IsValid {
            get {
                return _IsValid;
            }
            set {
                this.Set(ref _IsValid, value, nameof(IsValid));
                PrimaryCommand.NotifyCanExecuteChanged();
            }
        }
        private bool _IsValid = default(bool);

        public async Task<IEnumerable<T>> GetResultAsync() {
            var result = await _Result.Task;
            return result;
        }

        private readonly TaskCompletionSource<IEnumerable<T>> _Result = new TaskCompletionSource<IEnumerable<T>>();

        

        private IEnumerable<ISelectableViewModel<T>> _Context;
        public IEnumerable<ISelectableViewModel<T>> Context {
            get {
                return _Context;
            }
            set {
                DetachFrom(_Context);
                this.Set(ref _Context, value, nameof(Context));
                AttachTo(_Context);
                IsValid = _Context.Where(x => x.IsSelected).Count() > 0;
            }
        }

        private void DetachFrom(IEnumerable<ISelectableViewModel<T>> source) {
            if (source == null)
                return;

            foreach (var selectable in source)
                selectable.IsSelectedChanged -= ItemIsSelectedChanged;
        }

        private void AttachTo(IEnumerable<ISelectableViewModel<T>> source) {
            if (source == null)
                return;

            foreach (var selectable in source)
                selectable.IsSelectedChanged += ItemIsSelectedChanged;
        }

        private void ItemIsSelectedChanged(object sender, EventArgs e) {
            IsValid = _Context.Where(x => x.IsSelected).Count() > 0;
        }
    }
}
