<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Inst_MgmtCourses.aspx.cs" Inherits="LRCA.Inst_MgmtCourses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPMain" runat="server">
<div class="transition animated fadeIn">
      <div class="hpanel">
        <div class="panel-body">
            <h2 class="font-light m-b-xs" style="color:#AB1027"><span class="font-uppercase">
           Scores & Attendence Log</span>         
            </h2>
            <h4>Manage Trainee Scores & Attendence Log</h4>
            <small></small>
        </div>
          <asp:Panel ID="pnlAppStatus" runat="server"></asp:Panel>
    </div>
   
 <div class="row">
        <div class="col-lg-12">
                <div class="hpanel">         
                    <div class="panel-heading">
                        <a class="showhide">
                            <div class="panel-tools">
                                <i class="fa fa-chevron-up"></i>
                            </div>
                       Your Scheduled Courses
                        </a>
                    </div>
                   
            <div class="panel-body">
    
                                 <table id="example1" class="table table-striped table-bordered table-hover" >
                    <thead>
												<tr>
                                                    <th>Taining Provider</th>
													<th>Title </th>
                                                    <th>Start - End Dates</th>
                                                    <th>Language</th>
                                                    <th>Enrollment</th>
                                                    <th>Location</th>
                                                    <th></th>
												</tr>
											</thead>
											<tbody>
                                                <asp:Panel ID="pnlVideos" runat="server"></asp:Panel>
											</tbody>
                                     </table>
                </div>
        </div>
    </div>     
        </div></div>
       
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CPPageRelatedJavascript" runat="server">
   
</asp:Content>

