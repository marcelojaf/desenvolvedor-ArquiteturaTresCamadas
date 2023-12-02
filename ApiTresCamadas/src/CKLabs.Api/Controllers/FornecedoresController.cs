using AutoMapper;
using CKLabs.Api.DTO;
using CKLabs.Business.Interfaces;
using CKLabs.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CKLabs.Api.Controllers
{
    /// <summary>
    /// Controller de Fornecedores
    /// </summary>
    [Route("api/fornecedores")]
    public class FornecedoresController : MainController
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IFornecedorService _fornecedorService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Construtor
        /// </summary>
        public FornecedoresController(IFornecedorRepository fornecedorRepository,
                                      IFornecedorService fornecedorService,
                                      IMapper mapper,
                                      INotificador notificador) : base(notificador)
        {
            _fornecedorRepository = fornecedorRepository;
            _fornecedorService = fornecedorService;
            _mapper = mapper;
        }

        /// <summary>
        /// Obter todos os Fornecedores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<FornecedorDTO>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<FornecedorDTO>>(await _fornecedorRepository.ObterTodos());
        }

        /// <summary>
        /// Obter Fornecedor por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FornecedorDTO>> ObterPorId(Guid id)
        {
            var fornecedorDTO = await ObterFornecedor(id);

            if (fornecedorDTO == null) return NotFound();

            return fornecedorDTO;
        }

        /// <summary>
        /// Adicionar Fornecedor
        /// </summary>
        /// <param name="fornecedorDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<FornecedorDTO>> Adicionar(FornecedorDTO fornecedorDTO)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            await _fornecedorService.Adicionar(_mapper.Map<Fornecedor>(fornecedorDTO));

            return CustomResponse(HttpStatusCode.Created, fornecedorDTO);
        }

        /// <summary>
        /// Atualizar Fornecedor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fornecedorDTO"></param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<FornecedorDTO>> Atualizar(Guid id, FornecedorDTO fornecedorDTO)
        {
            if (id != fornecedorDTO.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            await _fornecedorService.Atualizar(_mapper.Map<Fornecedor>(fornecedorDTO));

            return CustomResponse(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Remover Fornecedor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<FornecedorDTO>> Excluir(Guid id)
        {
            await _fornecedorService.Remover(id);

            return CustomResponse(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Retorna um FornecedorDTO com seus Produtos e Endereço
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<FornecedorDTO> ObterFornecedor(Guid id)
        {
            return _mapper.Map<FornecedorDTO>(await _fornecedorRepository.ObterFornecedorProdutosEndereco(id));
        }

    }
}
