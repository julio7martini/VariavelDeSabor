using AplicacaoCantina.Models;
using AplicacaoCantina.Utils.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AplicacaoCantina.Controllers
{
    public class PedidoController : Controller
    {
        private readonly PedidoModel _pedidoModel;

        public PedidoController()
        {
            _pedidoModel = new PedidoModel();
        }

        // GET: Pedido
        public IActionResult Index()
        {
            var pedidos = _pedidoModel.GetAllPedidos();
            return View(pedidos);
        }

        // GET: Pedido/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pedido/Create
        [HttpPost]
        public IActionResult Create(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _pedidoModel.CreatePedido(pedido);
                return RedirectToAction("Index");
            }
            return View(pedido);
        }

        // GET: Pedido/Edit/5
        public IActionResult Edit(int id)
        {
            var pedido = _pedidoModel.GetPedidoById(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return View(pedido);
        }

        // POST: Pedido/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, Pedido pedido)
        {
            if (id != pedido.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _pedidoModel.UpdatePedido(pedido);
                return RedirectToAction("Index");
            }
            return View(pedido);
        }

        // GET: Pedido/Delete/5
        public IActionResult Delete(int id)
        {
            var pedido = _pedidoModel.GetPedidoById(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return View(pedido);
        }

        // POST: Pedido/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _pedidoModel.DeletePedido(id);
            return RedirectToAction("Index");
        }
    }
}
