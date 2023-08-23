using MVVM_test2.Models;
using MVVM_test2.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private int _number2;
        private int _number3;

        private ICommand _commandAdd;

        private Model _model = new Model();

        public int AddNumber
        {
            get => _addNumber;
            set
            {
                Set(ref _addNumber, value);
            }
        }

        public ICommand CommandAdd
        {
            get { return _commandAdd; }
        }


        public ReadOnlyObservableCollection<int> Collections
        {
            get => _model.Numbers;            
        }




        public void Add(int number)
        {
            _model.Add(number);
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
