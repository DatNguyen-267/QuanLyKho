using QuanLyKho.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Object = QuanLyKho.Model.Object;

namespace QuanLyKho.ViewModel
{
    class ObjectViewModel : BaseViewModel
    {
        private ObservableCollection<Object> _List { get; set; }
        public ObservableCollection<Object> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        private ObservableCollection<Unit> _Unit { get; set; }
        public ObservableCollection<Unit> Unit { get => _Unit; set { _Unit = value; OnPropertyChanged(); } }
        private ObservableCollection<Suplier> _Suplier { get; set; }
        public ObservableCollection<Suplier> Suplier { get => _Suplier; set { _Suplier = value; OnPropertyChanged(); } }
        private Object _SelectedItem { get; set; }
        public Object SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (_SelectedItem != null)
                {
                    DisplayName = SelectedItem.DisplayName;
                    BarCode = SelectedItem.BarCode;
                    QRCode = SelectedItem.QRCode;
                    SelectedUnit = SelectedItem.Unit;
                    SelectedSuplier = SelectedItem.Suplier;
                }
            }
        }
        private Unit _SelectedUnit { get; set; }
        public Unit SelectedUnit
        {
            get => _SelectedUnit; set
            {
                _SelectedUnit = value;
                OnPropertyChanged();
                if (_SelectedItem != null)
                {
                    
                }
            }
        }
        private Suplier _SelectedSuplier { get; set; }
        public Suplier SelectedSuplier
        {
            get => _SelectedSuplier; set
            {
                _SelectedSuplier = value;
                OnPropertyChanged();
                if (_SelectedItem != null)
                {

                }
            }
        }
        private string _DisplayName { get; set; }
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }
        private string _QRCode { get; set; }
        public string QRCode { get => _QRCode; set { _QRCode = value; OnPropertyChanged(); } }
        private string _BarCode { get; set; }
        public string BarCode { get => _BarCode; set { _BarCode = value; OnPropertyChanged(); } }
       
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ObjectViewModel()
        {
            List = new ObservableCollection<Object>(DataProvider.Ins.DB.Objects);
            Unit = new ObservableCollection<Unit>(DataProvider.Ins.DB.Units);
            Suplier = new ObservableCollection<Suplier>(DataProvider.Ins.DB.Supliers);
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedSuplier == null || SelectedUnit == null) return false;
                return true;
            }, (p) =>
            {
                var Object = new Object()
                {
                    Id = Guid.NewGuid().ToString(),
                    DisplayName = DisplayName,
                    BarCode = BarCode,
                    QRCode = QRCode,
                    IdUnit = SelectedUnit.Id,
                    IdSuplier = SelectedSuplier.Id,
                };
                DataProvider.Ins.DB.Objects.Add(Object);
                DataProvider.Ins.DB.SaveChanges();
                List.Add(Object);
            }
            );
            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null) return false;

                var displayList = DataProvider.Ins.DB.Objects.Where(x => x.Id == SelectedItem.Id);
                if (displayList != null || displayList.Count() != 0) return true;

                return false;
            }, (p) =>
            {
                var Object = DataProvider.Ins.DB.Objects.Where(x => x.Id == SelectedItem.Id).SingleOrDefault(); ;
                Object.DisplayName = DisplayName;
                Object.BarCode = BarCode;
                Object.QRCode = QRCode;
                Object.IdUnit = SelectedUnit.Id;
                Object.IdSuplier = SelectedSuplier.Id;
                DataProvider.Ins.DB.SaveChanges();

               
            });
        }
    }
}