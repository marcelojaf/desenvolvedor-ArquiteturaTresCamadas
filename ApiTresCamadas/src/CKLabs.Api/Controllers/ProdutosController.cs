using AutoMapper;
using CKLabs.Api.DTO;
using CKLabs.Business.Interfaces;
using CKLabs.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CKLabs.Api.Controllers
{
    /// <summary>
    /// Controller de Produtos
    /// </summary>
    [Route("api/produtos")]
    public class ProdutosController : MainController
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="produtoRepository"></param>
        /// <param name="produtoService"></param>
        /// <param name="mapper"></param>
        public ProdutosController(IProdutoRepository produtoRepository,
                                  IProdutoService produtoService,
                                  IMapper mapper,
                                  INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
            _produtoService = produtoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Obter todos os Produtos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<ProdutoDTO>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ProdutoDTO>>(await _produtoRepository.ObterProdutosFornecedores());
        }

        /// <summary>
        /// Obter Produto por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProdutoDTO>> ObterPorId(Guid id)
        {
            var produtoDTO = await ObterProduto(id);

            if (produtoDTO == null) return NotFound();

            return produtoDTO;
        }

        /// <summary>
        /// Adicionar Produto
        /// </summary>
        /// <param name="produtoDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ProdutoDTO>> Adicionar(ProdutoDTO produtoDTO)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            await _produtoService.Adicionar(_mapper.Map<Produto>(produtoDTO));

            return CustomResponse(HttpStatusCode.Created, produtoDTO);
        }

        /// <summary>
        /// Atualizar Produto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="produtoDTO"></param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProdutoDTO>> Atualizar(Guid id, ProdutoDTO produtoDTO)
        {
            if (id != produtoDTO.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            var produtoAtualizacao = await ObterProduto(id);

            produtoAtualizacao.Nome = produtoDTO.Nome;
            produtoAtualizacao.Descricao = produtoDTO.Descricao;
            produtoAtualizacao.Valor = produtoDTO.Valor;
            produtoAtualizacao.Ativo = produtoDTO.Ativo;
            produtoAtualizacao.FornecedorId = produtoDTO.FornecedorId;

            await _produtoService.Atualizar(_mapper.Map<Produto>(produtoAtualizacao));

            return CustomResponse(HttpStatusCode.NoContent, produtoDTO);
        }

        /// <summary>
        /// Remover Produto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProdutoDTO>> Excluir(Guid id)
        {
            var produtoDTO = await ObterProduto(id);

            if (produtoDTO == null) return NotFound();

            await _produtoService.Remover(id);

            return CustomResponse(HttpStatusCode.NoContent);
        }


        /// <summary>
        /// Retorna um ProdutoDTO com o Fornecedor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<ProdutoDTO> ObterProduto(Guid id)
        {
            return _mapper.Map<ProdutoDTO>(await _produtoRepository.ObterProdutoFornecedor(id));
        }
    }
}
