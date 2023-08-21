using AutoMapper;
using WS.Basic.Webapi.Data;
using WS.Basic.Webapi.Models;
using Microsoft.AspNetCore.Mvc;
using WS.Basic.Webapi.Entities;

namespace WS.Basic.Webapi.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ProductDbContext _context;
        public ProductController(ProductDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// Obter todos os produtos
        /// </summary>
        /// <returns>Coleção de produtos</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var getProduct = _context.Products.Where(po => po.IsProductActive).ToList();

            var getProductView = _mapper.Map<List<ProductViewModel>>(getProduct);

            return Ok(getProductView);
        }

        /// <summary>
        /// Obter um produto
        /// </summary>
        /// <param name="id">Identificador do produto</param>
        /// <returns>dados do produto</returns>
        /// <response code="404">Não encontrado</response>
        /// <response code="200">Sucesso</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var getProduct = _context.Products.SingleOrDefault(po => po.ProductID == id);

            if (getProduct == null) return NotFound();

            var getProductView = _mapper.Map<ProductViewModel>(getProduct);

            return Ok(getProductView);
        }

        /// <summary>
        /// Cadastra um produto
        /// </summary>
        /// <remarks>
        /// {"id": 0, "name": "string", "quantity": 0, "price": 0, "isDeleted": true, "categoryID": 0, "getCategory": { "id": 0, "title": "string", "getProducts": ["string"] }}
        /// </remarks>
        /// <param name="inputProduct">Objeto Produto</param>
        /// <returns>Informações para consultar o produto ciado e o produto.</returns>
        /// <response code="201">Produto Criado</response>     
        [HttpPost]
        public IActionResult Post(ProductInputModel inputProduct)
        {
            var product = _mapper.Map<Product>(inputProduct);

            _context.Products.Add(product);
            _context.SaveChanges();

            var getProductView = _mapper.Map<ProductViewModel>(product);

            return CreatedAtAction(nameof(GetById), new { id = getProductView.ProductID }, getProductView);
        }

        /// <summary>
        /// Atualizar um produto
        /// </summary>
        /// <remarks>
        /// {"id": 0, "name": "string", "quantity": 0, "price": 0, "isDeleted": true, "categoryID": 0, "getCategory": { "id": 0, "title": "string", "getProducts": ["string"] }}
        /// </remarks>       
        /// <param name="id">Identificador do produto</param>
        /// <param name="inputProduct">Objeto Produto</param>
        /// <returns>Nada</returns>
        /// <response code="204">Sucesso mais sem retorno</response>
        /// <response code="404">Não encontrado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update(int id, ProductInputModel inputProduct)
        {
            var getProduct = _context.Products.SingleOrDefault(po => po.ProductID == id);

            if (getProduct == null) return NotFound();

            getProduct.Update(inputProduct.Name, inputProduct.Quantity, inputProduct.Price, inputProduct.CategoryID);

            _context.Products.Update(getProduct);
            _context.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// Deleta um produto
        /// </summary>
        /// <param name="id">Identificador do produto</param>
        /// <returns>Nada</returns>
        /// <response code="204">Sucesso mais sem retorno</response>
        /// <response code="404">Não encontrado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var getProduct = _context.Products.SingleOrDefault(po => po.ProductID == id);

            if (getProduct == null) return NotFound();

            getProduct.Delete(false);

            _context.SaveChanges();

            return NoContent();
        }
    }
}