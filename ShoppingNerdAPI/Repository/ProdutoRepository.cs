using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoppingNerdAPI.Data.ValueObjects;
using ShoppingNerdAPI.Model.Base;
using ShoppingNerdAPI.Model.Context;
using ShoppingNerdAPI.Repository.Interfaces;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace ShoppingNerdAPI.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly MysqlContext _mysqlContext;
        private IMapper _mapper;

        public ProdutoRepository(MysqlContext pMysqlContext,IMapper pMapper) 
        { 
            _mysqlContext = pMysqlContext;
            _mapper = pMapper;
        }
        public async Task<ProdutoVO> BuscaPorId(long pId)
        {
            Produto oProduto = await _mysqlContext.Produtos.Where(x=>x.Id == pId).FirstOrDefaultAsync() ?? new Produto();
            return _mapper.Map<ProdutoVO>(oProduto);
        }

        public async Task<ProdutoVO> BuscaPorNome(string pNome)
        {
            Produto oProduto = await _mysqlContext.Produtos.Where(x => x.Nome == pNome).FirstOrDefaultAsync() ?? new Produto();
            return _mapper.Map<ProdutoVO>(oProduto);
        }

        public async Task<IEnumerable<ProdutoVO>> BuscaTodos()
        {
            List<Produto> lProdutos = await _mysqlContext.Produtos.ToListAsync();
            return _mapper.Map<List<ProdutoVO>>(lProdutos);
        }

        public async Task<ProdutoVO> Criar(ProdutoVO pProduto)
        {
            Produto oProduto = _mapper.Map<Produto>(pProduto);
            _mysqlContext.Produtos.Add(oProduto);
            await _mysqlContext.SaveChangesAsync();
            return _mapper.Map<ProdutoVO>(oProduto);
        }

        public async Task<ProdutoVO> Editar(ProdutoVO pProduto)
        {
            Produto oProduto = _mapper.Map<Produto>(pProduto);
            _mysqlContext.Produtos.Update(oProduto);
            await _mysqlContext.SaveChangesAsync();
            return _mapper.Map<ProdutoVO>(oProduto);
        }

        public async Task<bool> Excluir(long pId)
        {
            try
            {
                Produto oProduto = await _mysqlContext.Produtos.Where(p => p.Id == pId).FirstOrDefaultAsync() ?? new Produto();
                if (oProduto.Id <= 0)
                {
                    return false;
                }
                _mysqlContext.Produtos.Remove(oProduto);
                await _mysqlContext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
