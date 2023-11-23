using BAS.AuditJournal.API.Controllers;
using BAS.AuditJournal.Application.Interfaces;
using BAS.AuditJournal.Entities;
using BAS.AuditJournal.Infrastructure.Repository;
using BAS.AuditJournal.Models;
using BAS.AuditJournal.Test.Helper;
using Microsoft.Extensions.Configuration;
using Moq;

namespace BAS.AuditJournal.Test.IntegrationTests
{
    [TestClass]
    public class SeatCatalogControllerShould
    {
        #region Private Members

        protected readonly IConfigurationRoot _configuration;
        private readonly SeatCatalogController _controllerObj;
        private readonly SeatCatalogController _moqControllerObj;
        private readonly Mock<IUnitOfWork> _moqRepo;

        #endregion

        #region Constructor

        /// <summary>
        /// Test constructor
        /// </summary>
        public SeatCatalogControllerShould()
        {
            _configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                      .AddJsonFile("appsettings.json")
                                                      .Build();

            var repository = new SeatCatalogRespository(_configuration);
            var unitofWork = new UnitOfWork(null,repository);

            _controllerObj = new SeatCatalogController(unitofWork);

            _moqRepo = new Mock<IUnitOfWork>();
            _moqControllerObj = new SeatCatalogController(_moqRepo.Object);
        }

        #endregion

        #region Test Methods

        /// <summary>
        /// Get seat catalog  success test
        /// </summary>
        /// <returns></returns>
         [Ignore]
        [TestMethod]
        public async Task GetSeatCatalogs()
        {

            //Get All seats enabled
            var data = await GetSeatCatalog();
        }

        /// <summary>
        /// Get account journal exception test
        /// </summary>
        /// <returns>Exception result</returns>
        [TestMethod]
        public async Task GetSeatCatalog_Throw_Exception()
        {
            //SQL Exception Test.
           _moqRepo.Setup(x => x.SeatCatalogs.GetAllAsync()).Throws(TestConstants.GetSqlException());

            var result = await _moqControllerObj.GetSeatCatalog();

            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Result);

            //General Exception Test.
            _moqRepo.Setup(x => x.SeatCatalogs.GetAllAsync()).Throws(TestConstants.GetGeneralException());

            result = await _moqControllerObj.GetSeatCatalog();

            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Result);
        }

        #endregion

        #region Private Methods        
        /// <summary>
        /// Get seat catalog list
        /// </summary>
        /// <returns>List catalog</returns>
        private async Task<ApiResponse<List<SeatCatalog>>> GetSeatCatalog()
        {
            var result = await _controllerObj.GetSeatCatalog();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Result.Count > 0);

            return result;
        }



        #endregion
    }
}
