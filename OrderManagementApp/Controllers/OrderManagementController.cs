using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagementApp.Managers;
using OrderManagementApp.Models;

namespace OrderManagementApp.Controllers
{
    public class OrderManagementController : Controller
    {
        // GET: OrderManagementController
        public ActionResult Index()
        {
            OrderManagementApiClient orderManagementApiClient = new OrderManagementApiClient();
            return View(orderManagementApiClient.GetAllOrders());
        }

        // GET: OrderManagementController/Details/5
        public ActionResult Details(int id)
        {
            OrderManagementApiClient orderManagementApiClient = new OrderManagementApiClient();
            return View(orderManagementApiClient.GetOrderById(id));
        }

        // GET: OrderManagementController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderManagementController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderModel collection)
        {
            try
            {
                OrderManagementApiClient orderManagementApiClient = new OrderManagementApiClient();
                return RedirectToAction(nameof(Index), orderManagementApiClient.PostNewOrder(collection));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderManagementController/Edit/5
        public ActionResult Edit(int id)
        {
            OrderManagementApiClient orderManagementApiClient = new OrderManagementApiClient();
            OrderModel orderModel = orderManagementApiClient.GetOrderById(id);
            return View(orderModel);
        }

        // POST: OrderManagementController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrderModel collection)
        {
            try
            {
                OrderManagementApiClient orderManagementApiClient = new OrderManagementApiClient();
                return RedirectToAction(nameof(Index), orderManagementApiClient.UpdateOrder(id,collection));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderManagementController/Delete/5
        public ActionResult Delete(int id)
        {
            OrderManagementApiClient orderManagementApiClient = new OrderManagementApiClient();
            return View(orderManagementApiClient.GetOrderById(id));
        }

        // POST: OrderManagementController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                OrderManagementApiClient orderManagementApiClient=new OrderManagementApiClient();
                return RedirectToAction(nameof(Index), orderManagementApiClient.DeleteOrderById(id));
            }
            catch
            {
                return View();
            }
        }
    }
}
