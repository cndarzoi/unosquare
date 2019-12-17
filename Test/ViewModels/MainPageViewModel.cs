using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Test.Interfaces;
using Test.Models;
using Xamarin.Forms;

namespace Test.ViewModels
{
    /// <summary>
    /// Main page view model
    /// </summary>
    public class MainPageViewModel
    {
        /// <summary>
        /// Add
        /// </summary>
        private ICommand AddCarCommand;

        /// <summary>
        /// Brand entry
        /// </summary>
        private string _brandEntry;

        /// <summary>
        /// Model entry
        /// </summary>
        private string _modelEntry;
        
        /// <summary>
        /// Year entry
        /// </summary>
        private string _yearEntry;

        /// <summary>
        /// Cars
        /// </summary>
        private ObservableCollection<CarModel> _cars;

        /// <summary>
        /// Android version release
        /// </summary>
        private string _androidVersionRelease;

        /// <summary>
        /// Main page view model
        /// </summary>
        public MainPageViewModel()
        {
            Cars = LoadData();

            AndroidVersionRelease = String.Format("Android Version Release: {0}",
                DependencyService.Get<ISystemInfo>().GetAndroidVersionRelease());
        }

        /// <summary>
        /// On add car to list
        /// </summary>
        public Command OnAddCarToList
        {
            get
            {
                return new Command(() => AddCarAsync());
            }
        }

        /// <summary>
        /// Load data
        /// </summary>
        /// <returns>Observable collection</returns>
        private ObservableCollection<CarModel> LoadData()
        {
            List<CarModel> cars = new List<CarModel>()
            {
                new CarModel()
                {
                    Brand = "Ford",
                    Model = "Figo",
                    Year = "2018",
                },
                new CarModel()
                {
                    Brand = "Ford",
                    Model = "Mustang",
                    Year = "2019",
                }
            };

            return new ObservableCollection<CarModel>(cars);
        }

        /// <summary>
        /// Add car
        /// </summary>
        public async Task AddCarAsync()
        {
            CarModel carModel = new CarModel()
            {
                Brand = BrandEntry,
                Model = ModelEntry,
                Year = YearEntry
            };

            bool isValid = Cars.Where(x=>x.Brand  == carModel.Brand).Any();
            isValid = Cars.Where(x => x.Brand == carModel.Brand).Any();
            isValid = Cars.Where(x => x.Brand == carModel.Brand).Any();

            if (!isValid) {
                Cars.Add(carModel);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Adding failed", "It was not possible to add", "OK");
            }
        }


        /// <summary>
        /// Cars
        /// </summary>
        public ObservableCollection<CarModel> Cars
        {
            get
            {
                return _cars;
            }
            set
            {
                if (_cars != value)
                {
                    _cars = value;
                    OnPropertyChanged(nameof(Cars));
                }
            }
        }

        /// <summary>
        /// Brand entry
        /// </summary>
        public string BrandEntry
        {
            get
            {
                return _brandEntry;
            }
            set
            {
                if (_brandEntry != value)
                {
                    _brandEntry = value;
                    OnPropertyChanged(nameof(BrandEntry));
                }
            }
        }

        /// <summary>
        /// Model Entry
        /// </summary>
        public string ModelEntry
        {
            get
            {
                return _modelEntry;
            }
            set
            {
                if (_modelEntry != value)
                {
                    _modelEntry = value;
                    OnPropertyChanged(nameof(BrandEntry));
                }
            }
        }

        /// <summary>
        /// Year Entry
        /// </summary>
        public string YearEntry
        {
            get
            {
                return _yearEntry;
            }
            set
            {
                if (_yearEntry != value)
                {
                    _yearEntry = value;
                    OnPropertyChanged(nameof(YearEntry));
                }
            }
        }

        /// <summary>
        /// Android version release
        /// </summary>
        public string AndroidVersionRelease
        {
            get
            {
                return _androidVersionRelease;
            }
            set
            {
                if (_androidVersionRelease != value)
                {
                    _androidVersionRelease = value;
                    OnPropertyChanged(nameof(AndroidVersionRelease));
                }
            }
        }

        /// <summary>
        /// Property changed
        /// </summary>
        public event PropertyChangingEventHandler PropertyChanged;

        /// <summary>
        /// On property changed
        /// </summary>
        /// <param name="propertyName">Property name</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangingEventArgs(propertyName));
            }
        }

    }
}
