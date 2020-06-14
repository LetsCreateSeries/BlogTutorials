using System;
using System.Windows.Input;
using BlogTutorials.PageModels.Base;
using Xamarin.Forms;

namespace BlogTutorials.ViewModels
{
    public class SampleCardViewModel : ExtendedBindableObject
    {
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _description;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        private ICommand _command;
        public ICommand Command
        {
            get => _command;
            set => SetProperty(ref _command, value);
        }

        public SampleCardViewModel(string title, string description, Action onItemTapAction)
        {
            Title = title;
            Description = description;
            Command = new Command(onItemTapAction);
        }
    }
}
