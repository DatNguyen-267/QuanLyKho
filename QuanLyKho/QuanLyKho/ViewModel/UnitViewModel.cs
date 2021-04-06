using QuanLyKho.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyKho.ViewModel
{
	public class UnitViewModel:BaseViewModel
	{
		private ObservableCollection<Unit> _List;
		public ObservableCollection<Unit> List { get => _List; set { _List = value; OnPropertyChanged(); } }

		private Unit _SelectedItem;
		public Unit SelectedItem { get => _SelectedItem ; set { _SelectedItem = value; OnPropertyChanged(); 
			if (SelectedItem != null)
                {
					DisplayName = _SelectedItem.DisplayName;
                }
			} }
		public ICommand AddCommand { get; set; }
		private string _DisplayName;
		public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }
		public UnitViewModel()
		{
			AddCommand = new RelayCommand<Window>((p) =>
			{
				if (string.IsNullOrEmpty(DisplayName)) return false;
				var displayList = DataProvider.Ins.DB.Units.Where(p => p.DisplayName == DisplayName);
				if (displayList == null || displayList.Count() == 0) return false;
				return true;
			}, (p) => {
				DataProvider.Ins.DB.Units.Add(new Unit() { DisplayName = DisplayName });
				DataProvider.Ins.DB.SaveChanges();
			});
			List = new ObservableCollection<Unit>(DataProvider.Ins.DB.Units);
		}
	}
}
