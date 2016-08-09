using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopWinApp.Model;
using DemoViewModelBase;

namespace WebShopWinApp.ViewModel
{
    public class MainPageViewModel: ViewModelBase
    {
        public Repository WebRepository { get; set; }   
        public MainPageViewModel()
        {
            WebRepository = Repository.InstanceRepository;
        }

    }
}