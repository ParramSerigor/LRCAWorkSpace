using LRCA.classes;
using LRCA.classes.DAL;
using LRCA.classes.Entity;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LRCA
{
    public partial class AppView_TP : System.Web.UI.Page
    {
        CryptoJS objcryptoJS = new CryptoJS();
        protected void Page_init(object sender, EventArgs e)
        {
            string EmpId = HttpContext.Current.Session["UserAuthId"] == null ? string.Empty : HttpContext.Current.Session["UserAuthId"].ToString();
            if (EmpId.Length == 0)
            {
                GlobalMethods.logout();
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strTPID = string.Empty;
                bool boolInstVarify = false;

                try
                {

                    strTPID = Request["cgi"].ToString() == null ? string.Empty : Request["cgi"].ToString();
                    if (GlobalMethods.ValueIsNull(strTPID).Length > 0)
                    {
                        strTPID = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(Request["cgi"].ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
                    }

                    #region Checking if this is AssignedToMe Action
                    bool IsAssignedToMe = false;
                    List<clsTP_Approval> lstContAppr = new List<clsTP_Approval>();
                    lstContAppr = TP_ApprovalDAL.SelectDynamicTP_Approval("TPId = " + strTPID + "", "MDETPApprId");
                    if (lstContAppr != null)
                    {
                        if (lstContAppr.Count > 0)
                        {
                            IsAssignedToMe = true;
                        }
                    }
                    #endregion

                    clsTrainingProvider objSPCont = new clsTrainingProvider();
                    objSPCont = TrainingProviderDAL.SelectTrainingProviderById(Convert.ToInt32(strTPID));
                    if (objSPCont != null)
                    {
                        #region Getting Contractor Info.
                        //clsSP_Contractor objSPC = new clsSP_Contractor();
                        //objSPC = SP_ContractorDAL.SelectSP_ContractorById(objSPCont.SPContractorID);
                        //if (objSPC != null)
                        //{
                        //    lblContractor.Text = objSPC.SPName;
                        //  //  lblCourseName.Text = "<b>" + objSPC.SPName + "</b>"; // for heading
                        //}
                        //else
                        //{
                        //    lblContractor.Text = "";
                        //   // lblCourseName.Text = "";
                        //}
                        #endregion

                        lblTPName.Text = objSPCont.TP_Name;
                        lblContractorApp.Text = objSPCont.TP_Name;
                        //lblTPPhone.Text = objSPCont.TP_Phone;
                        //lblTPMobile.Text = objSPCont.TP_Mobile;
                        lblTPWebsite.Text = objSPCont.TP_WebSite;

                        List<clsTP_Instructors> lstTPIns = new List<clsTP_Instructors>();
                        lstTPIns = TP_InstructorsDAL.SelectDynamicTP_Instructors("TPId = " + objSPCont.TPId + "", "TP_InstructorsId");
                        if (lstTPIns != null)
                        {
                            if (lstTPIns.Count > 0)
                            {
                                clsInstructor objInstructorIs = new clsInstructor();
                                objInstructorIs = InstructorDAL.SelectInstructorById(lstTPIns[0].TP_InstructorListId);
                                if (objInstructorIs != null)
                                {
                                    //lblApprInsName.Text = objInstructorIs.Instructor_FName + " " + objInstructorIs.Instructor_LName;
                                    //lblApprInsAccNum.Text = objInstructorIs.Instructor_AcctId;
                                    //lblApprInsExpire.Text = objInstructorIs.Instructor_AcctExpire.ToShortDateString();

                                    lblInstructorName.Text = objInstructorIs.Instructor_FName + " " + objInstructorIs.Instructor_LName;
                                    lblInsAccId.Text = objInstructorIs.NewRenewal_InspecTech_AcctNumber;
                                    lblAccdExpireDate.Text = objInstructorIs.NewRenewal_InspecTech_AcctExpiration;
                                }

                            }
                        }

                        List<clsTP_Location> lstLocation = new List<clsTP_Location>();
                        lstLocation = TP_LocationDAL.SelectDynamicTP_Location("TPId = " + objSPCont.TPId + "", "TPLocationId");
                        if (lstLocation != null)
                        {
                            if (lstLocation.Count > 0)
                            {
                                lblAddress_1.Text = lstLocation[0].TP_Address_Line_1;
                                lblAddress_2.Text = "";
                                lblCity.Text = lstLocation[0].TP_City;
                                lblCounty.Text = "";
                                lblState.Text = lstLocation[0].TP_State;
                                lblZipCode.Text = lstLocation[0].TP_ZipCode;
                                lblTPEmail.Text = "";
                            }
                        }

                        //if(objSPCont.IsActive == 1)
                        //{
                        //    #region Approve Training Provider should Add Courses.
                        //    pnlAppStatus.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'><a class='btn btn-primary2' href='TP_AddCourses.aspx?dash=active&cgi="+ objcryptoJS.AES_encrypt(HttpUtility.UrlEncode(objSPCont.TPId.ToString()), AppConstants.secretKey, AppConstants.initVec).ToString() + "'  >Schedule Courses</a>" + GlobalMethods.ContractorAppStatus(objSPCont.IsActive, "bar") + "</div>"));
                        //    #endregion
                        //}
                        //else
                        //{
                            pnlAppStatus.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'>" + GlobalMethods.ContractorAppStatus(objSPCont.IsActive.HasValue ? objSPCont.IsActive.Value : 0, "bar","") + "</div>"));
                       // }
                        
                    }



                }
                catch (Exception)
                {
                    ErrorHandler.ErrorPage();
                }

            }
        }
    }
}