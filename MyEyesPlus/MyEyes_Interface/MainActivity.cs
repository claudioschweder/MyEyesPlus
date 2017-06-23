using Android.App;
using Android.Widget;
using Android.OS;

namespace MyEyes
{
    [Activity(Label = "MyEyes", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            IniciarCamera();

            // Criação de botões
            Button BtnCapturar = FindViewById<Button>(Resource.Id.Capturar);
            Button BtnRepetir = FindViewById<Button>(Resource.Id.Repetir);
            Button BtnVoltar = FindViewById<Button>(Resource.Id.Voltar);

            // Definição dos metodos
            BtnCapturar.Click += delegate { Capturar(); };
            BtnRepetir.Click += delegate { Repetir(); };
            BtnVoltar.Click += delegate { Voltar(); };
        }

        public void IniciarCamera() {
            // Intent intent = new Intent(MediaStore.ActionImageCapture);
            // StartActivityForResult(intent, 0);
        }

        public void Capturar()
        {
            //define o alerta para executar a tarefa
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            AlertDialog alerta = builder.Create();
            //Define o Titulo
            alerta.SetTitle("Simulador sem câmera");
            alerta.SetIcon(Android.Resource.Drawable.IcDialogAlert);
            alerta.SetMessage("Por estar utilizando um emulador, não tem câmera.");
            alerta.SetButton("OK", (s, ev) =>
            {
                Toast.MakeText(this, "Legal, vamos continuar... !", ToastLength.Short).Show();
            });
            alerta.Show();
        }

        public void Repetir()
        {

        }

        Intent it = new Intent(getApplicationContext(), ActivityMain);
        it.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
        it.putExtra("SAIR", true);
        startActivity(it);

        //no onResume da ActivityMain você coloca o seguinte

        @Override
        protected void onResume()
        {
            if (getIntent().getBooleanExtra("SAIR", false))
            {
                finish();
            }
            super.onResume();
        }

        public void Voltar()
        {
            //define o alerta para executar a tarefa
            AlertDialog.Builder alerta = new AlertDialog.Builder(this);
            alerta.SetTitle("Sair");
            alerta.SetIcon(Android.Resource.Drawable.IcDialogAlert);
            alerta.SetMessage("Deseja realmente sair");
            //define o botão positivo
            alerta.SetPositiveButton("Ok", (senderAlert, args) =>
            {
                this.finish();
            });
            //define o botão negativo
            alerta.SetNegativeButton("Cancelar", (senderAlert, args) =>
            {
                Toast.MakeText(this, "Cancelado !", ToastLength.Short).Show();
            });
            //cria o alerta e exibe
            Dialog dialog = alerta.Create();
            dialog.Show();
        }
    }
}

