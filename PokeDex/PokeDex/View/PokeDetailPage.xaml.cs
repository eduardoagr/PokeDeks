
using PokeDex.Model;
using PokeDex.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokeDex.View {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PokeDetailPage : ContentPage {

        public PokeDetailVM pokeDetailVM { get; set; }

        public PokeDetailPage() {
            InitializeComponent();
        }

        public PokeDetailPage(Result item) {
            InitializeComponent();

            pokeDetailVM = new PokeDetailVM(item);

            BindingContext = pokeDetailVM;


        }
    }
}