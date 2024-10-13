using Cadastro_De_Clientes_Estacionamento.Models;
using Locadora_api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Cadastro_De_Clientes_Estacionamento.Controllers
{
    public class ClientesController : Controller
    {
        private readonly DataContext _db;

        public ClientesController(DataContext db)
        {
            _db = db;
        }

        // GET: ClientesController
        public IActionResult Index()
        {
            IEnumerable<Cliente> clientes = _db.Clientes; 

            return View(clientes);
        }

        public IActionResult Cadastrar()
        {
            return PartialView("_Cadastrar");
        }

        public IActionResult Detalhes(Guid? id)
        {
            ClienteDTO clienteDto = new ClienteDTO();
                 
            if (id == null)
            {
                return null;
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //busca os dados do cliente
            clienteDto.cliente = _db.Clientes.FirstOrDefault(x => x.Id == id);

            //busca os pagamentos do cliente
            clienteDto.pagamentos = _db.Pagamentos.Where(x => x.ClienteId == id);

            if (clienteDto.cliente == null)
            {
                return null;
                //return HttpNotFound();
            }
            
            return PartialView("_Detalhes", clienteDto);
        }


        [HttpPost]
        public IActionResult Cadastrar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _db.Clientes.Add(cliente);

                _db.SaveChanges();
                
                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";

                return RedirectToAction("Index");
            }
            else
            {
                TempData["MensagemErro"] = "Cadastro não realizado!";
            }

            return PartialView("_Cadastrar");
        }

        [HttpPost]
        public IActionResult PagarBoleto(Pagamento pagamento)
        {
            if (ModelState.IsValid)
            {
                pagamento.Id = Guid.NewGuid();
                pagamento.dataPagamento = DateTime.UtcNow;

                _db.Pagamentos.Add(pagamento);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Pagamento realizado com sucesso!";

                return RedirectToAction("Index");
            }
            else
            {
                TempData["MensagemErro"] = "Cadastro não realizado!";
            }

            return PartialView("_Cadastrar");
        }





        // GET: ClientesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
