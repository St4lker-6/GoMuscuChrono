using GoMuscuChrono.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoMuscuChrono.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TimeListView : ContentView
	{
		public TimeListView()
		{
			InitializeComponent ();
        }
	}
}