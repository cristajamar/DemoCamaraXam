using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace DemoCamara
{
    public partial class Inicio : ContentPage
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            //TakePhotoAsync abre la camara, StoreCameraMediaIption: le indicamos
            //el directorio donde guardarlo y el nombre de la foro
            var f = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
            {
                Directory = "Fotos",
                Name = "miforo.jpj"

            });


            //Asignamos para realizar la conexión stream
            var st = f.GetStream();

            //borra el fichero del disco,porque al subirlo a la nube ya no es necesario tenerlo guardado
            f.Dispose();
            var l = st.Length;
            byte[] bt = new byte[l];
            st.Read(bt, 0, bt.Length);

            var upload = new UploadFile();

            await upload.SubirFoto(bt);


            Mifoto.Source = ImageSource.FromStream(() => st);
             
       
        }
    }
}
