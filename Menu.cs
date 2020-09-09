using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace IC.Console
{
    public class Menu
    {
        public const string CaminhoMusica = @"C:\Faculdade\IC\Musicas\";
        public static void MenuPrincipal()
        {
           

            WriteLine(" *******************************************************");
            WriteLine("1 - Gerar Espectogramas");
            OpcoesMenuPrincipal(int.Parse(ReadLine()));
            
        }

        private static void OpcoesMenuPrincipal(int key)
        {
            
            switch (key)
            {
                case 1: OpcaoGerarEspectograma(); break;
                default:MenuPrincipal();break;
            }
        }
        private static void OpcaoGerarEspectograma()
        {
            
            WriteLine($"Caminho Musicas = {CaminhoMusica}");
            WriteLine("Permanecer nesse caminho ? (s/n)" );
            if(ReadLine().ToLower() != "s")
            {
                MenuPrincipal();
                return;
            }

            GerarEspectograma();
        }

        private static void GerarEspectograma()
        {
            
            var gerente = new GerenteDeArquivo.GerenteDeArquivo(CaminhoMusica);
            gerente.BusqueArquivos();
        }

        
    }
}

public class Musica : BeepNotas
{

    public void OhDeAlegria()
    {
        const int umSegundo = 500;
        //Primeira Estrofe
        BeepMi(umSegundo);
        BeepMi(umSegundo);
        BeepFa(umSegundo);
        BeepSol(umSegundo);
        BeepSol(umSegundo);
        BeepFa(umSegundo);
        BeepMi(umSegundo);
        BeepRe(umSegundo);
        BeepDo(umSegundo);
        BeepDo(umSegundo);
        BeepRe(umSegundo);
        BeepMi(umSegundo);
        BeepMi(umSegundo);
        BeepRe(umSegundo);
        BeepRe(umSegundo);

        //Segunda Estrofe
        BeepMi(umSegundo);
        BeepMi(umSegundo);
        BeepFa(umSegundo);
        BeepSol(umSegundo);
        BeepSol(umSegundo);
        BeepFa(umSegundo);
        BeepMi(umSegundo);
        BeepRe(umSegundo);
        BeepDo(umSegundo);
        BeepDo(umSegundo);
        BeepRe(umSegundo);
        BeepMi(umSegundo);
        BeepRe(umSegundo);
        BeepDo(umSegundo);
        BeepDo(umSegundo);
    }
}

public class BeepNotas : NotasNaturais
{
    public void BeepDo(int duracao) => Beep(DO, duracao);
    public void BeepRe(int duracao) => Beep(RE, duracao);
    public void BeepMi(int duracao) => Beep(MI, duracao);
    public void BeepFa(int duracao) => Beep(FA, duracao);
    public void BeepSol(int duracao) => Beep(SOL, duracao);
    public void BeepLa(int duracao) => Beep(LA, duracao);
    public void BeepSi(int duracao) => Beep(SI, duracao);
}

public class NotasNaturais
{
    public int DO => 264;
    public int RE => 297;
    public int MI => 330;
    public int FA => 352;
    public int SOL => 396;
    public int LA => 440;
    public int SI => 495;
}




