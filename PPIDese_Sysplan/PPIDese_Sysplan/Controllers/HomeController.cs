using PPIDese_Sysplan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PPIDese_Sysplan.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Todos os Clientes
        public JsonResult GetTodosClientes()
        {
            using (clienteContexto contextObj = new clienteContexto())
            {
                try
                {
                    var listaClientes = contextObj.cliente.ToList();
                    return Json(listaClientes, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        //GET: Cliente por Id
        public JsonResult GetClientePorId(string id)
        {
            using (clienteContexto contextObj = new clienteContexto())
            {
                var clienteId = Convert.ToInt32(id);
                var getClientePorId = contextObj.cliente.Find(clienteId);
                return Json(getClientePorId, JsonRequestBehavior.AllowGet);
            }
        }

        public string AtualizarCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                using (clienteContexto contextObj = new clienteContexto())
                {
                    int clienteId = Convert.ToInt32(cliente.IDCliente);
                    Cliente _cliente = contextObj.cliente.Where(b => b.IDCliente == clienteId).FirstOrDefault();
                    _cliente.Nome = cliente.Nome;
                    _cliente.Data_Nascimento = cliente.Data_Nascimento;
                    _cliente.Renda = cliente.Renda;

                    contextObj.SaveChanges();
                    return "Registro de cliente atualizado com sucesso";
                }
            }
            else
            {
                return "Registro de cliente inválido";
            }
        }
        // Adiciona Cliente
        public string AdicionarCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                using (clienteContexto contextObj = new clienteContexto())
                {
                    try
                    {
                        contextObj.cliente.Add(cliente);
                        contextObj.SaveChanges();
                        return "Registro de novo Cliente adicionado com sucesso";
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            else
            {
                return "Registro de cliente inválido";
            }
        }
    }
}