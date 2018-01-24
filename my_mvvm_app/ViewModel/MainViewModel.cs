using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using my_mvvm_app.Model;
using System.Collections.Generic;
using System.Linq;

namespace my_mvvm_app.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        List<Cards> FootballCards;
        RelayCommand buttonClicked;

        public MainViewModel()
        {
            // propogate the Football cards List
            FootballCards = Helpers.Teams.GenerateCards;

            // give the number of shuffles a default
            NumberOfShuffles = 0;

            // fill the UI properties
            var firstTeam = FootballCards.First();

            TeamName = firstTeam.TeamName;
            StadiumName = firstTeam.StadiumName;
            Capacity = firstTeam.Capacity;
            Longitude = firstTeam.Longitude;
            Latitude = firstTeam.Latitude;
        }


        private int numberOfShuffles;
        public int NumberOfShuffles
        {
            get { return numberOfShuffles; }
            set
            {
                Set(() => NumberOfShuffles, ref numberOfShuffles, value, true);
                // the final true means to broadcast the event
                if (numberOfShuffles > 0)
                    buttonClicked.RaiseCanExecuteChanged();
                // enables the click

            }
        }

        private string teamName;
        public string TeamName
        {
            get { return teamName; }
            set
            {

                Set(() => TeamName, ref teamName, value, true);
            }
        }

        private string stadiumName;
        public string StadiumName
        {
            get { return stadiumName; }
            set
            {

                Set(() => StadiumName, ref stadiumName, value, true);

            }
        }

        private int capacity;
        public int Capacity
        {
            get { return capacity; }
            set
            {
                Set(() => Capacity, ref capacity, value, true);
            }
        }

        private double latitude;
        public double Latitude
        {
            get { return latitude; }
            set
            {

                Set(() => Latitude, ref latitude, value, true);

            }
        }

        private double longitude;
        public double Longitude
        {
            get { return longitude; }
            set
            {

                Set(() => Longitude, ref longitude, value, true);

            }
        }

        public RelayCommand ButtonClicked
        {
            get
            {
                return buttonClicked ?? (buttonClicked = new RelayCommand(() =>
                {
                    // Shuffle the cards NumberOfShuffles times
                    FootballCards = Helpers.CardShuffle.Shuffle(FootballCards, NumberOfShuffles);

                    // get the first card
                    var topCard = FootballCards.First();

                    // propogate the properties
                    TeamName = topCard.TeamName;
                    StadiumName = topCard.StadiumName;
                    Capacity = topCard.Capacity;
                    Longitude = topCard.Longitude;
                    Latitude = topCard.Latitude;
               }));
            }
        }

    }
}