using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using ProbeDesigner.Model;
using ProbeDesigner.Service;
using ReactiveUI;

namespace ProbeDesigner.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ReactiveObject
    {

        private readonly IDataService _dataService;

        private string _welcomeTitle = string.Empty;
        private string _nomenclatureTitle;


        public ReactiveCommand ExitCommand { get; private set; }



        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get {return _welcomeTitle;}
            set{this.RaiseAndSetIfChanged(ref _welcomeTitle, value);}
        }

        public string NomenclatureTitle
        {
            get{return _nomenclatureTitle;}
            set{this.RaiseAndSetIfChanged(ref _nomenclatureTitle, value);}
        }


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null) { return; }
                    WelcomeTitle = item.Title;
                });

            _dataService.GetImgtSequenceData((item, error) => { if (error != null) return; NomenclatureTitle = item.Title; });

            ExitCommand = new ReactiveCommand();
            ExitCommand.Subscribe(_ => Exit());

            OpenNomenclatureCommand = new ReactiveCommand();
            OpenNomenclatureCommand.RegisterAsyncAction(_ => OpenNomenclature());

            OpenProbesCommand = new ReactiveCommand();
            OpenProbesCommand.RegisterAsyncAction(_ => OpenProbes());

        }

        private object OpenNomenclature()
        {
            Thread.Sleep(5000);
            return null;
        }

        private object OpenProbes()
        {
            Thread.Sleep(15000);
            return null;
        }


        public ReactiveCommand OpenProbesCommand
        { get; private set; }


        public ReactiveCommand OpenNomenclatureCommand
        { get; private set; }

        private void Exit()
        {
            Application.Current.Shutdown();
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}