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
    class MainViewModel:BaseViewModel
    {
        private ObservableCollection<Stock> _StockList; 
        public ObservableCollection<Stock> StockList { get => _StockList; set { _StockList = value; OnPropertyChanged(); } }
        public bool Isloaded = false;
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand UnitWindowCommand { get; set; }
        public ICommand SuplierWindowCommand { get; set; }
        public ICommand CustomerWindowCommand { get; set; }
        public ICommand ObjectWindowCommand { get; set; }
        public ICommand UserWindowCommand { get; set; }
        public ICommand InputWindowCommand { get; set; }
        public ICommand OutputWindowCommand { get; set; }
        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => true,
                (p) =>
                {
                    // Check null
                    if (p == null) return;
                    Isloaded = true;
                    p.Hide();
                    LoginWindow loginWindow = new LoginWindow();
                    loginWindow.ShowDialog();

                    if (loginWindow.DataContext == null) return;
                    var loginVM = loginWindow.DataContext as LoginViewModel;
                    if (loginVM.IsLogin)
                    {
                        p.Show();
                        LoadStockData();
                    }
                    else
                    {
                            p.Close();
                    }  
                });
            UnitWindowCommand = new RelayCommand<object>((p) => true,(p)=>{UnitWindow unitWindow = new UnitWindow();unitWindow.ShowDialog();});
            SuplierWindowCommand = new RelayCommand<object>((p) => true, (p) => { SupplierWindow suplierWindow = new SupplierWindow(); suplierWindow.ShowDialog(); });
            CustomerWindowCommand = new RelayCommand<object>((p) => true, (p) => { CustomerWindow customerWindow = new CustomerWindow(); customerWindow.ShowDialog(); });
            ObjectWindowCommand = new RelayCommand<object>((p) => true, (p) => { ObjectWindow objectWindow = new ObjectWindow(); objectWindow.ShowDialog(); });
            UserWindowCommand = new RelayCommand<object>((p) => true, (p) => { UserWindow userWindow = new UserWindow(); userWindow.ShowDialog(); });
            InputWindowCommand = new RelayCommand<object>((p) => true, (p) => { InputWindow inputWindow = new InputWindow(); inputWindow.ShowDialog(); });
            OutputWindowCommand = new RelayCommand<object>((p) => true, (p) => { OutputWindow outputWindow = new OutputWindow(); outputWindow.ShowDialog(); });
        }
        int i = 1;
        public void LoadStockData()
        {
            StockList = new ObservableCollection<Stock>();
            var objectList = DataProvider.Ins.DB.Objects;
            foreach (var item in objectList)
            {
                var inputList = DataProvider.Ins.DB.InputInfoes.Where(p => p.IdObject == item.Id);
                var outputList = DataProvider.Ins.DB.OutputInfoes.Where(p => p.IdObject == item.Id);

                int sumInput = 0;
                int sumOutput = 0;

                if (inputList != null) sumInput = (int)inputList.Sum(p => p.Count);
                if (outputList != null) sumOutput = (int)outputList.Sum(p => p.Count);

                Stock stock = new Stock();
                stock.STT = i;
                stock.Count = sumInput - sumOutput;
                stock.Object = item;

                StockList.Add(stock);
                i++;
            }
        }
    }
}
