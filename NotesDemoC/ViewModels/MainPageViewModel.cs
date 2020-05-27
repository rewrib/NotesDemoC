using NotesDemoC.Models;
using NotesDemoC.Views;
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
            }, 
            () => !string.IsNullOrEmpty(NoteText));
            

            EraseNoteCommand = new Command(() =>
            {
                AllNotes.Clear();
            });

            NoteSelectedCommand = new Command(async () =>
            {
                if (SelectedNote is null)
                    return;

                var detailViewModel = new DetailPageViewModel
                {
                    NoteText = SelectedNote.Text
                };

                await Application.Current.MainPage.Navigation.PushAsync(new DetailPage(detailViewModel));

                SelectedNote = null;
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

                SaveNoteCommand.ChangeCanExecute();

            }
        }

        NoteModel selectedNote;
        public NoteModel SelectedNote
        {
            get => selectedNote;
            set
            {
                selectedNote = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedNote)));
            }
        }

        public ObservableCollection<NoteModel> AllNotes { get; }

        public Command SaveNoteCommand { get; }
        public Command EraseNoteCommand { get; }
        public Command NoteSelectedCommand { get; }
    }
}
