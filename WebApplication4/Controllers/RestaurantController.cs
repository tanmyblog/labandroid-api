using Model;
using Model.Models;
using System.Linq;
using System.Web.Http;
using WebApplication4.Infrastructure;
using WebApplication4.ViewModel;

namespace WebApplication4.Controllers
{
    public class RestaurantController : ApiController
    {
        private ApiDbContext _db;

        public RestaurantController()
        {
            this._db = new ApiDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var dsgv = this._db.Restaurants.Select(x => new RestaurantModel()
            {
                id = x.id,
                name = x.name,
                address = x.address,
                type = x.type
            });

            return Ok(dsgv);
        }


        [HttpGet]
        public IHttpActionResult GetById(string id)
        {
            IHttpActionResult httpActionResult;
            var gv = _db.Restaurants.FirstOrDefault(x => x.id == id);

            if (gv == null)
            {
                ErrorsModel errors = new ErrorsModel();
                errors.Add("Không tìm thấy nhà hàng này");

                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.NotFound, errors);
            }
            else
            {
                httpActionResult = Ok(new RestaurantModel(gv));
            }

            return httpActionResult;
        }


        [HttpPost]
        public IHttpActionResult Create(CreateRestaurant model)
        {
            IHttpActionResult httpActionResult;
            ErrorsModel errors = new ErrorsModel();

            if (string.IsNullOrEmpty(model.name))
            {
                errors.Add("tên nhà hàng là trường bắt buộc");
            }

            if (errors.Errors.Count == 0)
            {
                Restaurants t = new Restaurants();
                t.id = model.id;
                t.name = model.name;
                t.address = model.address;
                t.type = model.type;

                t = _db.Restaurants.Add(t);

                this._db.SaveChanges();

                RestaurantModel viewModel = new RestaurantModel(t);

                httpActionResult = Ok(viewModel);
            }
            else
            {
                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.BadRequest, errors);
            }

            return httpActionResult;
        }


        [HttpPut]
        public IHttpActionResult Update(UpdateRestaurant model, string id)
        {
            IHttpActionResult httpActionResult;
            ErrorsModel errors = new ErrorsModel();

            Restaurants gv = this._db.Restaurants.FirstOrDefault(x => x.id == id);

            if (gv == null)
            {
                errors.Add("Nhà hàng này không tồn tại hoặc rỗng");

                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.NotFound, errors);
            }
            else
            {
                gv.name = model.name ?? model.name;
                gv.address = model.address ?? model.address;
                gv.type = model.type ?? model.type;

                this._db.Entry(gv).State = System.Data.Entity.EntityState.Modified;

                this._db.SaveChanges();

                httpActionResult = Ok(new RestaurantModel(gv));
            }

            return httpActionResult;
        }

        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            IHttpActionResult httpActionResult;
            ErrorsModel errors = new ErrorsModel();

            Restaurants gv = this._db.Restaurants.FirstOrDefault(x => x.id == id);

            if (gv == null)
            {
                errors.Add("Nhà hàng này không tồn tại hoặc rỗng");

                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.NotFound, errors);
            }
            else
            {
                this._db.Entry(gv).State = System.Data.Entity.EntityState.Deleted;

                this._db.SaveChanges();

                httpActionResult = Ok(new RestaurantModel(gv));
            }

            return httpActionResult;
        }
    }
}