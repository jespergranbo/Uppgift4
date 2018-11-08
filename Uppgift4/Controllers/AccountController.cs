using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Uppgift4.Models;
using Uppgift4.ViewModels;
namespace Uppgift4.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (tvtablaEntities4 db = new tvtablaEntities4())
            {
                return View(db.user.ToList());
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(user account)
        {
            if (ModelState.IsValid)
            {
                using (tvtablaEntities4 db = new tvtablaEntities4())
                {
                    db.user.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.username + " du är nu registrerad!";
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(user account)
        {
            using (tvtablaEntities4 db = new tvtablaEntities4())
            {
                var usr = db.user.Where(u => u.username == account.username && u.password == account.password).FirstOrDefault();
                if (usr != null)
                {
                    Session["UserID"] = usr.user_id.ToString();
                    Session["Username"] = usr.username.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Användarnamnet eller lösenordet är fel");
                }
            }
            return View();
        }
        public ActionResult LoggedIn()
        {
            tvtablaEntities4 tvdb = new tvtablaEntities4();
            if (Session["UserId"] != null)
            {
                List<UserProgramVM> userChannel = new List<UserProgramVM>();
                var savedChannels = (from usr in tvdb.user_channel
                                     join chn in tvdb.channel on usr.channel_id equals chn.channel_id
                                     join prg in tvdb.program on usr.channel_id equals prg.channel_id
                                     select new { usr.user_channel_id, usr.user_id, chn.channel_name, usr.channel_id, prg.program_name, prg.start_time, prg.program_type, prg.description}).ToList();
                foreach (var item in savedChannels)
                {
                    if (item.user_id == Convert.ToInt32(Session["UserId"]))
                    {
                        UserProgramVM userItem = new UserProgramVM();
                        userItem.user_channel_id = item.user_channel_id;
                        userItem.user_id = item.user_id;
                        userItem.channel_name = item.channel_name;
                        userItem.channel_id = item.channel_id;
                        userItem.program_name = item.program_name;
                        userItem.program_type = item.program_type;
                        userItem.start_time = item.start_time;
                        userItem.description = item.description;
                        userChannel.Add(userItem);
                    }
                }
                return View(userChannel);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Delete(int? id)
        {
            tvtablaEntities4 db = new tvtablaEntities4();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_channel channel = db.user_channel.Find(id);
            if (channel == null)
            {
                return HttpNotFound();
            }
            return View(channel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tvtablaEntities4 db = new tvtablaEntities4();
            user_channel channel = db.user_channel.Find(id);
            db.user_channel.Remove(channel);
            db.SaveChanges();
            return RedirectToAction("LoggedIn");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_channel_id,user_id,channel_id")] user_channel channelUser)
        {
            tvtablaEntities4 db = new tvtablaEntities4();
            if (ModelState.IsValid)
            {
                db.user_channel.Add(channelUser);
                db.SaveChanges();
                return RedirectToAction("LoggedIn");
            }

            return View(channelUser);
        }
    }
}