using Caliburn.Micro;
using NoteApp.Models;
using NoteApp.Views;
using System;
using System.Linq;

namespace NoteApp.ViewModels
{
    class NotePanelViewModel : Screen
    {
        NoteAppContext context = NoteAppContext.GetInstance();
        private Note _note;
        private string _title;
        private string _text;

        public string Title
        {
            get { return _title; }
            set { _title = value; NotifyOfPropertyChange(() => Title); }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; NotifyOfPropertyChange(() => Text); }
        }

        public NotePanelViewModel()
        { }

        public NotePanelViewModel(Note note) : base()
        {
            _note = note;
            FillPanel();
        }

        private void FillPanel()
        {
            Title = _note.Title;
            Text = _note.Text;
        }

        public void SaveNote(string title, string text)
        {
            if (_note == null)
            {
                _note = new Note()
                {
                    Title = title,
                    Text = text,
                    UpdateDate = DateTime.Now,
                    CreationDate = DateTime.Now
                };
                context.Notes.Add(_note);
            }
            else
            {
                _note = context.Notes.SingleOrDefault(n => n.Id == _note.Id);
                _note.Title = Title;
                _note.Text = Text;
                _note.UpdateDate = DateTime.Now;
            }
            context.SaveChanges();

            base.TryCloseAsync();
        }
    }
}
