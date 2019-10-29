using Flashcards.Lib.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flashcards.Lib.ViewModels
{
    public class TestViewModel : ViewModelBase
    {
        private bool _isPanelWithOriginalWordVisible;
        private bool _isPanelWithTranslationWordVisible;
        private bool _isPanelWithSummaryVisible;
        private string _expressionTranslated;
        private string _expressionToBeTranslated;
        private Word _currentWord;
        private RelayCommand _commandContinue;
        private RelayCommand _commandNextWord;

        public void Initialzie(List<Word> listOfWords)
        {
            Words = new List<Word>(listOfWords);
            Index = 0;
            Start();
        }

        private void Start()
        {
            IsPanelWithOriginalWordVisible = true;
            IsPanelWithTranslationWordVisible = false;
            IsPanelWithSummaryVisible = false;
            if (Words.Count > Index)
            {
                CurrentWord = Words[Index];
                ExpressionToBeTranslated = CurrentWord.Expression;
                ExpressionTranslated = CurrentWord.Translation;
                Index++;
            }
            else
            {
                IsPanelWithOriginalWordVisible = false;
                IsPanelWithTranslationWordVisible = false;
                IsPanelWithSummaryVisible = true;
            }
        }

        public RelayCommand CommandContinueTest
        {
            get { return _commandContinue ?? (_commandContinue = new RelayCommand(_ContinueTest)); }
        }

        public RelayCommand CommandNextWord
        {
            get { return _commandNextWord ?? (_commandNextWord = new RelayCommand(Start)); }
        }

        private void _ContinueTest()
        {
            IsPanelWithOriginalWordVisible = false;
            IsPanelWithTranslationWordVisible = true;
        }

        public List<Word> Words { get; set; }
        public int Index { get; set; }

        public bool IsPanelWithOriginalWordVisible
        {
            get { return _isPanelWithOriginalWordVisible; }
            set
            {
                _isPanelWithOriginalWordVisible = value;
                RaisePropertyChanged();
            }
        }
        public bool IsPanelWithTranslationWordVisible
        {
            get { return _isPanelWithTranslationWordVisible; }
            set
            {
                _isPanelWithTranslationWordVisible = value;
                RaisePropertyChanged();
            }
        }
        public bool IsPanelWithSummaryVisible
        {
            get { return _isPanelWithSummaryVisible; }
            set
            {
                _isPanelWithSummaryVisible = value;
                RaisePropertyChanged();
            }
        }


        public Word CurrentWord
        {
            get { return _currentWord; }
            set
            {
                _currentWord = value;
                RaisePropertyChanged();
            }
        }
        public string ExpressionToBeTranslated
        {
            get { return _expressionToBeTranslated; }
            set
            {
                _expressionToBeTranslated = value;
                RaisePropertyChanged();
            }
        }
        public string ExpressionTranslated
        {
            get { return _expressionTranslated; }
            set
            {
                _expressionTranslated = value;
                RaisePropertyChanged();
            }
        }
    }
}
