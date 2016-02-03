using System;
using System.Threading.Tasks;
using ContactosModel.Model;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;

namespace DemoCamara
{
    public class UploadFile
    {
        private string url = "http://apiredcontacto.azurewebsites.net/api/Camera";

        public async Task<string> SubirFoto(byte[] file)
        {
            //Creamos el restclient
            var client=new RestClient(url);
            
            var request=new RestRequest();
            //le decimos de que tipo es el metodo
            request.Method = Method.POST;

            //Creamos el objeto del tipo FotoModel con todos los datos del fichero
            var d = new FotosModel() {Datos = Convert.ToBase64String(file), Id = 2}; //el id no es necesario

            //Le incluimos el JSON a la variable
            request.AddJsonBody(d);

            //Y ejecutamos
            var r = await client.Execute<string>(request);

            return r.Data;
        }
    }
}