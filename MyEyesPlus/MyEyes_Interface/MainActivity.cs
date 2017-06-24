using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Graphics;
using Android.Provider;
using Android.Runtime;

namespace MyEyes
{
    [Activity(Label = "MyEyes", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            Intent intent = new Intent(MediaStore.ActionImageCapture);
            StartActivityForResult(intent, 0);

            // Criação de botões
            Button BtnCapturar = FindViewById<Button>(Resource.Id.Capturar);
            Button BtnRepetir = FindViewById<Button>(Resource.Id.Repetir);
            Button BtnVoltar = FindViewById<Button>(Resource.Id.Voltar);
            ImageView CmpImageCamera = FindViewById<ImageView>(Resource.Id.ImageCamera);

            // Definição dos metodos
            BtnCapturar.Click += delegate { Capturar(); };
            BtnRepetir.Click += delegate { Repetir(); };
            BtnVoltar.Click += delegate { Voltar(); };
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            Bitmap imageBitmap = (Bitmap)data.Extras.Get("data");
            ImageView CmpImageCamera = FindViewById<ImageView>(Resource.Id.ImageCamera);
            CmpImageCamera.SetImageBitmap(imageBitmap);
        }


        public void Capturar()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            StartActivityForResult(intent, 0);
        }

        public void Repetir()
        {

        }

        public void Voltar()
        {
            AlertDialog.Builder alerta = new AlertDialog.Builder(this);
            alerta.SetTitle("Sair");
            alerta.SetIcon(Android.Resource.Drawable.IcDialogAlert);
            alerta.SetMessage("Deseja realmente sair");
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