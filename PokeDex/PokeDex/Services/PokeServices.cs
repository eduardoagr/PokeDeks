using Newtonsoft.Json;

using PokeDex.Model;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

using Xamarin.Essentials;

namespace PokeDex.Services {
    public class PokeServices {

        const string BASE_URL = "https://pokeapi.co/api/v2/pokemon?limit=151";
        const string SECUNDARY_API = "https://pokeapi.glitch.me/v1/pokemon/{0}";


        #region Basic Pokemon Data
        public static async Task<ObservableCollection<Result>> getPokemonsAsync() {

            if (Connectivity.NetworkAccess.Equals(NetworkAccess.Internet)) {

                ObservableCollection<Result> pokeData = new ObservableCollection<Result>();

                using (HttpClient client = new HttpClient()) {

                    HttpResponseMessage message = await client.GetAsync(BASE_URL);
                    if (message.IsSuccessStatusCode) {
                        string result = await message.Content.ReadAsStringAsync();
                        var jsonRoot = JsonConvert.DeserializeObject<RootObj>(result);

                        pokeData.Clear();

                        foreach (var item in jsonRoot.results) {

                            item.id = Convert.ToInt32(item.url.Split('/')[6]);

                            item.image_url =
                                $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{item.id}.png";

                            pokeData.Add(item);
                        }
                        return pokeData;
                    }
                }

            }
            return null;
        }
        #endregion

        #region Pokemon detail
        public static async Task<ObservableCollection<PokeDescription>> getPokemonDetaliAsync(int id) {

            if (Connectivity.NetworkAccess == NetworkAccess.Internet) {

                var url = string.Format(SECUNDARY_API, id);

                using (HttpClient client = new HttpClient()) {

                    HttpResponseMessage message = await client.GetAsync(url);
                    if (message.IsSuccessStatusCode) {
                        string result = await message.Content.ReadAsStringAsync();
                        var json = JsonConvert.DeserializeObject<ObservableCollection<PokeDescription>>(result);
                        return json;
                    }
                }
            }

            return null;
        }

        #endregion
    }
}