﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using HTK.Bank.Api.Models;
using HTK.Bank.Core.Models;
using HTK.Bank.Core.Services;

namespace HTK.Bank.Api.Controllers
{
    public class AIController : ApiController
    {
        private MovementService _movementService = new MovementService(Settings.DATABASE_FILE_PATH);
        private DistributionService _distribiutionService = new DistributionService();

        [HttpPost]
        public TestResult Test(List<Movement> movements)
        {
            var headers = Request.Headers;
            var userName = headers.GetValues("UserName").First();
          
            var batches = _movementService.Get();
            //if(batches.Count(x=>x.UserName== userName) <5)
            //{
            //    _movementService.Save(userName, movements);
            //    return new TestResult() { UserName = userName, Verified = true, Score = 0 };
            //}


            var testResult = new TestResult();
            testResult.UserName = userName;

            var svm = new SVMService();
            if(svm.TestFactor(Factor.AngleOfCurvature, batches, movements, userName))
            {
                testResult.Score += 33;
                testResult.Description += "AngleOfCurvature; ";
            }
            if (svm.TestFactor(Factor.CurvatureDistance, batches, movements, userName))
            {
                testResult.Score += 33;
                testResult.Description += "CurvatureDistance; ";
            }
            if (svm.TestFactor(Factor.Direction, batches, movements, userName))
            {
                testResult.Score += 33;
                testResult.Description += "Direction; ";
            }

            if (testResult.Score > 60)
            {
                testResult.Verified = true;
                _movementService.Save(userName, movements);

            }

            return testResult;
        }

      

        
        public double TestDistance()
        {
            var obs1 = _movementService.GetMovements(null, null, Factor.AngleOfCurvature);
            var obs2 = _movementService.GetMovements(null, "40c38b8c-d6c6-4c13-a5a8-15caa604c94f", Factor.AngleOfCurvature);
            var distance = _distribiutionService.Distance(obs1, obs2, 360);

            return 0;
        }



    }
}
