using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCallingManegment.Models;

namespace TCallingManegment.Controllers
{
    public class UserMasterController : Controller
    {
        // Connection string
        string connectionString = "YourConnectionString"; // Replace with your actual connection string

        // GET: UserMaster
        public ActionResult Index()
        {
            DataTable dtblUser = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM UserMaster", sqlCon);
                sqlDa.Fill(dtblUser);
            }
            return View(dtblUser);
        }

        // GET: UserMaster/Create
        public ActionResult Create()
        {
            return View(new UserMaster());
        }

        // POST: UserMaster/Create
        [HttpPost]
        public ActionResult Create(UserMaster userMaster)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO UserMaster VALUES(@UserName, @MobileNo, @EmailID, @DateOfJoining, @RoleID, @ReportingRoleID, @LastLoginDate, @Photo, @UserID, @Password)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@UserName", userMaster.UserName);
                // Add other parameters...
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: UserMaster/Edit/5
        public ActionResult Edit(int id)
        {
            UserMaster userMaster = new UserMaster();
            DataTable dtblUser = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT * FROM UserMaster WHERE UserID = @UserID";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@UserID", id);
                sqlDa.Fill(dtblUser);
            }
            if (dtblUser.Rows.Count == 1)
            {
              //  userMaster.UserID = Convert.ToInt32(dtblUser.Rows[0][0].ToString());
                userMaster.UserName = dtblUser.Rows[0][1].ToString();
                // Set other properties...
                return View(userMaster);
            }
            else
                return RedirectToAction("Index");
        }

        // POST: UserMaster/Edit/5
        [HttpPost]
        public ActionResult Edit(UserMaster userMaster)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "UPDATE UserMaster SET UserName=@UserName WHERE UserID=@UserID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@UserID", userMaster.UserID);
                sqlCmd.Parameters.AddWithValue("@UserName", userMaster.UserName);
                // Add other parameters...
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: UserMaster/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM UserMaster WHERE UserID=@UserID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@UserID", id);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
    }
}