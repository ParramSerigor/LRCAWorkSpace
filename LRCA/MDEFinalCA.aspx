<%@ Page Title="" Language="C#" MasterPageFile="~/MDE.Master" AutoEventWireup="true" CodeBehind="MDEFinalCA.aspx.cs" Inherits="LRCA.MDEFinalCA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPMain" runat="server">
<div class="transition animated fadeIn">
      <div class="hpanel">
        <div class="panel-body">
            <h2 class="font-light m-b-xs" style="color:#AB1027"><span class="font-uppercase">
          Certification & Accreditation </span>         
            </h2>
            <h4>Trainee: <asp:Label ID="lblCrouseName" runat="server" ></asp:Label></h4>
           
        </div>
          <asp:Panel ID="pnlAppStatus" runat="server"></asp:Panel>
    </div>
    <asp:Label ID="lblerror" runat="server" ></asp:Label>
   <br /><br />
    <div class="row">
        <div class="col-lg-12">
                <div class="hpanel collapsed">         
                    <div class="panel-heading">
                        <a class="showhide">
                            <div class="panel-tools">
                                <i class="fa fa-chevron-up"></i>
                            </div>
                           Certifications & Accreditations Application
                        </a>
                    </div>
                              <div class="panel-body">
                 <div class="row">
                      
                     <div class="col-lg-4">
                        <div class="form-group"><label >Employer Name</label>
                    <div >
                        <asp:Label ID="lblEmployerName" runat="server" class="form-control"></asp:Label>
                        
                    </div></div></div>
                     <div class="col-lg-4">
                        <div class="form-group"><label >Employer Phone</label>
                    <div >
                        <asp:Label ID="lblEmployerPhone" runat="server" class="form-control"></asp:Label>
                        
                    </div></div></div>
                     <div class="col-lg-4">
                        <div class="form-group"><label >Employer Email</label>
                    <div >
                        <asp:Label ID="lblEmployerEmail" runat="server" class="form-control"></asp:Label>
                        
                    </div></div></div>
                   
                 </div>
                <br />
                <div class="row">
                      
                     <div class="col-lg-4">
                        <div class="form-group"><label >Years of Accreditation</label>
                    <div >
                        <asp:Label ID="lblYearFor" runat="server" class="form-control"></asp:Label>
                    </div></div></div>
                    <div class="col-lg-4"></div>
                    <div class="col-lg-4"></div>
                 </div>

                <br />
     
               </div>
                   
                 </div>
            </div>

     </div>
    <br />
 <div class="row">
        <div class="col-lg-12">
                <div class="hpanel">         
                    <div class="panel-heading">
                        <a class="showhide">
                            <div class="panel-tools">
                                <i class="fa fa-chevron-up"></i>
                            </div>
                       Final Checklist before generating an Accreditation Certification 
                        </a>
                    </div>
                   
            <div class="panel-body">
                
                <table  class="table table-hover table-striped">
											<thead>
												<tr>
													<th>Employer Verification </th>
													<th>Background Check</th>
                                                    <th>Payment Confirm</th>
													<th>Notes</th>
                                                    <th>Final Status</th>
                                                    <th></th>
												</tr>
											</thead>
											<tbody>
                                                <tr><td>
                                                    <asp:DropDownList ID="dropEmpVerify" CssClass="form-control m-b" ToolTip="Employer Verification" runat="server">
                                                      <asp:ListItem Text="YES" Value="1">YES</asp:ListItem>   
                                                        <asp:ListItem Text="NO" Value="0">NO</asp:ListItem>   
                                                   </asp:DropDownList>                            
                                                    </td>
                                                    <td>
                                                   <asp:DropDownList ID="dropBackGround" CssClass="form-control m-b" ToolTip="Background Check" runat="server">
                                                      <asp:ListItem Text="YES" Value="1">YES</asp:ListItem>   
                                                        <asp:ListItem Text="NO" Value="0">NO</asp:ListItem>  
                                                   </asp:DropDownList>   
                                                    </td>
                                                    <td>
                                                    <asp:DropDownList ID="dropPayment" CssClass="form-control m-b" ToolTip="Payment Confirmation" runat="server">
                                                       <asp:ListItem Text="YES" Value="1">YES</asp:ListItem>   
                                                        <asp:ListItem Text="NO" Value="0">NO</asp:ListItem>   
                                                    </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                       <asp:TextBox ID="txtNotes" class="form-control" placeholder="Notes" title="Comments" runat="server" ></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="dropFinalStatus" CssClass="form-control m-b" ToolTip="Final Decision" runat="server">
                                                       <asp:ListItem Text="Approve" Value="1">Approve</asp:ListItem>   
                                                        <asp:ListItem Text="Reject" Value="2">On Hold</asp:ListItem>   
                                                         <asp:ListItem Text="Reject" Value="4">Deficient</asp:ListItem>   
                                                         <asp:ListItem Text="Reject" Value="0">Reject</asp:ListItem>   
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
