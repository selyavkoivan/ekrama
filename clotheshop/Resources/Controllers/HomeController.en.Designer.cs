﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace clotheshop {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class HomeController_en {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal HomeController_en() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("clotheshop.Resources.Controllers.HomeController.en", typeof(HomeController_en).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to email.
        /// </summary>
        internal static string email {
            get {
                return ResourceManager.GetString("email", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to password.
        /// </summary>
        internal static string password {
            get {
                return ResourceManager.GetString("password", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to repeat password.
        /// </summary>
        internal static string repeated_password {
            get {
                return ResourceManager.GetString("repeated-password", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to sign up.
        /// </summary>
        internal static string sign_up {
            get {
                return ResourceManager.GetString("sign-up", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to username.
        /// </summary>
        internal static string username {
            get {
                return ResourceManager.GetString("username", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to this username is taken.
        /// </summary>
        internal static string UsernameError {
            get {
                return ResourceManager.GetString("UsernameError", resourceCulture);
            }
        }
    }
}
