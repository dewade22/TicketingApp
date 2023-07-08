﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TA.UserAccount.Core.Resource {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class UserAccountResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal UserAccountResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TA.UserAccount.Core.Resource.UserAccountResource", typeof(UserAccountResource).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to User with email address {0} already registered.
        /// </summary>
        public static string CreateUser_EmailExist {
            get {
                return ResourceManager.GetString("CreateUser_EmailExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to generate token.
        /// </summary>
        public static string Token_FailedToGenerate {
            get {
                return ResourceManager.GetString("Token_FailedToGenerate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to User has been archived.
        /// </summary>
        public static string User_Archived {
            get {
                return ResourceManager.GetString("User_Archived", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to User with email address {0} not registered in the system.
        /// </summary>
        public static string User_NotRegistered {
            get {
                return ResourceManager.GetString("User_NotRegistered", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Password is invalid.
        /// </summary>
        public static string User_WrongPassword {
            get {
                return ResourceManager.GetString("User_WrongPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Email is empty.
        /// </summary>
        public static string UserAccount_EmptyEmail {
            get {
                return ResourceManager.GetString("UserAccount_EmptyEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Couldn&apos;t get user with refresh token {0}.
        /// </summary>
        public static string UserAccount_RefreshTokenNotFound {
            get {
                return ResourceManager.GetString("UserAccount_RefreshTokenNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to User with email address {0} cannot be found.
        /// </summary>
        public static string UserEmail_NotFound {
            get {
                return ResourceManager.GetString("UserEmail_NotFound", resourceCulture);
            }
        }
    }
}
