using NoteApp.Models;
using System;
using System.Data.Entity;

namespace NoteApp
{
    public class NoteAppContext : System.Data.Entity.DbContext
    {
        private static NoteAppContext _instance;

        public static NoteAppContext GetInstance()
        {
            if (_instance == null)
                _instance = new NoteAppContext();
            return _instance;
        }

        private NoteAppContext() : base("DbConnection")
        { }
        public DbSet<Note> Notes { get; set; }
    }
}
