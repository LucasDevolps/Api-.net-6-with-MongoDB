﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiMongoDB.Models;
using WebApiMongoDB.Services;

namespace WebApiMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoServices _produtoServices;

        public ProdutoController(ProdutoServices produtoServices)
        {
            _produtoServices = produtoServices;
        }

        [HttpGet]
        public async Task<List<Produto>> GetProdutos() =>
            await _produtoServices.GetAsync();

        [HttpPost]
        public async Task<Produto> PostProduto(Produto produto)
        {
            await _produtoServices.CreateAsync(produto);

            return produto;
        }
        [HttpPut]
        public async Task<Produto> PutProduto(string id,Produto produto)
        {
            await _produtoServices.UpdateAsync(id, produto);

            return produto;
        }
        [HttpDelete]
        public async void DeleteProduto(string id)
        {
            await _produtoServices.DeleteAsync(id);
        }
    }
}
