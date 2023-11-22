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
    public class AuditJournalController : BaseApiController
    {
        #region Private Members

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor  

        /// <summary>
        /// Initialize ContactController by injecting an object type of IUnitOfWork
        /// </summary>
        public AuditJournalController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        #endregion

        #region Public Methods
        
        /// <summary>
        /// Get account audit journal information
        /// </summary>
        /// <param name="seatId">Seat code</param>
        /// <param name="fromDate">Init date</param>
        /// <param name="toDate">End date</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseCache(CacheProfileName = "Cache2Mins")]
        [Route("journal/{seatId}/{fromDate}/{toDate}")]
        public async Task<ApiResponse<List<AccountJournal>>> GetAccountJournal(int seatId, DateTime fromDate, DateTime toDate)
        {

            var apiResponse = new ApiResponse<List<AccountJournal>>();

            try
            {
                var data = await _unitOfWork.AuditJournals.GetAccountJournal(seatId, fromDate, toDate);
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
