using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Graphics;
using Android.Provider;
using Android.Runtime;
using Android.Media;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace MyEyes
{
    [Activity(Label = "MyEyes", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int cont;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            MediaPlayer _myPlayer = MediaPlayer.Create(this, DetectarAudio());

            Button BtnCamera = FindViewById<Button>(Resource.Id.Camera);
            Button BtnRepetir = FindViewById<Button>(Resource.Id.Repetir);
            Button BtnFechar = FindViewById<Button>(Resource.Id.Fechar);
            ImageView CmpImageCamera = FindViewById<ImageView>(Resource.Id.ImageCamera);

            BtnCamera.Click += delegate { Camera(); };
            BtnRepetir.Click += delegate { Repetir(_myPlayer); };
            BtnFechar.Click += delegate { Fechar(); };
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            Bitmap imageBitmap = (Bitmap)data.Extras.Get("data");

            ImageView CmpImageCamera = FindViewById<ImageView>(Resource.Id.ImageCamera);
            CmpImageCamera.SetImageBitmap(imageBitmap);

            cont += 1;
            MediaPlayer _myPlayer = MediaPlayer.Create(this, DetectarAudio());
            _myPlayer.Start();
        }

        public void Camera()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            StartActivityForResult(intent, 0);            
        }

        public void Repetir(MediaPlayer _myPlayer)
        {
            _myPlayer.Start();
        }

        public int DetectarAudio()
        {
            switch (cont)
            {
                case 1:
                    return Resource.Raw.EmNomedeOketra;
                case 2:
                    return Resource.Raw.TecelaDeCorrentes;
                case 3:
                    return Resource.Raw.PassagemParaAMaravilha;
                case 4:
                    return Resource.Raw.QuebraCabecaDoFlamiforjador;
                default:
                    cont = 0;
                    return Resource.Raw.RufiaDaSerralheriaClandestina;
            }

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
            { });

            Dialog dialog = alerta.Create();
            dialog.Show();
        }
    }
}