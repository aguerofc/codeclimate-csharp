using BAS.AuditJournal.API.Controllers;
using BAS.AuditJournal.Application.Interfaces;
using BAS.AuditJournal.Entities;
using BAS.AuditJournal.Infrastructure.Repository;
using BAS.AuditJournal.Models;
using BAS.AuditJournal.Test.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;

namespace BAS.AuditJournal.Test.IntegrationTests
{
    [TestClass]
    public class AuditJournalControllerShould
    {
        #region Private Members

        protected readonly IConfigurationRoot _configuration;
        private readonly AuditJournalController _controllerObj;
        private readonly AuditJournalController _moqControllerObj;
        private readonly Mock<IUnitOfWork> _moqRepo;

        #endregion

        #region Constructor

        /// <summary>
        /// Test constructor
        /// </summary>
        public AuditJournalControllerShould()
        {
            _configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                      .AddJsonFile("appsettings.json")
                                                      .Build();

            var repository = new AccountJournalRepository(_configuration);
            var unitofWork = new UnitOfWork(repository,null);

            _controllerObj = new AuditJournalController(unitofWork);

            _moqRepo = new Mock<IUnitOfWork>();
            _moqControllerObj = new AuditJournalController(_moqRepo.Object);
        }

        #endregion

        #region Test Methods

        /// <summary>
        /// Get account journal success test
        /// </summary>
        /// <returns></returns>
        [Ignore]
        [TestMethod]
        public async Task GetAccountJournal()
        {           

            //Get All Journal by date and type of seat
            var data = await GetAccountJournal(TestConstants.AccountJournalParamTest.SeatId,
                TestConstants.AccountJournalParamTest.FromDate, 
                TestConstants.AccountJournalParamTest.ToDate);           
        }

        /// <summary>
        /// Get account journal exception test
        /// </summary>
        /// <returns>Exception result</returns>
        [TestMethod]
        public async Task GetAccountJournal_Throw_Exception()
        {
            //SQL Exception Test.
            _moqRepo.Setup(x => x.AuditJournals.GetAccountJournal(It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).Throws(TestConstants.GetSqlException());

            var result = await _moqControllerObj.GetAccountJournal(1, DateTime.Now, DateTime.Now);

            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Result);

            //General Exception Test.
            _moqRepo.Setup(x => x.AuditJournals.GetAccountJournal(It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).Throws(TestConstants.GetGeneralException());

            result = await _moqControllerObj.GetAccountJournal(1, DateTime.Now, DateTime.Now);

            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Result);
        }

        #endregion

        #region Private Methods        
        /// <summary>
        /// Call Account journal test
        /// </summary>
        /// <param name="seatId">Seat id</param>
        /// <param name="fromDate">Init date</param>
        /// <param name="toDate">Finish date</param>
        /// <returns>Success data object</returns>
        private async Task<ApiResponse<List<AccountJournal>>> GetAccountJournal(int seatId, DateTime fromDate, DateTime toDate)
        {
            var result = await _controllerObj.GetAccountJournal(seatId, fromDate, toDate);

            Assert.Inconclusive();
            //Assert.IsNotNull(result);
            //Assert.IsTrue(result.Success);
            //Assert.IsTrue(result.Result.Count > 0);

            return result;
        }

       

        #endregion
    }
}
