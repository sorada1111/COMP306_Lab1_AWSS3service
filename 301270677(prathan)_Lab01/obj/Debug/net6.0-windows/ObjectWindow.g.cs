﻿#pragma checksum "..\..\..\ObjectWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F77B6742A02F11C01857ADF0FEEE0727285C4FF0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using System.Windows.Shell;
using _301270677_prathan__Lab01;


namespace _301270677_prathan__Lab01 {
    
    
    /// <summary>
    /// ObjectWindow
    /// </summary>
    public partial class ObjectWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\ObjectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox bucketComboBox;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\ObjectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox objectPathTextBox;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\ObjectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button browse_btn;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\ObjectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid objectDataGrid;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\ObjectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button upload_btn;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\ObjectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backToMainWindow_btn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/301270677(prathan)_Lab01;component/objectwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ObjectWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\ObjectWindow.xaml"
            ((_301270677_prathan__Lab01.ObjectWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.ObjectWindow_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.bucketComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 16 "..\..\..\ObjectWindow.xaml"
            this.bucketComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.BucketComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.objectPathTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\..\ObjectWindow.xaml"
            this.objectPathTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.objectPathTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.browse_btn = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\ObjectWindow.xaml"
            this.browse_btn.Click += new System.Windows.RoutedEventHandler(this.BrowseButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.objectDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.upload_btn = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\ObjectWindow.xaml"
            this.upload_btn.Click += new System.Windows.RoutedEventHandler(this.Upload_btn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.backToMainWindow_btn = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\ObjectWindow.xaml"
            this.backToMainWindow_btn.Click += new System.Windows.RoutedEventHandler(this.backToMainWindow_btn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

