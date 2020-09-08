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
    public partial class AppView_Instructor : System.Web.UI.Page
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
                
                try
                {

                    strTPID = Request["cgi"].ToString() == null ? string.Empty : Request["cgi"].ToString();
                    if (GlobalMethods.ValueIsNull(strTPID).Length > 0)
                    {
                        strTPID = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(Request["cgi"].ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
                    }

                    clsInstructor objSPCont = new clsInstructor();
                    objSPCont = InstructorDAL.SelectInstructorById(Convert.ToInt32(strTPID));
                    if (objSPCont != null)
                    {
                        List<clsTP_Instructors> lstTPIns = new List<clsTP_Instructors>();
                        lstTPIns = TP_InstructorsDAL.SelectDynamicTP_Instructors("InstructorId = "+ strTPID + " and CreatedBy = '" + HttpContext.Current.Session["UserAuthId"].ToString() + "'", "TP_InstructorsId");
                        if(lstTPIns != null)
                        {
                            if(lstTPIns.Count > 0)
                            {
                                clsTrainingProvider objIns = new clsTrainingProvider();
                                objIns = TrainingProviderDAL.SelectTrainingProviderById(lstTPIns[0].TPId);
                                if(objIns != null)
                                {
                                    lblTP.Text = objIns.TP_Name;
                                    lblInstructorAss.Text = " associated with " + objIns.TP_Name;
                                }
                                else
                                {
                                    lblTP.Text = "-";
                                    lblInstructorAss.Text = "-";
                                }
                                
                            }
                            else
                            {
                                lblTP.Text = "NO TRAINING PROVIDER";
                                lblInstructorAss.Text = " NOT ASSOCIATED WITH TRAINING PROVIDER";
                            }
                        }
                        else
                        {
                            lblTP.Text = "NO TRAINING PROVIDER";
                            lblInstructorAss.Text = " NOT ASSOCIATED WITH TRAINING PROVIDER";
                        }

                        #region Getting Category Title
                        clsCategory objCat = new clsCategory();
                        objCat = CategoryDAL.SelectCategoryById(objSPCont.ACRDCatID);
                        if(objCat != null)
                        {
                            lblCategory.Text = objCat.CatTitle;
                        }
                        else
                        {
                            lblCategory.Text = "-";
                        }
                        #endregion
                        
                        lblFName.Text = objSPCont.Instructor_FName;
                        lblLName.Text = objSPCont.Instructor_LName;
                        lblInstructorApp.Text = objSPCont.Instructor_FName + " " + objSPCont.Instructor_LName;
                        lblTPEmail.Text = objSPCont.Instructor_Email;
                        lblTPPhone.Text = objSPCont.Instructor_Phone;
                        lblTPMobile.Text = "";
                        lblInsAccId.Text = objSPCont.AccreditationID;
                        lblAccdExpireDate.Text = Convert.ToDateTime(objSPCont.AccreditationExpirationDate).ToShortDateString();


                        if(objSPCont.IsActive == 1)
                        {
                            pnlAppStatus.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'><a href='Inst_ScheduleClass.aspx?dash=active&cgi="+ Request["cgi"] +"' class='btn btn-primary2'>Schedule A Class</a>" + GlobalMethods.ContractorAppStatus(objSPCont.IsActive.HasValue ? objSPCont.IsActive.Value : -1, "bar","") + "</div>"));
                        }
                        else
                        {
                            pnlAppStatus.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'>" + GlobalMethods.ContractorAppStatus(objSPCont.IsActive.HasValue ? objSPCont.IsActive.Value : -1, "bar","") + "</div>"));
                        }
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