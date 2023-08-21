using AutoMapper;
using WS.Basic.Webapi.Data;
using WS.Basic.Webapi.Models;
using Microsoft.AspNetCore.Mvc;
using WS.Basic.Webapi.Entities;

namespace WS.Basic.Webapi.Controllers
{
    [ApiController]
    [Route("api/Categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ProductDbContext _context;
        private readonly IMapper _mapper;
        public CategoryController(ProductDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// Obter todas as categorias
        /// </summary>
        /// <returns>Coleção de categorias</returns>
        /// <response code="200"> Sucesso </response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var getCategory = _context.Categories.ToList();

            var categoryView = _mapper.Map<List<CategoryViewModel>>(getCategory);

            return Ok(categoryView);
        }

        /// <summary>
        /// Obter uma categoria
        /// </summary>
        /// <param name="id">Identificado da categoria</param>
        /// <returns>Dados da categoria</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var getCategory = _context.Categories.SingleOrDefault(ca => ca.CategoryId == id);

            if (getCategory == null) return NotFound();

            var categoryView = _mapper.Map<CategoryViewModel>(getCategory);

            return Ok(categoryView);
        }

        /// <summary>
        /// Cadastrar uma categoria
        /// </summary>
        /// <remarks>
        /// {  "id": 0,  "title": "string"}
        /// </remarks>
        /// <param name="categoryInpu">Input Categoria</param>
        /// <returns>dados da categoria cadastrado</returns>
        /// <response code="201">Criado com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post(CategoryInputModel categoryInpu)
        {
            var category = _mapper.Map<Category>(categoryInpu);

            _context.Categories.Add(category);
            _context.SaveChanges();

            var categoryView = _mapper.Map<CategoryViewModel>(category);

            return CreatedAtAction(nameof(GetById), new { id = category.CategoryId }, categoryView);
        }


        /// <summary>
        /// Deletar uma categoria
        /// </summary>
        /// <param name="id">identificador de categoria</param>
        /// <returns>Data</returns>
        /// <reponse code="204">Sucesso</reponse>
        /// <response code="404">Não encontrado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var getCategory = _context.Categories.SingleOrDefault(ca => ca.CategoryId == id);

            if (getCategory == null) return NotFound();

            _context.Categories.Remove(getCategory);
            _context.SaveChanges();

            return NoContent();
        }
    }
}