using GoMuscuChrono.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GoMuscuChrono
{
	public partial class MainPage : ContentPage
	{
        public int Counter { get; set; }

        public MainPage()
		{
			InitializeComponent();

            this.BindingContext = new MainPageViewModel();
        }
	}
}
