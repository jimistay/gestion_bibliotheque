﻿#pragma checksum "..\..\..\..\..\View\livres\Ajouter.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6837504AAA94B8E54F32C786E01CE820A4D4B3E2"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
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
using gestion_bibliotheque.View.livres;


namespace gestion_bibliotheque.View.livres {
    
    
    /// <summary>
    /// Ajouter
    /// </summary>
    public partial class Ajouter : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\..\View\livres\Ajouter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TitreTextBox;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\..\View\livres\Ajouter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DatePublicationTextBox;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\..\View\livres\Ajouter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CouvertureTextBox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\..\View\livres\Ajouter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox GenreComboBox;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\..\View\livres\Ajouter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox AuteurComboBox;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\..\View\livres\Ajouter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox EditionComboBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.12.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/gestion_bibliotheque;component/view/livres/ajouter.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\livres\Ajouter.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.12.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TitreTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.DatePublicationTextBox = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.CouvertureTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            
            #line 24 "..\..\..\..\..\View\livres\Ajouter.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SelectionnerImage_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.GenreComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.AuteurComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.EditionComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            
            #line 38 "..\..\..\..\..\View\livres\Ajouter.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AjouterLivre_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

