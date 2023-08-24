using MVVM_test2.Infrastructure.Commands;
using MVVM_test2.Models;
using MVVM_test2.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Xml.Serialization;

namespace MVVM_test2.ViewModels
{

    
    internal class MainWindowViewModel : ViewModel
    {

      

        #region Заголовок окна

        private string _title = "Заголовок2";

        /// <summary>
        /// Заголовок окна
        /// </summary>
        public string Title
        {
            get => _title;
            //set    //полное описание сеттера свойства для обновления.
            //{
            //    if (Equals(value, _title)) return; //проверка на зацикливание
            //    _title = value; ;  //установление заголовка
            //    OnPropertyChanged();  //вызов метода, который вызовет событие обновления
            //}
            set 
            {
                Set(ref _title, value); //короткая запись сеттера, благодаря дополнительному методу сет, который реализует всю логику, описанную сверху
            }
        }
        #endregion

        private int _addNumber;
        private int _summa;
        private int _selectedIndex;

        private Model _model = new Model();



        #region Commands

        #region CloseApplicationCommand

        public ICommand CloseApplicationCommand { get; } //здесь живет сама команда (это по сути обычное свойство, чтобы его можно было вызвать из хамл)

        private void OnCloseApplicationCommandExecuted(object p) //логика команды
        {
            Application.Current.Shutdown();
        }

        private bool CanCloseApplicationCommandExecute(object p) => true; //если команда должна быть доступна всегда, то просто возвращаем true

        #endregion

        #region AddCommand

        public ICommand AddCommand { get; } //здесь живет сама команда (это по сути обычное свойство, чтобы его можно было вызвать из хамл)

        private void OnAddCommandExecuted(object p) //логика команды
        {
            Add(_addNumber);
        }

        private bool CanAddCommandExecute(object p) => true; //если команда должна быть доступна всегда, то просто возвращаем true

        #endregion

        #region RemoveCommand

        public ICommand RemoveCommand { get; } //здесь живет сама команда (это по сути обычное свойство, чтобы его можно было вызвать из хамл)

        private void OnRemoveCommandExecuted(object p) //логика команды
        {
            Remove(_selectedIndex);
        }

        private bool CanRemoveCommandExecute(object p) => true; //если команда должна быть доступна всегда, то просто возвращаем true

        #endregion

        #endregion

        public MainWindowViewModel()
        {
            #region Commands
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            AddCommand = new LambdaCommand(OnAddCommandExecuted, CanAddCommandExecute);
            RemoveCommand = new LambdaCommand(OnRemoveCommandExecuted, CanRemoveCommandExecute);
            #endregion
        }

        public int AddNumber
        {
            get => _addNumber;
            set
            {
                Set(ref _addNumber, value);
            }
        }

        public int Summa
        {
            get
            {
                _summa = _model.SumAll();
                return _summa;
            }
        }

        public int SelectedIndex
        {
            set
            {
                Set(ref _selectedIndex, value);
            }
        }

        


        public ReadOnlyObservableCollection<int> Collections
        {
            get => _model.Numbers;            
        }




        private void Add(int number)
        {
            _model.Add(number);
            OnPropertyChanged("Summa");
        }

        private void Remove(int index)
        {
            if (index != -1)
            {
                _model.Remove(index);
                OnPropertyChanged("Summa");
            }
                
        }

        

        //public int Number1
        //{
        //    get => _number1;
        //    set
        //    {
        //        Set(ref _number1, value);
        //        OnPropertyChanged("Number3");
        //    }
        //}

        //public int Number2
        //{
        //    get => _number2;
        //    set
        //    {
        //        Set(ref _number2, value);
        //        OnPropertyChanged("Number3");
        //    }
        //}

        //public int Number3
        //{
        //    get
        //    {
        //        _number3 = GetNumber3();
        //        return _number3;
        //    }            
        //}

        //public int GetNumber3()
        //{
        //    return sum.SumOf(_number1, _number2);
        //}

    }
}
