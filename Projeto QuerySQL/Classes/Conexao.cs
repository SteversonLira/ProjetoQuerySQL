using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_QuerySQL.Classes
{
    public class Conexao
    {
        public static string ConexaoBancoDados()
        {
            ReadConfigFile();
            //string connectionString = @"Data Source=" + variaveisglobal.dataSource + ";Initial Catalog=SCL_BANCO;Persist Security Info=True;User ID=" + variaveisglobal.usuario + ";Password="+ variaveisglobal.senha;
            //string connectionString = @"Data Source=" + variaveisglobal.dataSource + ";Initial Catalog=SCL_BANCO;Persist Security Info=True;User ID=" + variaveisglobal.usuario + ";Password=" + variaveisglobal.senha;
            //string connectionString = @"Data Source=" + variaveisglobal.dataSource + ";Initial Catalog=AuxilioProgramacao;Persist Security Info=True;User ID=" + variaveisglobal.usuario + ";Password=" + variaveisglobal.senha;
            //variaveisglobal.StringDeConexao = connectionString;
            string connectionString = @"Data Source= TID-STEVERSON\SQLEXPRESS;Integrated Security=false;Initial Catalog=ProjetoQuerySQL;UID=sa;PWD=Steverson2054";
            return connectionString;
        }

        private static void ReadConfigFile()
        {
            //ler arquivo
            //string[] lines = System.IO.File.ReadAllLines(@"X:\EXETPS\PONTE.tps");
            ////string[] lines = System.IO.File.ReadAllLines(@"\SCL\EXETPS\PONTE.tps");
            //variaveisglobal.dataSource = lines[0];
            //variaveisglobal.usuario = lines[1];
            //variaveisglobal.senha = lines[2];
            //variaveisglobal.dataBase = lines[3];

            //variaveisglobal.dataSource = Settings.Default["DATA_BASE"].ToString();
            //variaveisglobal.usuario = Settings.Default["USUARIO"].ToString();
            //variaveisglobal.senha = Settings.Default["SENHA"].ToString();
        }
    }
}
