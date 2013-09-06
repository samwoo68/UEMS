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

namespace UserControlSample
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            myLoginControl.LoginStateChanged += new LoginControl.LoginStateChangedHandler(myLoginControl_LoginStateChanged);

        }

        void myLoginControl_LoginStateChanged(object sender, EventArgs e)
        {
            btnGo.IsEnabled = myLoginControl.IsLoggedIn;
        }
    }
}
