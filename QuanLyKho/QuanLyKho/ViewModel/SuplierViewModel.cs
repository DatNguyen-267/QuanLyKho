using QuanLyKho.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyKho.ViewModel
{
    public class SuplierViewModel:BaseViewModel
    {
        private ObservableCollection<Suplier> _List { get; set; }
        public ObservableCollection<Suplier> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        private Suplier _SelectedItem { get; set; }
        public Suplier SelectedItem { get => _SelectedItem; set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (_SelectedItem != null)
                {
                    DisplayName = SelectedItem.DisplayName;
                    Address = SelectedItem.Address;
                    Phone = SelectedItem.Phone;
                    Email = SelectedItem.Email;
                    MoreInfo = SelectedItem.MoreInfo;
                    ContractDate = SelectedItem.ContractDate;
                }
            } }

        private string  _DisplayName { get; set; }
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }
        private string _Address { get; set; }
        public string Address { get => _Address; set { _Address = value; OnPropertyChanged(); } }
        private string _Phone { get; set; }
        public string Phone { get => _Phone; set { _Phone = value; OnPropertyChanged(); } }
        private string _Email { get; set; }
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }
        private string _MoreInfo { get; set; }
        public string MoreInfo { get => _MoreInfo; set { _MoreInfo = value; OnPropertyChanged(); } }
        private DateTime? _ContractDate { get; set; }
        public DateTime? ContractDate { get => _ContractDate; set { _ContractDate = value; OnPropertyChanged(); } }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public SuplierViewModel()
        {
            List = new ObservableCollection<Suplier>(DataProvider.Ins.DB.Supliers);
            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
             {
                 var suplier = new Suplier()
                 {
                     DisplayName = DisplayName,
                     Email = Email,
                     Phone = Phone,
                     MoreInfo = MoreInfo,
                     ContractDate = ContractDate,
                     Address = Address
                 };
                 DataProvider.Ins.DB.Supliers.Add(suplier);
                 DataProvider.Ins.DB.SaveChanges();

                 List.Add(suplier);
             }
            );
            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null) return false;

                var displayList = DataProvider.Ins.DB.Units.Where(x => x.Id == SelectedItem.Id);
                if (displayList != null || displayList.Count() != 0) return true;

                return false;
            }, (p) => {
                var suplier = DataProvider.Ins.DB.Supliers.Where(x => x.Id == SelectedItem.Id).SingleOrDefault(); ;
                suplier.DisplayName = DisplayName;
                suplier.Address = Address;
                suplier.Email = Email;
                suplier.MoreInfo = MoreInfo;
                suplier.Phone = Phone;
                suplier.ContractDate = ContractDate;
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.DisplayName = suplier.DisplayName;
                SelectedItem.Address = suplier.Address;
                SelectedItem.Email = suplier.Email;
                SelectedItem.Phone = suplier.Phone;
                SelectedItem.MoreInfo = suplier.MoreInfo;
                SelectedItem.ContractDate = suplier.ContractDate;

            });
        }
    }
}
