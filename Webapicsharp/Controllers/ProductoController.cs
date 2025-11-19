using Microsoft.AspNetCore.Mvc;
using WebApiCSharp.Application.Interfaces;
using WebApiCSharp.Application.DTOs;
using WebApiCSharp.Domain.Entities;
using WebApiCSharp.Domain.Enums;

namespace WebApiCSharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _service;

        public ProductoController(IProductoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> GetAll()
        {
            var productos = await _service.GetAllAsync();

            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDto>> GetById(int id)
        {
            var p = await _service.GetByIdAsync(id);

            if (p == null)
                return NotFound();

            return Ok(new ProductoDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                TipoProducto = p.TipoProducto,
                Tipo = p.TipoProducto.ToString()
            });
        }

        [HttpPost]
        public async Task<ActionResult<ProductoDto>> Create(ProductoCreateDto dto)
        {
            var productoDto = new ProductoDto
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                UnidadMedida = dto.UnidadMedida,
                CostoUnitario = dto.CostoUnitario,
                Tipo = dto.Tipo
            };

            var id = await _service.CreateAsync(productoDto);

            return CreatedAtAction(nameof(GetById), new { id }, new ProductoDto
            {
                Id = id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                UnidadMedida = dto.UnidadMedida,
                CostoUnitario = dto.CostoUnitario,
                Tipo = dto.Tipo
            });
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductoDto dto)
        {
            var result = await _service.UpdateAsync(dto.Id, dto);

            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
