﻿#pragma checksum "..\..\CaseWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "150487B2F7E650543EA1DB65A3852AF0"
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
using System.Windows.Forms.Integration;
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
    /// CaseWindow
    /// </summary>
    public partial class CaseWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 5 "..\..\CaseWindow.xaml"
        internal DataBaseDesignCourse.CaseWindow Window;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\CaseWindow.xaml"
        internal System.Windows.Controls.Grid LayoutRoot;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\CaseWindow.xaml"
        internal System.Windows.Controls.Button sure;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\CaseWindow.xaml"
        internal System.Windows.Controls.Button cancel;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\CaseWindow.xaml"
        internal System.Windows.Controls.ComboBox CaseType;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\CaseWindow.xaml"
        internal System.Windows.Controls.TextBox CaseAddress;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\CaseWindow.xaml"
        internal System.Windows.Controls.TextBox CaseContent;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\CaseWindow.xaml"
        internal System.Windows.Controls.RadioButton CaseBuild;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\CaseWindow.xaml"
        internal System.Windows.Controls.RadioButton CaseSurvey;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\CaseWindow.xaml"
        internal System.Windows.Controls.RadioButton CaseFinish;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\CaseWindow.xaml"
        internal System.Windows.Controls.RadioButton CaseTrial;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\CaseWindow.xaml"
        internal System.Windows.Controls.ListView CaseRelatedPersonList;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\CaseWindow.xaml"
        internal System.Windows.Controls.Button deletCase;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\CaseWindow.xaml"
        internal System.Windows.Controls.Button addCase;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\CaseWindow.xaml"
        internal System.Windows.Controls.TextBlock textBlock1;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\CaseWindow.xaml"
        internal System.Windows.Controls.TextBox CaseTime;
        
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
            System.Uri resourceLocater = new System.Uri("/DataBaseDesignCourse;component/casewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CaseWindow.xaml"
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
            this.Window = ((DataBaseDesignCourse.CaseWindow)(target));
            return;
            case 2:
            this.LayoutRoot = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.sure = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\CaseWindow.xaml"
            this.sure.Click += new System.Windows.RoutedEventHandler(this.sure_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cancel = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\CaseWindow.xaml"
            this.cancel.Click += new System.Windows.RoutedEventHandler(this.cancel_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CaseType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.CaseAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.CaseContent = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.CaseBuild = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 9:
            this.CaseSurvey = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 10:
            this.CaseFinish = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 11:
            this.CaseTrial = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 12:
            this.CaseRelatedPersonList = ((System.Windows.Controls.ListView)(target));
            return;
            case 13:
            this.deletCase = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\CaseWindow.xaml"
            this.deletCase.Click += new System.Windows.RoutedEventHandler(this.deletCase_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.addCase = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\CaseWindow.xaml"
            this.addCase.Click += new System.Windows.RoutedEventHandler(this.addCase_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.textBlock1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 16:
            this.CaseTime = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
