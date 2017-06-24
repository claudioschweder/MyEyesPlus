using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Graphics;
using Android.Provider;
using Android.Runtime;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.IO;

namespace MyEyes
{
    [Activity(Label = "MyEyes", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private int byteArray;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            // Criação de botões
            Button BtnCamera = FindViewById<Button>(Resource.Id.Camera);
            Button BtnRepetir = FindViewById<Button>(Resource.Id.Repetir);
            Button BtnFechar = FindViewById<Button>(Resource.Id.Fechar);
            ImageView CmpImageCamera = FindViewById<ImageView>(Resource.Id.ImageCamera);

            // Definição dos metodos
            BtnCamera.Click += delegate { Camera(); };
            BtnRepetir.Click += delegate { Repetir(); };
            BtnFechar.Click += delegate { Fechar(); };
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            Bitmap imageBitmap = (Bitmap)data.Extras.Get("data");

            ImageView CmpImageCamera = FindViewById<ImageView>(Resource.Id.ImageCamera);
            CmpImageCamera.SetImageBitmap(imageBitmap);
        }

        public static async Task<string> GetStreamStringFromImageSourceAsync(Xamarin.Forms.StreamImageSource imageSource, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (imageSource.Stream != null)
            {
                var stream = await imageSource.Stream(cancellationToken);

                //stream?.Length > 0 can do this - Pubudu
                // stream
                if (stream == null || stream.Length <= 0) return null;

                var bytes = new byte[stream.Length];
                stream.Position = 0;
                stream.Read(bytes, 0, (int)stream.Length);
                return Convert.ToBase64String(bytes);
            }
            return null;
        }

        public void Camera()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            StartActivityForResult(intent, 0);
        }

        public void Repetir()
        {

        }

        public void Fechar()
        {
            AlertDialog.Builder alerta = new AlertDialog.Builder(this);
            alerta.SetTitle("Sair");
            alerta.SetIcon(Android.Resource.Drawable.IcDialogAlert);
            alerta.SetMessage("Deseja realmente fechar o aplicativo?");
            alerta.SetPositiveButton("Ok", (senderAlert, args) =>
            {
                Finish();
            });
            alerta.SetNegativeButton("Cancelar", (senderAlert, args) =>
            {});

            Dialog dialog = alerta.Create();
            dialog.Show();
        }
    }
}