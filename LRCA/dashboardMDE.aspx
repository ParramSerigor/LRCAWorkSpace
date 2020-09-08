<%@ Page Title="" Language="C#" MasterPageFile="~/MDE.Master" AutoEventWireup="true" CodeBehind="dashboardMDE.aspx.cs" Inherits="LRCA.dashboardMDE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPMain" runat="server">
     <div class="row">
            <div class="col-lg-12">
                      
    <div class="row">
       
        <div class="col-lg-3">
                <div class="hpanel stats">
                    <div class="panel-body h-200">
                        <div class="stats-title pull-left">
                        <div class="stats-icon pull-left">
                            <i class="pe-7s-folder fa-3x"></i>
                        </div>
                             <div class="clearfix"></div>
                            <h4 class="text-danger" style="font-size:17px">
                           Contractor Accreditation
                                </h4>
                        </div>
                       
                        <div class="clearfix"></div>
                        <div class="flot-chart">
                           
                            <h1 class="text-danger">
                                <b><%=TotalContractorPendingApps %></b>
                                </h1>                           
                                <small>New Contractor Accreditation applications on the system.</small> 
                        </div>
                    </div>
                    <div class="panel-footer">
                        <a href="MDE_ContrApps.aspx?contapps=active" class="btn btn-xs btn-info" title="Click to view Contractor Accreditations applications">View Applications</a>
                    </div>
                </div>
            </div>    
        <div class="col-lg-3">
                <div class="hpanel stats">
                    <div class="panel-body h-200">
                        <div class="stats-title pull-left">
                        <div class="stats-icon pull-left">
                            <i class="pe-7s-folder fa-3x"></i>
                        </div>
                             <div class="clearfix"></div>
                            <h4 class="text-danger" style="font-size:17px">
                           Inspector & Risk Assessor
                                </h4>
                        </div>
                       
                        <div class="clearfix"></div>
                        <div class="flot-chart">
                           
                            <h1 class="text-danger">
                                <b><%=TotalRisk_Apps %></b>
                                </h1>                           
                                <small>New Inspector & Risk Assessor Applications.</small> 
                        </div>
                    </div>
                    <div class="panel-footer">
                        <a href="MDE_RiskApps.aspx?RiskApps=active" class="btn btn-xs btn-info" title="Click to view Applocations">View Applications</a>
                    </div>
                </div>
            </div>  
        <div class="col-lg-3">
                <div class="hpanel stats">
                    <div class="panel-body h-200">
                        <div class="stats-title pull-left">
                        <div class="stats-icon pull-left">
                            <i class="pe-7s-folder fa-3x"></i>
                        </div>
                             <div class="clearfix"></div>
                            <h4 class="text-danger" style="font-size:17px">
                           Supervisor
                                </h4>
                        </div>
                       
                        <div class="clearfix"></div>
                        <div class="flot-chart">
                           
                            <h1 class="text-danger">
                                <b><%=TotalSuper_Apps %></b>
                                </h1>                           
                                <small>New Supervisor Applications.</small> 
                        </div>
                    </div>
                    <div class="panel-footer">
                        <a href="MDE_SuperApps.aspx?Superapps=active" class="btn btn-xs btn-info" title="Click to view Applocations">View Applications</a>
                    </div>
                </div>
            </div>               
        <div class="col-lg-3">
                <div class="hpanel stats">
                    <div class="panel-body h-200">
                        <div class="stats-title pull-left">
                        <div class="stats-icon pull-left">
                            <i class="pe-7s-folder fa-3x"></i>
                        </div>
                             <div class="clearfix"></div>
                            <h4 class="text-danger" style="font-size:17px">
                           Training Provider
                                </h4>
                        </div>
                       
                        <div class="clearfix"></div>
                        <div class="flot-chart">
                           
                            <h1 class="text-danger">
                                <b><%=TotalTP_Apps %></b>
                                </h1>                           
                                <small>New Training Provider Applications.</small> 
                        </div>
                    </div>
                    <div class="panel-footer">
                        <a href="MDE_TPApps.aspx?tpapps=active" class="btn btn-xs btn-info" title="Click to view Applocations">View Applications</a>
                    </div>
                </div>
            </div>               
          
    </div>
           <div class="row">
               <div class="col-lg-3">
                <div class="hpanel stats">
                    <div class="panel-body h-200">
                        <div class="stats-title pull-left">
                        <div class="stats-icon pull-left">
                            <i class="pe-7s-id fa-3x"></i>
                        </div>
                             <div class="clearfix"></div>
                            <h4 class="text-danger" style="font-size:17px">
                          Instructors
                                </h4>
                        </div>
                       
                        <div class="clearfix"></div>
                        <div class="flot-chart">
                           
                            <h1 class="text-danger">
                                <b><%=TotalInstructor_Apps %></b>
                                </h1>                           
                                <small>New Instructor applications.</small> 
                        </div>
                    </div>
                    <div class="panel-footer">
                        <a href="MDE_InstructorApps.aspx?Instructapps=active" class="btn btn-xs btn-info" title="Click to view Applications">View Applications</a>
                    </div>
                </div>
            </div>
       <div class="col-lg-3">
                <div class="hpanel stats">
                    <div class="panel-body h-200">
                        <div class="stats-title pull-left">
                        <div class="stats-icon pull-left">
                            <i class="pe-7s-notebook fa-3x"></i>
                        </div>
                             <div class="clearfix"></div>
                            <h4 class="text-danger" style="font-size:17px">
                           TRAINING COURSES
                                </h4>
                        </div>
                       
                        <div class="clearfix"></div>
                        <div class="flot-chart">
                           
                            <h1 class="text-danger">
                                <b><%=TotalTrainingCourses %></b>
                                </h1>                           
                                <small>New applications for Training Courses.</small> 
                        </div>
                    </div>
                    <div class="panel-footer">
                        <a href="MDE_TCourseApps.aspx?TCourseApps=active" class="btn btn-xs btn-info" title="Click to view Courses">View Courses</a>
                    </div>
                </div>
            </div>        
               <div class="col-lg-3">
                <div class="hpanel stats">
                    <div class="panel-body h-200">
                        <div class="stats-title pull-left">
                        <div class="stats-icon pull-left">
                            <i class="pe-7s-notebook fa-3x"></i>
                        </div>
                             <div class="clearfix"></div>
                            <h4 class="text-danger" style="font-size:17px">
                           Accreditations
                                </h4>
                        </div>
                       
                        <div class="clearfix"></div>
                        <div class="flot-chart">
                           
                            <h1 class="text-danger">
                                <b><%=TotalMDECertifications %></b>
                                </h1>                           
                                <small>New C&A Applications.</small> 
                        </div>
                    </div>
                    <div class="panel-footer">
                        <a href="MDE_CertApps.aspx?certapps=active" class="btn btn-xs btn-info" title="Click to view C&A Applications">View Applications</a>
                    </div>
                </div>
            </div>               
         
               <div class="col-lg-3">
                <div class="hpanel stats">
                    <div class="panel-body h-200">
                        <div class="stats-title pull-left">
                        <div class="stats-icon pull-left">
                            <i class="pe-7s-notebook fa-3x"></i>
                        </div>
                             <div class="clearfix"></div>
                            <h4 class="text-danger" style="font-size:17px">
                           MDE COURSES
                                </h4>
                        </div>
                       
                        <div class="clearfix"></div>
                        <div class="flot-chart">
                           
                            <h1 class="text-danger">
                                <b><%=TotalMDECourses %></b>
                                </h1>                           
                                <small>Total number of Courses.</small> 
                        </div>
                    </div>
                    <div class="panel-footer">
                        <a href="MDEMgmtCourses.aspx?mdecourse=active" class="btn btn-xs btn-info" title="Click to view Courses">View Courses</a>
                    </div>
                </div>
            </div>    
               <div class="col-lg-3"></div>
           </div>
</div>
         </div>
 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPPageRelatedJavascript" runat="server">

</asp:Content>