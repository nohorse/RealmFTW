﻿using System;

using CommonServiceLocator;

using GalaSoft.MvvmLight.Ioc;

using RealmFTW.Services;
using RealmFTW.Views;

namespace RealmFTW.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register(() => new NavigationServiceEx());
            SimpleIoc.Default.Register<ShellViewModel>();
            SimpleIoc.Default.Register<NetDataService>();
            SimpleIoc.Default.Register<RealmService>();

            Register<MainViewModel, MainPage>();
            Register<ImageGalleryViewModel, ImageGalleryPage>();
            Register<ImageGalleryDetailViewModel, ImageGalleryDetailPage>();
            Register<SettingsViewModel, SettingsPage>();
            Register<ReposViewModel, ReposPage>();
        }

        public ReposViewModel ReposViewModel => ServiceLocator.Current.GetInstance<ReposViewModel>();

        public SettingsViewModel SettingsViewModel => ServiceLocator.Current.GetInstance<SettingsViewModel>();

        public ImageGalleryDetailViewModel ImageGalleryDetailViewModel => ServiceLocator.Current.GetInstance<ImageGalleryDetailViewModel>();

        public ImageGalleryViewModel ImageGalleryViewModel => ServiceLocator.Current.GetInstance<ImageGalleryViewModel>();

        public MainViewModel MainViewModel => ServiceLocator.Current.GetInstance<MainViewModel>();

        public ShellViewModel ShellViewModel => ServiceLocator.Current.GetInstance<ShellViewModel>();

        public NavigationServiceEx NavigationService => ServiceLocator.Current.GetInstance<NavigationServiceEx>();

        public NetDataService NetDataService => ServiceLocator.Current.GetInstance<NetDataService>();

        public RealmService RealmService => ServiceLocator.Current.GetInstance<RealmService>();

        public void Register<VM, V>()
            where VM : class
        {
            SimpleIoc.Default.Register<VM>();

            NavigationService.Configure(typeof(VM).FullName, typeof(V));
        }
    }
}
