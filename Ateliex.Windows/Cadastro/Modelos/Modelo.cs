using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Xml;

namespace Ateliex.Cadastro.Modelos
{
    public class ModelosResource : ResourceCollection<ModeloResource>
    {
        public ConsultaDeModelosResource GetConsultaDeModelos()
        {
            // GET /cadastro/modelos/consulta-de-modelos

            var resource = new ConsultaDeModelosResource();

            return resource;
        }

        public CadastroDeModelosResource GetCadastroDeModelos()
        {
            // GET /cadastro/modelos/{codigo}/cadastro-de-modelos

            var resource = new CadastroDeModelosResource();

            return resource;
        }
    }

    public class ModeloResource : Resource
    {
        public string Codigo { get; set; }

        public string Nome { get; set; }
        
        public decimal CustoDeProducao { get; set; }

        public DetalhesDeModeloResource GetDetalhesDeModelo()
        {
            // GET /cadastro/modelos/{Codigo}

            var resource = new DetalhesDeModeloResource();

            return resource;
        }

        public AlteracaoDeModelosResource GetAlteracaoDeModelos()
        {
            // GET /cadastro/modelos/{Codigo}/alteracao-de-modelos

            var resource = new AlteracaoDeModelosResource();

            return resource;
        }

        public ExclusaoDeModelosResource GetExclusaoDeModelos()
        {
            // GET /cadastro/modelos/{Codigo}/exclusao-de-modelos

            var resource = new ExclusaoDeModelosResource();

            return resource;
        }
    }

    public class DetalhesDeModeloResource : ModeloResource
    {
        public RecursoResource[] Recursos { get; set; }

        public AdicaoDeRecursosResource GetAdicaoDeRecursos()
        {
            // GET /cadastro/modelos/{Codigo}/adicao-de-recursos

            var resource = new AdicaoDeRecursosResource();

            return resource;
        }
    }

    public class RecursoResource : Resource
    {
        public string Descricao { get; set; }
    }

    public class DetalhesDeRecurso : RecursoResource
    {
        public ExclusaoDeModelosResource GetExclusaoDeRecursos()
        {
            // GET /cadastro/modelos/{Codigo}/exclusao-de-modelos

            var resource = new ExclusaoDeModelosResource();

            return resource;
        }
    }

    public class AdicaoDeRecursosResource : Resource
    {
        public string CodigoDeModelo { get; set; }

        public string Descricao { get; set; }

        public DetalhesDeRecurso Post()
        {
            // POST /cadastro/modelos/{CodigoDeModelo}/adicao-de-recursos
            //
            // Descricao={Descricao}

            var resource = new DetalhesDeRecurso();

            return resource;
        }
    }

    public class ExclusaoDeRecursosResource : Resource
    {
        public string Codigo { get; set; }

        public string Id { get; set; }

        public DetalhesDeModeloResource Post()
        {
            // POST /cadastro/modelos/{Codigo}/recursos/{Id}/exclusao-de-recursos

            var resource = new DetalhesDeModeloResource();

            return resource;
        }
    }

    public class ConsultaDeModelosResource : Resource
    {
        public string Nome { get; set; }

        public long PrimeiraPagina { get; set; }

        public long TamanhoDaPagina { get; set; }

        public ModelosResource GetModelos()
        {
            // GET /cadastro/modelos?Nome={Nome}&PrimeiraPagina={PrimeiraPagina}&TamanhoDaPagina={TamanhoDaPagina}

            var resource = new ModelosResource();

            return resource;
        }
    }

    public class CadastroDeModelosResource : Resource
    {
        public string Codigo { get; set; }

        public string Nome { get; set; }

        public ModeloResource Post()
        {
            // POST /cadastro/modelos/cadastro-de-modelos
            //
            // Codigo={Codigo},Nome={Nome}

            var resource = new ModeloResource();

            return resource;
        }
    }

    public class AlteracaoDeModelosResource : Resource
    {
        public string Codigo { get; set; }

        public string Nome { get; set; }

        public DetalhesDeModeloResource Post()
        {
            // POST /cadastro/modelos/{Codigo}/alteracao-de-modelos

            var resource = new DetalhesDeModeloResource();

            return resource;
        }
    }

    public class ExclusaoDeModelosResource : Resource
    {
        public string Codigo { get; set; }

        public ModelosResource Post()
        {
            // POST /cadastro/modelos/{Codigo}/exclusao-de-modelos

            var resource = new ModelosResource();

            return resource;
        }
    }
}
