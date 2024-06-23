using BlazorToDoTasks.Client.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorToDoTasks.Client
{
    public class ServerValidator : ComponentBase
    {
       
        private ValidationMessageStore _messageStore;
        [CascadingParameter]
        private EditContext CurrentEditContext { get; set; }
        protected override void OnInitialized()
        {
            if (CurrentEditContext == null)
                throw new Exception();

            _messageStore = new ValidationMessageStore(CurrentEditContext);
            CurrentEditContext.OnValidationRequested += (s, e) => _messageStore?.Clear();
            CurrentEditContext.OnFieldChanged += (s, e) => _messageStore?.Clear(e.FieldIdentifier);
        }
        public void ClearErrors()
        {
            _messageStore.Clear();
            CurrentEditContext?.NotifyValidationStateChanged();
        }
        public void DisplayErrors(IEnumerable<ErrorResponseViewModel> errors)
        {
            foreach (var item in errors)
            {
                _messageStore.Add(new FieldIdentifier(CurrentEditContext.Model, item.PropertyName), item.ErrorMessage);
            }
            CurrentEditContext?.NotifyValidationStateChanged();

        }
    }

}
