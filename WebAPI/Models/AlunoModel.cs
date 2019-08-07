using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace WebAPI.Models
{
    public class AlunoModel
    {


        #region Estrutura Anterior com Arquivos Texto

        //public List<Aluno> ListarAlunos()
        //{
        //    var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Base.json");

        //    var json = File.ReadAllText(caminhoArquivo);
        //    var lstAlunos = JsonConvert.DeserializeObject<List<Aluno>>(json);

        //    return lstAlunos;
        //}

        //public Aluno Inserir(Aluno Aluno)
        //{
        //    var listaAlunos = this.ListarAlunos();

        //    var maxId = listaAlunos.Max(aluno => aluno.Id);
        //    Aluno.Id = ++maxId;

        //    listaAlunos.Add(Aluno);

        //    ReescreverArquivo(listaAlunos);
        //    return Aluno;
        //}

        //public bool Deletar(int id)
        //{
        //    var listaAlunos = this.ListarAlunos();

        //    var itemIndex = listaAlunos.FindIndex(p => p.Id == id);
        //    if (itemIndex >= 0)
        //    {
        //        listaAlunos.RemoveAt(itemIndex);
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //    ReescreverArquivo(listaAlunos);
        //    return true;
        //}

        //public AlunoDTO Atualizar(int id, AlunoDTO aluno)
        //{
        //    var listaAlunos = this.ListarAlunos();

        //    var itemIndex = listaAlunos.FindIndex(p => p.Id == aluno.Id);
        //    if (itemIndex >= 0)
        //    {
        //        aluno.Id = id;
        //        listaAlunos[itemIndex] = aluno;
        //    }
        //    else
        //    {
        //        return null;
        //    }

        //    ReescreverArquivo(listaAlunos);
        //    return aluno;
        //}

        //public bool ReescreverArquivo(List<AlunoDTO> listaAlunos)
        //{
        //    var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Base.json");

        //    var json = JsonConvert.SerializeObject(listaAlunos, Formatting.Indented);
        //    File.WriteAllText(caminhoArquivo, json);

        //    return true;
        //}


        #endregion

        public List<AlunoDTO> ListarAlunos(int? id = null)
        {
            try
            {
                var alunoBD = new AlunoDAO();

                return alunoBD.ListarAlunosDB(id);
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao listar Alunos : Erro = {ex.Message}");
            }
        }

        public void Inserir(AlunoDTO aluno)
        {
            try
            {
                var alunoDB = new AlunoDAO();
                alunoDB.InserirAlunoDB(aluno);
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao inserir Aluno: Erro = {ex.Message}");
            }
        }

        public void Atualizar(AlunoDTO aluno)
        {
            try
            {
                var alunoDB = new AlunoDAO();
                alunoDB.AtualizarAlunoDB(aluno);
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao Atualizar Aluno: Erro = {ex.Message}");
            }
        }
       
        public void Deletar(int id)
        {
            try
            {
                var alunoBD = new AlunoDAO();
                alunoBD.DeletarAlunoDB(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao Deletar Aluno: Erro => {ex.Message}");
            }

        }
    }
}