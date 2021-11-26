using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using U4WM55_HFT_2021221.Logic;
using U4WM55_HFT_2021221.Models;

namespace U4WM55_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JuryController : ControllerBase
    {
        IJuryLogic jl;

        public JuryController(IJuryLogic jl)
        {
            this.jl = jl;
        }

        [HttpPost]
        public void PostC([FromBody] Competitions competition)
        {
            jl.CreateComp(competition.Place, competition.Difficulty, competition.CompDate, competition.HowManyJudges, competition.HeadOfJury);
        }

        [HttpPost]
        public void PostL([FromBody] Looks look)
        {
            jl.CreateLook(look.Theme, look.Brand, look.Budget, look.TimeFrame, look.Difficulty, (int)look.CompId);
        }

        [HttpDelete("{id}")]
        public void DeleteMUA(int id)
        {
            jl.DeleteMUA(id);
        }

        [HttpDelete("{id}")]
        public void DeleteComp(int id)
        {
            jl.DeleteComp(id);
        }

        [HttpDelete("{id}")]
        public void DeleteLook(int id)
        {
            jl.DeleteLook(id);
        }

        [HttpPut]
        public void PutLD([FromBody] Looks look, int newDiff)
        {
            jl.ChangeLookDifficulty(look.Id, newDiff);
        }

        [HttpPut]
        public void PutT([FromBody] Looks look, string newTheme)
        {
            jl.ChangeTheme(look.Id, newTheme);
        }

        [HttpPut]
        public void PutCD([FromBody] Competitions comp, int newDiff)
        {
            jl.ChangeCompDifficulty(comp.Id, newDiff);
        }

        [HttpGet]
        public IList<SponsorBrandsResult> SponsorBrands()
        {
            return jl.SponsorBrands();
        }

        [HttpGet]
        public IList<HowManyLooksResult> HowManyLooks()
        {
            return jl.HowManyLooks();
        }

    }
}
