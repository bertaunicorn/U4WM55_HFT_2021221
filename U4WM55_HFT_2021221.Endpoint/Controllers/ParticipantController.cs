using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using U4WM55_HFT_2021221.Logic;
using U4WM55_HFT_2021221.Models;

namespace U4WM55_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ParticipantController :ControllerBase
    {
        IParticipantLogic pl;

        public ParticipantController(IParticipantLogic pl)
        {
            this.pl = pl;
        }

        [HttpPost]
        public void PostM([FromBody] MUAs mua)
        {
            pl.CreateMUA(mua.Name, mua.Gender, mua.Country, mua.ExperienceLvl, mua.Phone, mua.Email, mua.Sponsor, mua.NumOfModels, mua.Points);
        }

        [HttpPost]
        public void PostC([FromBody] Connector conn)
        {
            pl.CreateConnection(conn.CompetitionId, conn.MUAsId);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            pl.DeleteConnection(id);
        }

        [HttpPut]
        public void PutNM([FromBody] MUAs mua, int newNum)
        {
            pl.ChangeNumOfModels(mua.Id, newNum);
        }

        [HttpPut]
        public void PutM([FromBody] MUAs mua, int newLvl)
        {
            pl.UpgradeMUA(mua.Id, newLvl);
        }

        [HttpGet]
        public IList<GendersResult> Genders()
        {
            return pl.Genders();
        }

        [HttpGet]
        public IList<SameCountryResult> SameCountry()
        {
            return pl.SameCountry();
        }

    }
}
