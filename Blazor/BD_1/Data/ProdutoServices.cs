using Microsoft.EntityFrameworkCore;

namespace BD_1.Data;
public class ProdutoServices
{
    #region Métodos privados
    private ProdutoDbContext dbContext;
    #endregion

    #region Construtor
    public ProdutoServices(ProdutoDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    #endregion

    #region Metodos Publicos 
    /// <summary>
    /// Retorna a lista de produtos
    /// </summary>
    /// <returns></returns>
    public async Task<List<Produto>> RetornaProdutoAsync()
    {
        return await dbContext.Produto.ToListAsync();
    }

    /// <summary>
    /// Adiciona um novo produto para DbContext e o salva
    /// </summary>
    /// <param name="prod"></param>
    /// <returns></returns>
    public async Task<Produto> AddProductAsync(Produto prod)
    {
        try
        {
            dbContext.Produto.Add(prod);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
        return prod;
    }

    /// <summary>
    /// Atualiza um produto e salva as mudanças
    /// </summary>
    /// <param name="prod"></param>
    /// <returns></returns>
    public async Task<Produto> UpdateProductAsync(Produto prod)
    {
        try
        {
            var productExist = dbContext.Produto.FirstOrDefault(p => p.Id == prod.Id);
            if (productExist != null)
            {
                dbContext.Update(prod);
                await dbContext.SaveChangesAsync();
            }
        }
        catch (Exception)
        {
            throw;
        }
        return prod;
    }

    /// <summary>
    /// Remove um produto de DbContext e o salva
    /// </summary>
    /// <param name="produto"></param>
    /// <returns></returns>
    public async Task DeleteProductAsync(Produto produto)
    {
        try
        {
            dbContext.Produto.Remove(produto);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion
}