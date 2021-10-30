using Caliburn.Micro;
using NoteApp.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace NoteApp.ViewModels
{
    class MainViewModel : Conductor<object>
    {
        NoteAppContext context = NoteAppContext.GetInstance();

        private Note _selectedNote;

        public Note SelectedNote
        {
            get { return _selectedNote; }
            set 
            { 
                _selectedNote = value;
                NotifyOfPropertyChange(() => SelectedNote);
            }
        }

        public void AddNote()
        {
            LoadNotePanel();
        }

        public void EditNote()
        {
            try
            {
                ActivateItemAsync(new NotePanelViewModel(SelectedNote));
            }
            catch (System.Exception)
            {
                MessageBox.Show("Select the note!", "Error");
            }
        }
        public void DeleteNote()
        {
            try
            {
                Note note = context.Notes.Find(SelectedNote.Id);
                context.Notes.Remove(note);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                MessageBox.Show("Error", "The note wasn`t deleted!");
            }
        }

        public void LoadNotePanel()
        {
            ActivateItemAsync(new NotePanelViewModel());
        }
    }
}
