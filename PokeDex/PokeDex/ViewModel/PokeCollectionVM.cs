using PokeDex.Model;
using PokeDex.Services;
using PokeDex.View;

using System.Collections.ObjectModel;
using System.Windows.Input;

using Xamarin.Forms;

namespace PokeDex.ViewModel {
    public class PokeCollectionVM : ViewModelBase {


        private ObservableCollection<Result> _pokeItems;
        private Result selectedItem;

        public ObservableCollection<Result> pokeItems {
            get { return _pokeItems; }
            set
            {
                if (_pokeItems != value) {
                    _pokeItems = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand SelectedItemCommand { get; set; }
        public Result SelectedItem {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public PokeCollectionVM() {

            SelectedItemCommand = new Command(async () => {

                var nav = Application.Current.MainPage;

                await nav.Navigation.PushAsync(new PokeDetailPage(selectedItem));
                selectedItem = null;

            });

            pokeItems = new ObservableCollection<Result>();
            loadData();
        }

        public async void loadData() {

            pokeItems = await PokeServices.getPokemonsAsync();

        }
    }
}
