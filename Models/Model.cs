using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_test2
{
    class Model
    {
        private readonly ObservableCollection<int> _numbers = new ObservableCollection<int>() { 1, 2, 3 };
        public readonly ReadOnlyObservableCollection<int> Numbers;

        
        public Model()
        {
            Numbers = new ReadOnlyObservableCollection<int>(_numbers);
        }

        public void Add(int number) 
        {
            this._numbers.Add(number);        
        }

        public void Remove(int index)
        { 
            this._numbers.RemoveAt(index);
        }

        public int SumAll()
        {
            int summa = 0;
            for (int i = 0; i < this._numbers.Count; i++)
            {
                summa += this._numbers[i];
            }
            return summa;
        }
    }
}
