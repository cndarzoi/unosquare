using System;
using System.Runtime.CompilerServices;
using Android.OS;
using Test.Droid.DependecyServices;
using Test.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(SystemInfo))]
namespace Test.Droid.DependecyServices
{
    public class SystemInfo: ISystemInfo
    {
        public string GetAndroidVersionRelease()
        {
            string versionRelease = Build.VERSION.Release;
            return versionRelease;
        }
    }
}
