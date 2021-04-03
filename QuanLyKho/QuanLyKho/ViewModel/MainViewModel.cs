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
        public ICommand CustomerWindowCommand { get; set; }
        public ICommand ObjectWindowCommand { get; set; }
        public ICommand UserWindowCommand { get; set; }
        public ICommand InputWindowCommand { get; set; }
        public ICommand OutputWindowCommand { get; set; }
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
            CustomerWindowCommand = new RelayCommand<object>((p) => true, (p) => { CustomerWindow customerWindow = new CustomerWindow(); customerWindow.ShowDialog(); });
            ObjectWindowCommand = new RelayCommand<object>((p) => true, (p) => { ObjectWindow objectWindow = new ObjectWindow(); objectWindow.ShowDialog(); });
            UserWindowCommand = new RelayCommand<object>((p) => true, (p) => { UserWindow userWindow = new UserWindow(); userWindow.ShowDialog(); });
            InputWindowCommand = new RelayCommand<object>((p) => true, (p) => { InputWindow inputWindow = new InputWindow(); inputWindow.ShowDialog(); });
            OutputWindowCommand = new RelayCommand<object>((p) => true, (p) => { OutputWindow outputWindow = new OutputWindow(); outputWindow.ShowDialog(); });
        }
    }
}
