using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Calculator
{
	public class Sum : INotifyPropertyChanged
	{
		private string _firstNumber;
		private string _secondNumber;
		private string _result;

		public string FirstNumber
		{
			get { return _firstNumber; }
			set
			{
				int number;
				if(int.TryParse(value, out number))
				{
					_firstNumber = value;
					OnPropertyChanged("FirstNumber");
					OnPropertyChanged("Result");
				}
			}
		}

		public string SecondNumber
		{
			get { return _secondNumber; }
			set
			{
				int number;
				if(int.TryParse(value, out number))
				{
					_secondNumber = value;
					OnPropertyChanged("SecondNumber");
					OnPropertyChanged("Result");
				}
			}
		}

		public string Result
		{
			get 
			{ 
				int res = int.Parse(FirstNumber) + int.Parse(SecondNumber);
				return res.ToString();					
			}
			set
			{
				int res = int.Parse(FirstNumber) + int.Parse(SecondNumber);
				_result = res.ToString();
				OnPropertyChanged("Result");
			}
		}

		public event PropertyChangedEventHandler? PropertyChanged;

		private void OnPropertyChanged(string propertyName)
		{
			if(PropertyChanged != null)
			{
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
