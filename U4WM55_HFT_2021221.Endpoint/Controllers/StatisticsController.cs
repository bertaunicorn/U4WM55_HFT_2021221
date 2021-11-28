using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using U4WM55_HFT_2021221.Logic;
using U4WM55_HFT_2021221.Models;

namespace U4WM55_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        IStatisticsLogic sl;

        public StatisticsController(IStatisticsLogic sl)
        {
            this.sl = sl;
        }

        [HttpGet("allComps")]
        public IEnumerable<Competitions> GetC()
        {
            return sl.GetAllComps();
        }

        
        [HttpGet("comp/{id}")]
        public Competitions GetC(int id)
        {
            return sl.GetOneComp(id);
        }

        [HttpGet("allLooks")]
        public IEnumerable<Looks> GetL()
        {
            return sl.GetAllLooks();
        }


        [HttpGet("look/{id}")]
        public Looks GetL(int id)
        {
            return sl.GetOneLook(id);
        }

        [HttpGet("allMUAs")]
        public IEnumerable<MUAs> GetM()
        {
            return sl.GetAllMUAs();
        }


        [HttpGet("mua/{id}")]
        public MUAs GetM(int id)
        {
            return sl.GetOneMUA(id);
        }

        [HttpGet("allConns")]
        public IEnumerable<Connector> Get()
        {
            return sl.GetAllConns();
        }


        [HttpGet("conn/{id}")]
        public Connector Get(int id)
        {
            return sl.GetOneConn(id);
        }
    }
}
