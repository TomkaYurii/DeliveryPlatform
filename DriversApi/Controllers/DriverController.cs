using Drivers.BLL.DTOs;
using Drivers.DAL.Contracts;
using Drivers.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Drivers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly ILogger<DriverController> _logger;
        private IUnitOfWork _ADOuow;
        
        public DriverController(ILogger<DriverController> logger,
            IUnitOfWork ado_unitofwork)
        {
            _logger = logger;
            _ADOuow = ado_unitofwork;
        }



        //GET: api/driver
        [HttpGet]
        public async Task<ActionResult< IEnumerable<Driver>>> GetAllDriversAsync()
        {
            try
            {
                var results = await _ADOuow._driverRepository.GetAllAsync();

                _logger.LogInformation($"Отримали всі івенти з БД");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Запит не відпрацював, щось пішло не так! - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        //GET: api/driver/Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Driver>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _ADOuow._driverRepository.GetAsync(id);
                if (result == null)
                {
                    _logger.LogInformation($"Івент із Id: {id}, не був знайдейний у базі даних");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Отримали івент з бази даних!");
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllDriversAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        //POST: api/driver
        [HttpPost]
        public async Task<ActionResult> PostDriverAsync([FromBody] AddAllInfoAboutDriverDTO model)
        {

            try
            {
                if (model == null)
                {
                    _logger.LogInformation($"Ми отримали пустий json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation($"Ми отримали некоректний json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є некоректним");
                }

                var obj_DriverLicense = new DriverLicense();
                //obj_DriverLicense.LicenseId = model.LicenseId;
                //obj_DriverLicense.ExpiryDate = model.ExpiryDate;
                obj_DriverLicense.Type = model.Type;

                var created_id_license = await _ADOuow._driverLicenseRepository.AddAsync(obj_DriverLicense);

                var obj_car = new Car();
                obj_car.PlateNumber = model.PlateNumber;
                obj_car.Max_weight = model.Max_weight;
                obj_car.Model = model.Model;

                var created_id_car = await _ADOuow._carRepository.AddAsync(obj_car);

                var obj_driver = new Driver();
                obj_driver.FirstName = model.FirstName;
                obj_driver.LastName = model.LastName;
                obj_driver.Experience = model.Experience;
                obj_driver.Email = model.Email;
                obj_driver.Phone = model.Phone;
                obj_driver.DriverLicense_Id = created_id_license;
                obj_driver.Car_Id = created_id_car;

                var created_id = await _ADOuow._driverRepository.AddAsync(obj_driver);

                _ADOuow.Commit();
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі PostDriverAsync - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        //PUT: api/driver/id
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDriverAsync(int id, [FromBody] Driver evnt)
        {
            try
            {
                if (evnt == null)
                {
                    _logger.LogInformation($"Ми отримали пустий json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation($"Ми отримали некоректний json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є некоректним");
                }

                var event_entity = await _ADOuow._driverRepository.GetAsync(id);
                if (event_entity == null)
                {
                    _logger.LogInformation($"Івент із Id: {id}, не був знайдейний у базі даних");
                    return NotFound();
                }

                await _ADOuow._driverRepository.ReplaceAsync(evnt);
                _ADOuow.Commit();
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі PostDriverAsync - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        //GET: api/driver/Id
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteByIdAsync(int id)
        {
            try
            {
                var event_entity = await _ADOuow._driverRepository.GetAsync(id);
                if (event_entity == null)
                {
                    _logger.LogInformation($"Івент із Id: {id}, не був знайдейний у базі даних");
                    return NotFound();
                }

                await _ADOuow._driverRepository.DeleteAsync(id);
                _ADOuow.Commit();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllDriversAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }


        ////GET: api/driver/name
        //[HttpGet("{name:alpha}")]
        //public async Task<ActionResult<Driver>> GetDriversByName(string name)
        //{
        //    try
        //    {
        //        var result = await _ADOuow.EFDriverRepository.GetDriversByName(name);
        //        if (result == null)
        //        {
        //            _logger.LogInformation($"Івент із іменем: {name}, не був знайдейний у базі даних");
        //            return NotFound();
        //        }
        //        else
        //        {
        //            _logger.LogInformation($"Отримали івент з бази даних!");
        //            return Ok(result);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Запис до БД сфейлився! Щось пішло не так  - {ex.Message}");
        //        return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
        //    }
        //}
    }
}
