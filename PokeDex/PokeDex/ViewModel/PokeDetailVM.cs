using PokeDex.Model;
using PokeDex.Services;

using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace PokeDex.ViewModel {
    public class PokeDetailVM : ViewModelBase {

        private ObservableCollection<PokeDescription> _pokeDesc;
        public ObservableCollection<PokeDescription> pokeDesc {
            get { return _pokeDesc; }
            set
            {
                if (_pokeDesc != value) {
                    _pokeDesc = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _PokeName;
        public string PokeName {
            get { return _PokeName; }
            set
            {
                if (_PokeName != value) {
                    _PokeName = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _PokeImage;
        public string PokeImage {
            get { return _PokeImage; }
            set
            {
                if (_PokeImage != value) {
                    _PokeImage = value;
                    RaisePropertyChanged();
                }
            }
        }


        private ObservableCollection<string> _PokeAbilities;
        public ObservableCollection<string> PokeAbilities {
            get { return _PokeAbilities; }
            set
            {
                if (_PokeAbilities != value) {
                    _PokeAbilities = value;
                    RaisePropertyChanged();
                }
            }
        }


        private string _PokeDesc;
        public string PokeDesc {
            get { return _PokeDesc; }
            set
            {
                if (_PokeDesc != value) {
                    _PokeDesc = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand speakCommad { get; set; }
        public PokeDetailVM(Result item) {

            getPokemonData(item.id);
            PokeName = item.name;
            speakCommad = new Command(async() => {

                await SpeakNowDefaultSettings(PokeDesc);

            });

        }

        private async void getPokemonData(int id) {

            PokeAbilities = new ObservableCollection<string>();

            pokeDesc = new ObservableCollection<PokeDescription>();

            pokeDesc = await PokeServices.getPokemonDetaliAsync(id);

            foreach (var item in pokeDesc) {

                PokeImage = item.sprite;
                PokeDesc = item.description;

                foreach (var elem in item.abilities.normal) {

                    if (!PokeAbilities.Contains(elem)) {
                        PokeAbilities.Add(elem);
                    }
                }
            }
        }

        public async Task SpeakNowDefaultSettings(string text) {
            await TextToSpeech.SpeakAsync(text);

            // This method will block until utterance finishes.
        }
    }
}
