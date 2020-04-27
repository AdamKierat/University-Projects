

namespace FootballMenagerMVVM.ViewModel
{
    using System.ComponentModel;
    using System.IO;

    using System.Text.Json;
    using System.Windows.Input;
    using Footballers.ViewModel.BaseClass;
    using Model;
    internal class FootballMenagerViewModel : ViewModelBase
    {
        #region PropertiesDeclaration


        private string forename = null;
        private string surname = null;
        private double? age = 25;
        private double? weight = 0;
        private string Path = "..//PlayersData.json";

        #endregion

        #region PropertiesMethods

        public string Forename
        {
            get => forename;
            set
            {
                forename = value;
                OnPropertyChanged(nameof(Forename));
            }
        }

        public double? Age
        {
            get => age;
            set
            {
                age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        public string Surname
        {
            get => surname;
            set
            {
                surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        public double? Weight
        {
            get => weight;
            set
            {
                weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }

        private Player selectedPlayer = null;

        public Player SelectedPlayer
        {
            get => selectedPlayer; set
            {
                selectedPlayer = value;
                OnPropertyChanged(nameof(SelectedPlayer));
                if (CopyCommand.CanExecute(null)) CopyCommand.Execute(null);
            }
        }

        private BindingList<Player> storedPlayers = new BindingList<Player>();

        public BindingList<Player> StoredPlayers
        {
            get => storedPlayers; 
            set
            {
                storedPlayers = value;
                OnPropertyChanged(nameof(StoredPlayers));
            }
        }

        #endregion

        #region CommandsDeclaration

        private ICommand _addCommand;
        private ICommand _clearCommand;
        private ICommand _copyCommand;
        private ICommand _deleteCommand;
        private ICommand _editCommand;
        private ICommand _loadDataCommand;
        private ICommand _saveDataCommand;

        #endregion

        #region CommandsMethods

        public ICommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new RelayCommand(
                    execute =>
                    {
                        Player player = new Player(Forename, Surname, (double) Age, (double) Weight);
                        if (StoredPlayers.Contains(player)) return;
                        StoredPlayers.Add(player);
                        OnPropertyChanged(nameof(StoredPlayers));
                        ClearCommand.Execute(null);
                    }
                    , canExecute => IsEmpty
                ));
            }
        }

        public ICommand ClearCommand
        {
            get
            {
                return _clearCommand ?? (_clearCommand = new RelayCommand(
                    execute =>
                    {
                        Forename = Surname = null;
                        Weight = Age = null;
                    }
                    , canExecute => true
                ));
            }
        }

        public ICommand CopyCommand
        {
            get
            {
                return _copyCommand ?? (_copyCommand = new RelayCommand(
                    execute =>
                    {
                        Forename = SelectedPlayer.Forename;
                        Surname = SelectedPlayer.Surname;
                        Age = SelectedPlayer.Age;
                        Weight = SelectedPlayer.Weight;
                    }
                    , canExecute => SelectedPlayer != null
                ));
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? (_deleteCommand = new RelayCommand(execute =>
                {
                    if (!StoredPlayers.Contains(SelectedPlayer)) return;
                    StoredPlayers.Remove(SelectedPlayer);
                    OnPropertyChanged(nameof(StoredPlayers));
                }, canExecute => IsEmpty && SelectedPlayer != null));
            }
        }

        public ICommand EditCommand
        {
            get
            {
                return _editCommand ?? (_editCommand = new RelayCommand(execute =>
                {
                    var newPlayer = new Player(Forename, Surname, (double) Age, (double) Weight);
                    if (!StoredPlayers.Contains(SelectedPlayer)) return;
                    var index = StoredPlayers.IndexOf(selectedPlayer);
                    StoredPlayers[index].Copy(newPlayer);
                    StoredPlayers.ResetItem(index);
                    ClearCommand.Execute(null);
                }, canExecute => IsEmpty && SelectedPlayer != null));
            }
        }
        public ICommand LoadDataCommand
        {
            get
            {
                return _loadDataCommand ?? (_loadDataCommand = new RelayCommand(execute =>
                {
                    var jsonPlayers = File.ReadAllText(Path);
                    StoredPlayers = JsonSerializer.Deserialize<BindingList<Player>>(jsonPlayers);
                    OnPropertyChanged(nameof(LoadDataCommand));
                    StoredPlayers.ResetBindings();
                }, canExecute => File.Exists(Path) && (new FileInfo(Path).Length > 0)));
            }
        }

        public ICommand SaveDataCommand
        {
            get
            {
                return _saveDataCommand ?? (_saveDataCommand = new RelayCommand(execute =>
                {
                    var jsonPlayers = JsonSerializer.Serialize(StoredPlayers);
                    File.WriteAllText(Path, jsonPlayers);
                    OnPropertyChanged(nameof(SaveDataCommand));
                }, canExecute => true));
            }
        }


        #endregion

        private bool IsEmpty => (!string.IsNullOrEmpty(Forename) && !string.IsNullOrEmpty(Surname) && Age > 0 && Weight > 0);
    }

}