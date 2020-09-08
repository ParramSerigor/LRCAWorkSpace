<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Inst_SaveScores.aspx.cs" Inherits="LRCA.Inst_SaveScores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPMain" runat="server">
<div class="transition animated fadeIn">
      <div class="hpanel">
        <div class="panel-body">
            <h2 class="font-light m-b-xs" style="color:#AB1027"><span class="font-uppercase">
          Score & Attendence Log </span>         
            </h2>
            <h4>Trainee: <asp:Label ID="lblCrouseName" runat="server" ></asp:Label></h4>
           
        </div>
          <asp:Panel ID="pnlAppStatus" runat="server"></asp:Panel>
    </div>
    <asp:Label ID="lblerror" runat="server" ></asp:Label>
   
 <div class="row">
        <div class="col-lg-12">
                <div class="hpanel">         
                    <div class="panel-heading">
                        <a class="showhide">
                            <div class="panel-tools">
                                <i class="fa fa-chevron-up"></i>
                            </div>
                       Score Card
                        </a>
                    </div>
                   
            <div class="panel-body">
                
                <table  class="table table-hover table-striped">
											<thead>
												<tr>
													<th>Attended Course </th>
													<th>Score Recieved</th>
                                                    <th>PASS/FAIL</th>
													<th></th>
												</tr>
											</thead>
											<tbody>
                                                <tr><td>
                                                    <asp:DropDownList ID="dropAttendence" CssClass="form-control m-b" ToolTip="Passing Score in Percent" runat="server">
                                                      <asp:ListItem Text="YES" Value="1">YES</asp:ListItem>   
                                                        <asp:ListItem Text="NO" Value="0">NO</asp:ListItem>   
                                                   </asp:DropDownList>                            
                                                    </td>
                                                    <td>
                                                   <asp:DropDownList ID="dropScore" CssClass="form-control m-b" ToolTip="Passing Score in Percent" runat="server">
                                                       <asp:ListItem Text="50%" Value="50%">50%</asp:ListItem>   
                                                        <asp:ListItem Text="60%" Value="60%">60%</asp:ListItem>   
                                                       <asp:ListItem Text="70%" Value="70%">70%</asp:ListItem>   
                                                       <asp:ListItem Text="80%" Value="80%">80%</asp:ListItem>   
                                                       <asp:ListItem Text="90%" Value="90%">90%</asp:ListItem>   
                                                       <asp:ListItem Text="100%" Value="100%">100%</asp:ListItem>   
                                                   </asp:DropDownList>   
                                                    </td>
                                                    <td>
                                                    <asp:DropDownList ID="dropPassFail" CssClass="form-control m-b" ToolTip="Course Passed or Failed" runat="server">
                                                       <asp:ListItem Text="YES" Value="1">PASS</asp:ListItem>   
                                                        <asp:ListItem Text="NO" Value="0">FAIL</asp:ListItem>   
                                                    </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        <asp:Button ID="btnAddTManual" runat="server" Text="Save Results" OnClick="AddTManual_Click" CssClass="btn btn-primary"  ToolTip="Save Results" />
                                                    </td>
                                                </tr>
                                                
											</tbody>
										</table>
           
                </div>
           
        </div>
               
            </div>
            
</div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CPPageRelatedJavascript" runat="server">
   
</asp:Content>

