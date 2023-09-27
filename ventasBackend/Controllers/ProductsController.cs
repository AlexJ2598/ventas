namespace ventasBackend.Controllers
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using ventas.Common.Models;
    using ventasBackend.Helpers;
    using ventasBackend.Models;
    public class ProductsController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Products
        public async Task<ActionResult> Index()
        {
            return View(await this.db.Products.OrderBy(p => p.Description).ToListAsync()); //OrderBy para ordenar alfabeticamente usando Linq
        }

        // GET: Products/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await this.db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductView view) //Siempre quitamos[Bind(Include = "ProductID,Description,Remarks,ImagePath,Price,IsAvailable,PublishOn")], porque para modificar el prodcutos va a seguir funcionando el metodo create.
        {
            if (ModelState.IsValid)
            {
                var pic = string.Empty;
                var folder = "~/Content/Products";

                if (view.ImageFile != null)
                {
                    pic = FileHelper.UploadPhoto(view.ImageFile, folder);
                    pic = $"{folder}/{pic}";
                }
                //Cargamos la imagen al sistema. Tenmosm que convertir la vista a producto.
                var product = this.ToProduct(view, pic);
                this.db.Products.Add(product);
                await this.db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(view);
        }

        private Product ToProduct(ProductView view, string pic)
        {
            return new Product
            {
                Description = view.Description,
                ImagePath = pic,
                IsAvailable = view.IsAvailable,
                Price = view.Price,
                ProductID = view.ProductID,
                PublishOn = view.PublishOn,
                Remarks = view.Remarks,
            };
        }

        // GET: Products/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Lo hacemmos no tipado, osea dinamico, para ello Product product = await this.db.Products.FindAsync(id); -> var product = await this.db.Products.FindAsync(id);
            var product = await this.db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProductID,Description,Remarks,ImagePath,Price,IsAvailable,PublishOn")] Product product)
        {
            if (ModelState.IsValid)
            {
                this.db.Entry(product).State = EntityState.Modified;
                await this.db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await this.db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Product product = await this.db.Products.FindAsync(id);
            this.db.Products.Remove(product);
            await this.db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
