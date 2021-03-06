using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace ScrollAndZoom
{
	public partial class MainPage : UserControl
	{
		public MainPage()
		{
			InitializeComponent();

            this.KeyDown += this.MainPage_KeyDown;
		}

        private void MainPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            { 
                panZoomBehavior.CancelDragToZoom(); 
            }
        }
	}
}
