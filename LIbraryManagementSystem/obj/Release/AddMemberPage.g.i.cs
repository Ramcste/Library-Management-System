﻿#pragma checksum "..\..\AddMemberPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EA61558A97CDC97B50C76FECF006C660"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
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


namespace LIbraryManagementSystem {
    
    
    /// <summary>
    /// AddMemberPage
    /// </summary>
    public partial class AddMemberPage : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 40 "..\..\AddMemberPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MemberidnoTextBox;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\AddMemberPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MembernameTextBox;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\AddMemberPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MemberaddressTextBox;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\AddMemberPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MemberphonenumberTextBox;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\AddMemberPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox DeptnameComboBox;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\AddMemberPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RollnoTextBox;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\AddMemberPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker Dateexpiry;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\AddMemberPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SessionTextBox;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\AddMemberPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SavememberButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/LIbraryManagementSystem;component/addmemberpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddMemberPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.MemberidnoTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.MembernameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.MemberaddressTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.MemberphonenumberTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.DeptnameComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.RollnoTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Dateexpiry = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 8:
            this.SessionTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.SavememberButton = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\AddMemberPage.xaml"
            this.SavememberButton.Click += new System.Windows.RoutedEventHandler(this.SavememberButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

