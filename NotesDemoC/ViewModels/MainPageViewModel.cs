using NotesDemoC.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace NotesDemoC.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageViewModel() {
            AllNotes = new ObservableCollection<NoteModel>();
            SaveNoteCommand = new Command(() =>
            {
                var note = new NoteModel
                {
                    Text = NoteText
                };
                AllNotes.Add(note);
                NoteText = string.Empty;
            });

            EraseNoteCommand = new Command(() =>
            {
                AllNotes.Clear();
            });
        }
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
        ObservableCollection<NoteModel> AllNotes { get; }

        public Command SaveNoteCommand { get; }
        public Command EraseNoteCommand { get; }
    }
}
