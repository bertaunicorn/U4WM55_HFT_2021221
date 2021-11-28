﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("competition")]
        public void PostC([FromBody] Competitions competition)
        {
            jl.CreateComp(competition.Place, competition.Difficulty, competition.CompDate, competition.HowManyJudges, competition.HeadOfJury);
        }

        [HttpPost("look")]
        public void PostL([FromBody] Looks look)
        {
            jl.CreateLook(look.Theme, look.Brand, look.Budget, look.TimeFrame, look.Difficulty, (int)look.CompId);
        }

        [HttpDelete("delete/{id}")]
        public void DeleteMUA(int id)
        {
            jl.DeleteMUA(id);
        }

        [HttpDelete("delete/{id}")]
        public void DeleteComp(int id)
        {
            jl.DeleteComp(id);
        }

        [HttpDelete("delete/{id}")]
        public void DeleteLook(int id)
        {
            jl.DeleteLook(id);
        }

        [HttpPut("lookDiff")]
        public void PutLD([FromBody] Looks look, int newDiff)
        {
            jl.ChangeLookDifficulty(look.Id, newDiff);
        }

        [HttpPut("theme")]
        public void PutT([FromBody] Looks look, string newTheme)
        {
            jl.ChangeTheme(look.Id, newTheme);
        }

        [HttpPut("compDiff")]
        public void PutCD([FromBody] Competitions comp, int newDiff)
        {
            jl.ChangeCompDifficulty(comp.Id, newDiff);
        }

        [HttpGet("sponsors")]
        public IList<SponsorBrandsResult> SponsorBrands()
        {
            return jl.SponsorBrands();
        }

        [HttpGet("howMany")]
        public IList<HowManyLooksResult> HowManyLooks()
        {
            return jl.HowManyLooks();
        }

    }
}