using BAS.AuditJournal.Application.Interfaces;
using BAS.AuditJournal.Entities;
using BAS.AuditJournal.Logging;
using BAS.AuditJournal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace BAS.AuditJournal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatCatalogController : BaseApiController
    {
        #region Private Members

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor  

        /// <summary>
        /// Initialize ContactController by injecting an object type of IUnitOfWork
        /// </summary>
        public SeatCatalogController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        #endregion

        #region Public Methods

        [HttpGet]
        [Route("journal")]
        public async Task<ApiResponse<List<SeatCatalog>>> GetSeatCatalog()
        {
            var apiResponse = new ApiResponse<List<SeatCatalog>>();

            try
            {
                var data = await _unitOfWork.SeatCatalogs.GetAllAsync();
                apiResponse.Success = true;
                apiResponse.Result = data.ToList();
            }
            catch (SqlException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Logger.Instance.Error("SQL Exception:", ex);
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Logger.Instance.Error("Exception:", ex);
            }

            return apiResponse;
        }
        #endregion
    }
}
