using ImageCircle.Forms.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FifaGuide.Views
{
    public partial class DetailPlayer : ContentPage
    {
        private Models.Jogador jogador;



        public DetailPlayer(Models.Jogador jogador)
        {

            this.jogador = jogador;

            InitializeComponent();

            //rltPrincipal

            BackgroundColor = Color.White;

            var backgroundImage = new Image()
            {
                Source = new FileImageSource() { File = "futboolField.jpg" },
                Aspect = Aspect.AspectFill,
                IsOpaque = true,
                Opacity = 0.8,
            };

            var dome = new Image()
            {
                Aspect = Aspect.AspectFill,
                Source = new FileImageSource() { File = "dome.png" }
            };

            var shader = new BoxView()
            {
                Color = Color.Black.MultiplyAlpha(.5),
            };

            var face = new CircleImage()
            {
                Aspect = Aspect.AspectFit,
                Source = jogador.urlProfileImage,
                BorderThickness = 5
            };

            var nation = new Image()
            {
                Aspect = Aspect.AspectFill,
                Source = jogador.urlNacImage
            };

            var details = new ContentView()
            {
                Content = new StackLayout()
                {
                    Padding = new Thickness(20, 10),
                    Children = { 
                        new Label(){
                            Text = jogador.first_name +" "+jogador.last_name,
                            FontSize = 20,
                            XAlign = TextAlignment.Center,
                            TextColor = Color.Black
                        }
                    }
                }
            };

            rltPrincipal.Children.Add(
                backgroundImage,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Height * .5;
                })
            );

            rltPrincipal.Children.Add(
                shader,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Height * .5;
                })
            );

            rltPrincipal.Children.Add(
                dome,
                Constraint.Constant(-10),
                Constraint.RelativeToParent((parent) =>
                {
                    return (parent.Height * .5) - 50;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width + 10;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Height * .2;
                })
            );

            rltPrincipal.Children.Add(
                face,
                Constraint.RelativeToParent((parent) =>
                {
                    return ((parent.Width / 2) - (face.Width / 2));
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Height * .35;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width * .3;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width * .3;
                })
            );

            rltPrincipal.Children.Add(
               nation,
               Constraint.RelativeToParent((parent) =>
               {
                   return parent.Width * .05;
               }),
                Constraint.RelativeToParent((parent) =>
                {
                    return (parent.Height * .2);
                })

           );

            rltPrincipal.Children.Add(
                details,
                Constraint.Constant(0),
                Constraint.RelativeToView(dome, (parent, view) =>
                {
                    return view.Y + view.Height + 30;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width;
                }),
                Constraint.Constant(120)
            );

            face.SizeChanged += (sender, e) =>
            {
                rltPrincipal.ForceLayout();
            };

            Content = rltPrincipal;
        }
    }
}
