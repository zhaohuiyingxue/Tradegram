﻿using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Hitasp.Tradegram.Samples
{
    public class SampleWebTest : TradegramWebTestBase
    {
        [Fact(Skip = "This is disabled since not working")]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }

        [Fact(Skip = "This is disabled since not working")]
        public async Task Login_Page()
        {
            var response = await GetResponseAsStringAsync("/Account/Login/");
            response.ShouldNotBeNull();
        }
    }
}
