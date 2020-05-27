using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;

namespace NotesDemoC.ViewModels
{
    public class DetailPageViewModel : INotifyPropertyChanged
    {
        public DetailPageViewModel()
        {
            BackButtonCommand = new Command(async () => await Application.Current.MainPage.Navigation.PopAsync());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        string noteText;
        public string NoteText
        {
            get => noteText;
            set
            {
                noteText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NoteText)));
            }
        }

        public ICommand BackButtonCommand { get; }
    }
}