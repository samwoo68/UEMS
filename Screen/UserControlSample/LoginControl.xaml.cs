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
    public partial class LoginControl : UserControl
    {
        public delegate void LoginStateChangedHandler(object sender, EventArgs e);
        public event LoginStateChangedHandler LoginStateChanged;

        public bool IsLoggedIn { get; set; }


        #region LoginFormBackground (DependencyProperty)

        /// <summary>
        /// A description of the property.
        /// </summary>
        public Brush LoginFormBackground
        {
            get { return (Brush)GetValue(LoginFormBackgroundProperty); }
            set { SetValue(LoginFormBackgroundProperty, value); }
        }
        public static readonly DependencyProperty LoginFormBackgroundProperty =
            DependencyProperty.Register("LoginFormBackground", typeof(Brush), typeof(LoginControl),
            new PropertyMetadata(new SolidColorBrush(Colors.White), new PropertyChangedCallback(OnLoginFormBackgroundChanged)));

        private static void OnLoginFormBackgroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((LoginControl)d).OnLoginFormBackgroundChanged(e);
        }

        protected virtual void OnLoginFormBackgroundChanged(DependencyPropertyChangedEventArgs e)
        {
            this.LayoutRoot.Background = (Brush) e.NewValue;
        }

        #endregion        


        public LoginControl()
        {
            InitializeComponent();
            
            VisualStateManager.GoToState(this, "LoggedOut", false);
            IsLoggedIn = false;

            btnLogIn.Click += new RoutedEventHandler(btnLogIn_Click);
            btnLogOut.Click += new RoutedEventHandler(btnLogOut_Click);
            
        }

        void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            IsLoggedIn = false;
            VisualStateManager.GoToState(this, "LoggedOut", true);
            LoginStateChanged(this, new EventArgs());
        }

        void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Password == "1234")
            {
                IsLoggedIn = true;
                VisualStateManager.GoToState(this, "LoggedIn", true);
                LoginStateChanged(this, new EventArgs());
            }

        }

    }
}
