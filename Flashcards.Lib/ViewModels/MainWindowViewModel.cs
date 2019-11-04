using CsvHelper;
using CsvHelper.Configuration;
using Flashcards.Lib.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

namespace Flashcards.Lib.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private DirectoryInfo _selectedDirectory;
        private List<Word> _words;
        private RelayCommand<WindowParameter> _commandStartTest;
        private bool _translationFirst;

        public event Action<object> OnStartTest;

        public void Initialize()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var direcotory = $"{path}\\FlashcardsLists";
            if (!Directory.Exists(direcotory))
            {
                Directory.CreateDirectory(direcotory);
            }
            var files = Directory.GetFiles(direcotory);
            foreach (var item in files)
            {
                if (DirInfo == null) DirInfo = new List<DirectoryInfo>();
                DirInfo.Add(new DirectoryInfo(item));
            }
            RaisePropertyChanged(nameof(DirInfo));
        }

        public List<DirectoryInfo> DirInfo
        { get; set; }

        public DirectoryInfo SelectedDirectory
        {
            get { return _selectedDirectory; }
            set
            {
                _selectedDirectory = value;
                RaisePropertyChanged();
                _OnSelectedDirectoryInfoChanged();
            }
        }

        public List<Word> Words
        {
            get { return _words; }
            set
            {
                _words = value;
                RaisePropertyChanged();
            }
        }

        public bool TranslationFirst
        {
            get { return _translationFirst; }
            set
            {
                _translationFirst = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Word> WordsView { get; set; }
        public Word SelectedWord { get; set; }


        public RelayCommand<WindowParameter> CommandStartTest
        {
            get { return _commandStartTest ?? (_commandStartTest = new RelayCommand<WindowParameter>(_StartTest)); }
        }

        private void _StartTest(WindowParameter obj)
        {
            _OnStartTest(obj);
        }

        protected void _OnStartTest(WindowParameter obj)
        {
            if (OnStartTest != null)
                OnStartTest(obj);
        }

        private void _OnSelectedDirectoryInfoChanged()
        {
            //Encoding enc = Encoding.GetEncoding("Windows-1250");
            //var cnf = new Configuration(new System.Globalization.CultureInfo("pl-PL"));
            //cnf.Encoding = enc;
            //using (var sr = new StreamReader(SelectedDirectory.FullName, Encoding.GetEncoding("Windows-1250")))

            string[] text = File.ReadAllLines(SelectedDirectory.FullName);

            try
            {

                using (var sr = File.OpenText(SelectedDirectory.FullName))
                {
                    using (var csv = new CsvReader(sr))
                    {
                        csv.Configuration.CultureInfo = new System.Globalization.CultureInfo("pl-PL");
                        csv.Configuration.Encoding = Encoding.UTF8;
                        csv.Configuration.HasHeaderRecord = false;
                        Words = csv.GetRecords<Word>().ToList();
                    }
                }
                WordsView = new ObservableCollection<Word>(Words);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
