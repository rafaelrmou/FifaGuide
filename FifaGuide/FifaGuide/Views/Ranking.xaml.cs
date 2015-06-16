using FifaGuide.Models;
using FifaGuide.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FifaGuide.Views
{
    public partial class Ranking : ContentPage
    {
        Dictionary<string, string> filtros = new Dictionary<string, string>() {
            { "Passe", "pace" },
            { "Drible", "dribbling" },
            { "Chute", "shooting" },
            { "Defesa", "defending" },
            { "Cabeçada", "heading" },
            { "Passagem", "passing" },
            { "Altura", "height" },
            { "Avaliação", "rating" },
            { "Vendas", "sales" },
            };

        public Ranking()
        {
            InitializeComponent();



            foreach (var item in filtros.Keys)
            {
                pkAtributos.Items.Add(item);
            }

            pkAtributos.SelectedIndex = 0;


            
        }

        void ListRanking_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;

            var jogador = e.SelectedItem as Jogador;

            ((ListView)sender).SelectedItem = null;

            //App.MasterDetail.Detail = new DetailViagem();
            Navigation.PushAsync(new DetailPlayer(jogador));
        }

        private void UpdateList(string Filter)
        {

            ApiCall apiCall = new ApiCall();

            //Aqui buscamos os 10 com as maiores Notas e Iniciamos uma Thread
            apiCall.GetResponse<List<Jogador>>("topten", Filter).ContinueWith(t =>
            {
                //O ContinueWith é responsavel por fazer algo após o request finalizar

                //Aqui verificamos se houve problema ne requisição
                if (t.IsFaulted)
                {
                    Debug.WriteLine(t.Exception.Message);
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        DisplayAlert("Falha", "Ocorreu um erro na Requisição :(", "Ok");
                    });
                }
                //Aqui verificamos se a requisição foi cancelada por algum Motivo
                else if (t.IsCanceled)
                {
                    Debug.WriteLine("Requisição cancelada");

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        DisplayAlert("Cancela", "Requisição Cancelada :O", "Ok");
                    });
                }
                //Caso a requisição ocorra sem problemas, cairemos aqui
                else
                {
                    //Se Chegarmos aqui, está tudo ok, agora itemos tratar nossa Lista
                    //Aqui Usaremos a Thread Principal, ou seja, a que possui as references da UI
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        ListRanking.ItemsSource = t.Result;
                    });

                }
            });
        }

        private void pkAtributos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pkAtributos.SelectedIndex == -1)
            {
                UpdateList("pace");
            }
            else
            {
                string attrName = pkAtributos.Items[pkAtributos.SelectedIndex];

                UpdateList(filtros[attrName]);
            }
        }


    }
}
