using IC.Utils.Validadores;
using System;
using System.Diagnostics;
using System.IO;

namespace GerenteDeArquivo
{
    public class GerenteDeArquivo
    {
        const string program = @"C:\Faculdade\IC\progs\Spek\spek.exe";
        public string PathFiles { get; }
        public GerenteDeArquivo(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Patn não pode ser nulo ou vazio", nameof(path));
            }

            PathFiles = path;
        }


        public void BusqueArquivos(bool apenasNaoExistentes = false)
        {
            var dir = new DirectoryInfo(PathFiles);
            BusqueArquivosRecursivo(dir, apenasNaoExistentes);
        }

        private void BusqueArquivosRecursivo(DirectoryInfo dir, bool apenasNaoExistentes)
        {
            int i = dir.GetFiles().Length;
            foreach (FileInfo file in dir.GetFiles())
            {
                i++;
                string arquivo = file.DirectoryName + @"\" + file.Name;
                if (!ValidadorDeTipo.EhInteiro(file.Name.Replace(file.Extension, string.Empty)))
                {
                    File.Move(arquivo, file.DirectoryName + "/" + i.ToString() + file.Extension);
                    arquivo = file.DirectoryName + @"/" + i.ToString() + file.Extension;
                }

                CrieEspectograma(arquivo);
            }

            foreach (DirectoryInfo subDir in dir.GetDirectories())
            {
                BusqueArquivosRecursivo(subDir, apenasNaoExistentes);
            }
        }

        private void CrieEspectograma(string arquivo)
        {
           // Process.Start(program, arquivo);
            using (Process processo = new Process())
            {
                processo.StartInfo.UseShellExecute = false;
                processo.StartInfo.FileName = program;
                processo.StartInfo.CreateNoWindow = false;
                processo.StartInfo.Arguments = arquivo;
                processo.Start();
            }
        }
    }
}
