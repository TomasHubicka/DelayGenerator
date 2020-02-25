using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DelayGenerator.ViewModels;

namespace DelayGenerator.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        #region Binding
        private string _codeTitle;
        private string _cycleAmount;
        private string _cyclesText;
        private string _cycleRate;
        private string _rateText;
        private string _time;
        private string _cycleTime;
        private string _program;
        private int _language { get; set; }
        private string _input;
        private string _inputType;
        private string _buttonPress;
        private string _codeSave;
        private string _codeCopy;
        private string _cycleChoice;
        public string CodeTitle { get => _codeTitle; set { _codeTitle = value; NotifyPropertyChanged(); } }
        public string CycleAmount { get => _cycleAmount; set { _cycleAmount = value; NotifyPropertyChanged(); } }
        public string CyclesText { get => _cyclesText; set { _cyclesText = value; NotifyPropertyChanged(); } }
        public string CycleRate { get => _cycleRate; set { _cycleRate = value; NotifyPropertyChanged(); } }
        public string RateText { get => _rateText; set { _rateText = value; NotifyPropertyChanged(); } }
        public string Time { get => _time; set { _time = value; NotifyPropertyChanged(); } }
        public string CycleTime { get => _cycleTime; set { _cycleTime = value; NotifyPropertyChanged(); } }
        public string Program { get => _program; set { _program = value; NotifyPropertyChanged(); } }
        public string Input { get => _input; set { _input = value; NotifyPropertyChanged(); } }
        public string InputType { get => _inputType; set { _inputType = value; NotifyPropertyChanged(); } }
        public string ButtonPress { get => _buttonPress; set { _buttonPress = value; NotifyPropertyChanged(); } }
        public string CodeSave { get => _codeSave; set { _codeSave = value; NotifyPropertyChanged(); } }
        public string CodeCopy { get => _codeCopy; set { _codeCopy = value; NotifyPropertyChanged(); } }
        public string CycleChoice { get => _cycleChoice; set { _cycleChoice = value; NotifyPropertyChanged(); } }
        public List<string> DropRegister { get; set; }
        public List<string> DropCycle { get; set; }
        #endregion

        public MainViewModel()
        {
            Title = "AVR delay generator";
            if (_language == 1)
            {
                _cycleRate = "Rychlost cyklů:";
                _cycleAmount = "Počet cyklů:";
                _cycleTime = "nebo čas a počet cyklů:";
                _time = "Čas(sek):";
                _input = "Uživatelský vstup:";
                _inputType = "Vyberte si co zadávat:";
                _buttonPress = "Klikni na tlačítko Start:";
                _codeSave = "Uložit zdrojový kód:";
                _codeCopy = "nebo zkopírovat:";
                _codeTitle = "Vygenerovaný ASM kód";
            }
            else
            {
                _cycleRate = "Cycle rate:";
                _cycleAmount = "Cycle amount:";
                _cycleTime = "Time and cycle rate:";
                _time = "Time(sec):";
                _input = "User input:";
                _inputType = "Select what to input:";
                _buttonPress = "Click on Start button:";
                _codeSave = "Save the source code:";
                _codeCopy = "or copy:";
                _codeTitle = "Generated ASM code:";
            }
            DropRegister = new List<string> { "R0", "R1", "R2", "R3", "R4", "R5", "R6", "R7", "R8", "R9", "R10", "R11", "R12" };
            DropCycle = new List<string> {"1,0000", "1,8432", "2,0000", "2,4576", "3,2768", "3,6864", "4,0000","4,6080","7,3728","8,0000","9,1260","11,059" };
            CommandCZ = new RelayCommand(
                () => { _language = 1; NotifyPropertyChanged(); },
                () => { return true; }
                );
            CommandENG = new RelayCommand(
                () => { _language = 0; NotifyPropertyChanged(); },
                () => { return true; }
                );
        }
        public RelayCommand CommandCZ { get; set; }
        public RelayCommand CommandENG { get; set; }
        public string Title { get; set; }

        #region Notify
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion 
    }
}
