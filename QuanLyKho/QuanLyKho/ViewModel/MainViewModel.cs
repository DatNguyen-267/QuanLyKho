using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyKho.ViewModel
{
    class MainViewModel:BaseViewModel
    {
        public bool Isloaded = false;
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand UnitWindowCommand { get; set; }
        public ICommand SuplierWindowCommand { get; set; }
        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<object>((p) => true,
                (p) =>
                {
                    Isloaded = true;
                    LoginWindow loginWindow = new LoginWindow();
                    loginWindow.ShowDialog();
                });
            UnitWindowCommand = new RelayCommand<object>((p) => true,(p)=>{UnitWindow unitWindow = new UnitWindow();unitWindow.ShowDialog();});
            SuplierWindowCommand = new RelayCommand<object>((p) => true, (p) => { SupplierWindow suplierWindow = new SupplierWindow(); suplierWindow.ShowDialog(); });
        }
    }
}
