﻿#pragma checksum "..\..\inputMonthBox.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D95CAC04508CCC3F36CF66C7EE049995"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.3634
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace DataBaseDesignCourse {
    
    
    /// <summary>
    /// inputMonthBox
    /// </summary>
    public partial class inputMonthBox : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\inputMonthBox.xaml"
        internal System.Windows.Controls.TextBlock textBlock1;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\inputMonthBox.xaml"
        internal System.Windows.Controls.TextBox monthcount;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\inputMonthBox.xaml"
        internal System.Windows.Controls.Button button1;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\inputMonthBox.xaml"
        internal System.Windows.Controls.Button button2;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DataBaseDesignCourse;component/inputmonthbox.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\inputMonthBox.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.textBlock1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.monthcount = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.button1 = ((System.Windows.Controls.Button)(target));
            
            #line 8 "..\..\inputMonthBox.xaml"
            this.button1.Click += new System.Windows.RoutedEventHandler(this.button1_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.button2 = ((System.Windows.Controls.Button)(target));
            
            #line 9 "..\..\inputMonthBox.xaml"
            this.button2.Click += new System.Windows.RoutedEventHandler(this.button2_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
