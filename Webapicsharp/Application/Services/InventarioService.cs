using WebApiCSharp.Application.DTOs;
using WebApiCSharp.Application.Interfaces;
using WebApiCSharp.Domain.Entities;
using WebApiCSharp.Domain.Enums;
using WebApiCSharp.Domain.ValueObjects;
using WebApiCSharp.Domain.Repositories;

namespace WebApiCSharp.Application.Services;

public class InventarioService : IInventarioCommand, IInventarioQuery
{
    private readonly IUnitOfWork _unitOfWork;

    public InventarioService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    // =====================
    //      COMMANDS
    // =====================

    public OperationResult AgregarProducto(ProductoDto prod, int cantidad, int usuarioId)
    {
        try
        {
            // Parse tipo from string to enum
            TipoProducto tipoProducto = prod.TipoProducto.ToUpper() switch
            {
                "MATERIAPRIMA" => TipoProducto.MateriaPrima,
                "INTERMEDIO" => TipoProducto.Intermedio,
                "PRODUCTOFINAL" => TipoProducto.ProductoFinal,
                _ => TipoProducto.MateriaPrima
            };

            var producto = new Producto(
                nombre: prod.Nombre,
                descripcion: prod.Descripcion,
                unidadMedida: prod.UnidadMedida,
                costoUnitario: (decimal)prod.CostoUnitario,
                tipoProducto
            );
            
            producto.AgregarStock(cantidad);
            producto.DefinirStockMinimo(0);

            _unitOfWork.Productos.Agregar(producto);
            _unitOfWork.Complete();

            return OperationResult.Ok("Producto registrado correctamente.");
        }
        catch (Exception ex)
        {
            return OperationResult.Fail($"Error al agregar producto: {ex.Message}");
        }
    }


    public OperationResult AjustarStock(int productoId, int ajuste, int usuarioId)
    {
        try
        {
            var producto = _unitOfWork.Productos.ObtenerPorId(productoId);
            if (producto == null)
                return OperationResult.Fail("Producto no encontrado.");

            producto.AjustarStock(ajuste);

            _unitOfWork.Productos.Actualizar(producto);
            _unitOfWork.Complete();

            return OperationResult.Ok("Stock ajustado correctamente.");
        }
        catch (Exception ex)
        {
            return OperationResult.Fail($"Error al ajustar stock: {ex.Message}");
        }
    }


    public OperationResult SetStockMin(int productoId, int cantidad, int usuarioId)
    {
        try
        {
            var producto = _unitOfWork.Productos.ObtenerPorId(productoId);
            if (producto == null)
                return OperationResult.Fail("Producto no encontrado.");

            producto.DefinirStockMinimo(cantidad);

            _unitOfWork.Productos.Actualizar(producto);
            _unitOfWork.Complete();

            return OperationResult.Ok("Stock mínimo actualizado.");
        }
        catch (Exception ex)
        {
            return OperationResult.Fail($"Error en stock mínimo: {ex.Message}");
        }
    }


    // =====================
    //        QUERIES
    // =====================

    public OperationResult BuscarStock(int productoId)
    {
        try
        {
            var producto = _unitOfWork.Productos.ObtenerPorId(productoId);
            if (producto == null)
                return OperationResult.Fail("Producto no encontrado.");

            return OperationResult.Ok($"Stock actual: {producto.CantidadActual}");
        }
        catch (Exception ex)
        {
            return OperationResult.Fail($"Error al consultar stock: {ex.Message}");
        }
    }


    public IEnumerable<Producto> BuscarProductos(FiltroProductoDto filtro)
    {
        return _unitOfWork.Productos.Buscar(filtro);
    }
}
