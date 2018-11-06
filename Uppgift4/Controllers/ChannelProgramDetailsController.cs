using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Uppgift4.Models;
using Uppgift4.ViewModels;

namespace Uppgift4.Controllers
{
    public class ChannelProgramDetailsController : Controller
    {
        // GET: ChannelProgramDetails
        public ActionResult Index()
        {
            tvtablaEntities2 tvdb = new tvtablaEntities2();
            List<ProgramVM> programsVMlist = new List<ProgramVM>();
            var programList = (from chn in tvdb.channel
                               join pgn in tvdb.program on chn.channel_id equals pgn.channel_id
                               select new {chn.channel_id, chn.channel_name, pgn.program_name, pgn.start_time, pgn.end_time, pgn.program_id, pgn.program_type}).ToList();
            foreach (var item in programList)
            {
                ProgramVM vmItem = new ProgramVM();
                vmItem.channel_name = item.channel_name;
                vmItem.program_name = item.program_name;
                vmItem.channel_id = item.channel_id;
                vmItem.end_time = item.end_time;
                vmItem.start_time = item.start_time;
                vmItem.program_id = item.program_id;
                vmItem.program_type = item.program_type;
                programsVMlist.Add(vmItem);
            }

            return View(programsVMlist);
        }
    }
}